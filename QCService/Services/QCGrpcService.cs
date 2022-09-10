using AutoMapper;
using Grpc.Core;
using QCService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Warehouse_Backend.Grpc;

namespace QCService.Services
{
    public class QCGrpcService : QCGrpc.QCGrpcBase
    {
        private readonly IQualityCheckRepository qualityCheckRepository;
        private readonly IMapper mapper;

        public QCGrpcService(IQualityCheckRepository qualityCheckRepository, IMapper mapper)
        {
            this.qualityCheckRepository = qualityCheckRepository;
            this.mapper = mapper;
        }

        public override async Task<QualityCheckResponse> CreateQCRecords(QualityCheckRequest request, ServerCallContext context)
        {
            try
            {


                var orderCode = request.Ordercode;
                var qualityCheckForCreation = request.QualityCheck;

                List<QualityCheck> qcList = new List<QualityCheck>();
                int i = 1;
                foreach (var qcForInsert in qualityCheckForCreation)
                {
                    string qcTag = orderCode + "-" + qcForInsert.QCListDate + "-" + i.ToString();
                    qcForInsert.QCList = orderCode;
                    qcForInsert.QCTag = qcTag;
                    qcForInsert.QualityCheckId = new Guid().ToString();
                    i++;

                    var qualityCheck = await qualityCheckRepository.OrderExistsForQualityCheck(orderCode, qcTag);
                    if (qualityCheck)
                    {
                        return null;
                    }

                    var qualityCheckEntity = mapper.Map<Entities.QualityCheck>(qcForInsert);

                    qualityCheckEntity.Active = true;
                    qualityCheckEntity.Company_Code =    "ABC";
                    qualityCheckEntity.Company_Name =    "ABC";
                    qualityCheckEntity.Customer_Code =   "ABC";
                    qualityCheckEntity.Customer_Name =   "ABC";
                    qualityCheckEntity.Warehouse_Code =  "ABC";
                    qualityCheckEntity.Warehouse_Name = "ABC";
                    qualityCheckEntity.Product_Code = qcForInsert.ProductCode;
                    qualityCheckEntity.QC_List = qcForInsert.QCList;
                    qualityCheckEntity.QC_ListDate = qcForInsert.QCListDate;
                    qualityCheckEntity.QC_ListTime = qcForInsert.QCListTime;
                    qualityCheckEntity.QC_Tag = qcForInsert.QCTag;
                    qualityCheckEntity.CreatedBy = "Grpc";
                    qualityCheckEntity.CreatedDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
                    qualityCheckEntity.CreatedTime = DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
                    qualityCheckEntity.IsDeleted = false;
                    qualityCheckEntity.QC_Status = "Pending";

                    var qualityCheckProcessed = await qualityCheckRepository.UpdateQualityCheckStatus(orderCode, qcTag, qualityCheckEntity);
                    await qualityCheckRepository.SaveChanges();
                    var qualityCheckModel = mapper.Map<QualityCheck>(qualityCheckProcessed);
                    qcList.Add(qualityCheckModel);
                }

                var response = new QualityCheckResponse();
                foreach (var qcitem in qcList)
                {
                    response.QualityCheck.Add(qcitem);
                }

                return response;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
