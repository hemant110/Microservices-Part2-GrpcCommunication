using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderReceive.Messages;
using OrderReceive.Models;
using OrderReceive.Repositories;
using OrderReceive.Services;
using Polly.CircuitBreaker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OrderReceive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderHeaderRepository orderHeaderRepository;
        private readonly IMapper mapper;
        private readonly IQualityCheckService qualityCheckService;
        public OrdersController(IOrderHeaderRepository orderHeaderRepository, IMapper mapper, IQualityCheckService qualityCheckService)
        {
            this.orderHeaderRepository = orderHeaderRepository;
            this.mapper = mapper;
            this.qualityCheckService = qualityCheckService;
        }

        [HttpGet("{orderCode}", Name ="GetOrder")]
        public async Task<ActionResult<OrderHeader>> Get(string orderCode)
        {
            var order = await orderHeaderRepository.GetOrderByID(orderCode);
            if(order == null)
            {
                return NotFound();
            }

            var result = mapper.Map<OrderHeader>(order);
            result.Order_NoOfLines = order.OrderLines.Count;
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<OrderHeader>> Post(OrderForCreation orderForCreation)
        {
            var orderEntity = mapper.Map<Entities.OrderHeader>(orderForCreation);
            orderHeaderRepository.AddOrder(orderEntity);
            await orderHeaderRepository.SaveChanges();

            var orderToReturn = mapper.Map<OrderHeader>(orderEntity);

            return CreatedAtRoute("GetOrder", new { orderCode = orderEntity.Order_Code }, orderToReturn);


        }

        [HttpPost("createorder")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<ActionResult> CreateOrderAsync([FromBody] OrderCreated orderCreated)
        {
            try
            {
                var orderExists = await orderHeaderRepository.GetOrderByID(orderCreated.Order_Code);

                if(orderExists == null)
                {
                    return BadRequest();
                }

                List<Entities.QualityCheck> qcCheckList = new List<Entities.QualityCheck>();

                foreach(OrderLine oLine in orderCreated.OrderLines)
                {
                    Entities.QualityCheck qcCheck = new Entities.QualityCheck
                    {
                        Product_Code = oLine.ProductCode,
                        QC_List = oLine.Order_Code,
                        QC_ListDate = DateTime.Now.Date.ToString("yyyy-MM-dd"),
                        QC_ListTime = DateTime.Now.TimeOfDay.ToString().Substring(0, 8)
                    };
                    qcCheckList.Add(qcCheck);
                }

                //OrderCreatedMessage orderCreatedMessage = mapper.Map<OrderCreatedMessage>(orderCreated);
                //orderCreatedMessage.OrderLines = new List<OrderLineMessage>();

                //int total = 0;
                //foreach(var line in order.OrderLines)
                //{
                //    OrderLineMessage lineMessage = mapper.Map<OrderLineMessage>(line);
                //    orderCreatedMessage.OrderLines.Add(lineMessage);
                //}

                bool result = false;
                try
                {
                    //await messageBus.PublishMessage(orderCreatedMessage, "ordercreate");
                    result = await qualityCheckService.PostQualityCheckData(orderCreated.Order_Code, qcCheckList);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                        throw;
                }

                return Accepted(result);

            }
            catch(BrokenCircuitException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.StackTrace);
            }
        }

    }
}
