using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QCService.Models;
using QCService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QCService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QualityCheckController : ControllerBase
    {
        IQualityCheckRepository qualityCheckRepository;
        IMapper mapper;
        public QualityCheckController(IQualityCheckRepository qualityCheckRepository, IMapper mapper)
        {
            this.qualityCheckRepository = qualityCheckRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QualityCheck>>> Get()
        {
            var qualityCheckList = await qualityCheckRepository.GetAllQualityCheckTasks();
            if (qualityCheckList.Count() <= 0)
            {
                return NotFound();
            }
            var qualityCheckModel = mapper.Map<List<QualityCheck>>(qualityCheckList.ToList());

            return Ok(qualityCheckModel);
        }
        [HttpGet("{orderCode}" , Name ="GetQCByCode")]
        public async Task<ActionResult<IEnumerable<QualityCheck>>> GetByCode(string orderCode)
        {
            try
            {
                if (!await qualityCheckRepository.OrderExistsForQualityCheck(orderCode, String.Empty))
                {
                    return NotFound();
                }

                var qcList = await qualityCheckRepository.GetQualityCheckTasksByOrder(orderCode);
                    
                var qcModel = mapper.Map<List<QualityCheck>>(qcList.ToList());

                return Ok(qcModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest("Something bad happens.");
            }
        }

        [HttpGet("{orderCode}/{qcTag}", Name = "GetQCByTag")]
        public async Task<ActionResult<IEnumerable<QualityCheck>>> GetByCodeAndTag(string orderCode, string qcTag)
        {
            if (!await qualityCheckRepository.OrderExistsForQualityCheck(orderCode, string.Empty))
            {
                return NotFound();
            }

            var qcList = await qualityCheckRepository.GetQualityCheckTasksByOrderAndTag(orderCode, qcTag);

            var qcModel = mapper.Map<List<QualityCheck>>(qcList.ToList());

            return Ok(qcModel);
        }
        [HttpPut("{orderCode}/{qcTag}")]
        public async Task<ActionResult<QualityCheck>> Put(string orderCode, string qcTag,
            [FromBody] QualityCheckForUpdate qualityCheckForUpdate)
        {
            var qcExist = await qualityCheckRepository.GetQualityCheckTasksByOrderAndTag(orderCode, qcTag);

            if (qcExist == null)
            {
                return NotFound();
            }

            var qcEntity = mapper.Map<Entities.QualityCheck>(qualityCheckForUpdate);
            var processedQC = await qualityCheckRepository.UpdateQualityCheckStatus(orderCode, qcTag, qcEntity);
            await qualityCheckRepository.SaveChanges();
            var qcToReturn = mapper.Map<QualityCheck>(processedQC);

            return CreatedAtRoute("GetQCByTag", new { orderCode = qcToReturn.QC_List, qcTag = qcToReturn.QC_Tag }, qcToReturn);
        }

        [HttpPost("{orderCode}")]
        public async Task<ActionResult<QualityCheck>> Post(string orderCode, [FromBody] List<QualityCheckForCreation> qualityCheckForInsert)
        {
            try
            {
                int i = 1;
                List<QualityCheck> qcList = new List<QualityCheck>();
                foreach (var qcForInsert in qualityCheckForInsert)
                {
                    string qcTag = orderCode + "-" + qcForInsert.QC_ListDate + "-" + i.ToString();
                    qcForInsert.QC_List = orderCode;
                    qcForInsert.QC_Tag = qcTag;
                    qcForInsert.QualityCheckId = new Guid();
                    i++;

                    var qualityCheck = await qualityCheckRepository.OrderExistsForQualityCheck(orderCode, qcTag);
                    if (qualityCheck)
                    {
                        return BadRequest("Record already exists.");
                    }

                    var qualityCheckEntity = mapper.Map<Entities.QualityCheck>(qcForInsert);
                    var qualityCheckProcessed = await qualityCheckRepository.UpdateQualityCheckStatus(orderCode, qcTag, qualityCheckEntity);
                    await qualityCheckRepository.SaveChanges();
                    var qualityCheckModel = mapper.Map<QualityCheck>(qualityCheckProcessed);
                    qcList.Add(qualityCheckModel);
                }

                return CreatedAtRoute("GetQCByCode", new { orderCode = orderCode }, qcList);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest("Something bad happens.");
            }
        }
    }
}
