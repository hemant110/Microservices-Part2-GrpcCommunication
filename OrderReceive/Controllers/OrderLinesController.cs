using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderReceive.Models;
using OrderReceive.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderReceive.Controllers
{
    [Route("api/orders/{orderCode}/orderlines")]
    [ApiController]
    public class OrderLinesController : ControllerBase
    {
        private readonly IOrderHeaderRepository orderHeaderRepository;
        private readonly IOrderLinesRepository orderLinesRepository;
        private readonly IMapper mapper;

        public OrderLinesController(IOrderHeaderRepository orderHeaderRepository, 
            IOrderLinesRepository orderLinesRepository, 
            IMapper mapper)
        {
            this.orderHeaderRepository = orderHeaderRepository;
            this.orderLinesRepository = orderLinesRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderLine>>> Get(string orderCode)
        {
            if(await orderHeaderRepository.OrderExists(orderCode) == null)
            {
                return NotFound();
            }

            var orderLines = await orderLinesRepository.GetOrderLines(orderCode);
            return Ok(mapper.Map<List<OrderLine>>(orderLines));
        }

        [HttpGet("{orderLineId}", Name ="GetOrderLine")]
        public async Task<ActionResult<OrderLine>> Get(string orderCode, string orderLineId)
        {
            if(await orderHeaderRepository.OrderExists(orderCode) == null)
            {
                return NotFound();
            }

            var orderLine = orderLinesRepository.GetOrderLinesById(orderLineId);

            if(orderLine == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<OrderLine>(orderLine));
        }

        [HttpPost]
        public async Task<ActionResult<OrderLine>> Post(string orderCode, [FromBody] OrderLineForCreation orderLineForCreation)
        {
            var order = await orderHeaderRepository.OrderExists(orderCode);
            if(order == null)
            {
                return NotFound();
            }

            var orderLineEntity = mapper.Map<Entities.OrderLines>(orderLineForCreation);

            orderLineEntity.OrderHeaderId = order.OrderHeaderId;
            orderLineEntity.Order_Code = orderCode;

            var savedOrderLine = await orderLinesRepository.AddOrUpdateOrderLine(orderCode, orderLineEntity);
            await orderLinesRepository.SaveChanges();

            var orderLineToReturn = mapper.Map<OrderLine>(savedOrderLine);

            return CreatedAtRoute("GetOrderLine",
                        new { orderCode = orderCode, orderLineId = orderLineToReturn.LineId }
                        , orderLineToReturn);
        }

        [HttpPut("{orderLineId}")]
        public async Task<ActionResult<OrderLine>> Put(string orderCode, string orderLineId, 
            [FromBody] OrderLineForUpdate orderLineForUpdate)
        {
            if(await orderHeaderRepository.OrderExists(orderCode) == null)
            {
                return NotFound();
            }

            var orderLineEntity = await orderLinesRepository.GetOrderLinesById(orderLineId);
            if(orderLineEntity == null)
            {
                return NotFound();
            }

            mapper.Map(orderLineForUpdate, orderLineEntity);

            orderLinesRepository.UpdateOrderLine(orderLineEntity);
            await orderLinesRepository.SaveChanges();

            return Ok(mapper.Map<OrderLine>(orderLineEntity));
        }

        [HttpDelete("{orderLineId}")]
        public async Task<ActionResult> Delete(string orderCode, string orderLineId)
        {
            if(await orderHeaderRepository.OrderExists(orderCode) == null)
            {
                return NotFound();
            }

            var orderLineEntity = await orderLinesRepository.GetOrderLinesById(orderLineId);
            if(orderLineEntity == null)
            {
                return NotFound();
            }

            orderLinesRepository.RemoveOrderLine(orderLineEntity);
            await orderLinesRepository.SaveChanges();

            return NoContent();
        }










    }
}
