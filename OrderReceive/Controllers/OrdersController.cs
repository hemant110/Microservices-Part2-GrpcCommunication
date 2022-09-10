using AutoMapper;
using Grpc.Net.Client;
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
using Warehouse_Backend.Grpc;

namespace OrderReceive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderHeaderRepository orderHeaderRepository;
        private readonly IMapper mapper;
        public OrdersController(IOrderHeaderRepository orderHeaderRepository, IMapper mapper)
        {
            this.orderHeaderRepository = orderHeaderRepository;
            this.mapper = mapper;
        }

        [HttpGet("{orderCode}", Name = "GetOrder")]
        public async Task<ActionResult<OrderHeader>> Get(string orderCode)
        {
            var order = await orderHeaderRepository.GetOrderByID(orderCode);
            if (order == null)
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

                if (orderExists == null)
                {
                    return BadRequest();
                }

                List<QualityCheckForCreation> qcCheckList = new List<QualityCheckForCreation>();

                foreach (OrderLine oLine in orderCreated.OrderLines)
                {
                    QualityCheckForCreation qcCheck = new QualityCheckForCreation
                    {
                        ProductCode = oLine.ProductCode,
                        QCList = oLine.Order_Code,
                        QCListDate = DateTime.Now.Date.ToString("yyyy-MM-dd"),
                        QCListTime = DateTime.Now.TimeOfDay.ToString().Substring(0, 8)
                    };
                    qcCheckList.Add(qcCheck);
                }

                bool result = false;
                try
                {
                    var channel = GrpcChannel.ForAddress("https://localhost:5001");
                    QualityCheckService qualityCheckService = new QualityCheckService(new QCGrpc.QCGrpcClient(channel));
                    if (qcCheckList.Count > 0)
                        result = await qualityCheckService.PostQualityCheckData(orderCreated.Order_Code, qcCheckList);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

                return Accepted(result);

            }
            catch (BrokenCircuitException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.StackTrace);
            }
        }

    }
}
