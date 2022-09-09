using Microsoft.EntityFrameworkCore;
using OrderReceive.DBContexts;
using OrderReceive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderReceive.Repositories
{
    public class OrderLineRepository : IOrderLinesRepository
    {
        private readonly OrderReceiveDbContext orderReceiveDbContext;
        public OrderLineRepository(OrderReceiveDbContext orderReceiveDbContext)
        {
            this.orderReceiveDbContext = orderReceiveDbContext;
        }
        public async Task<OrderLines> AddOrUpdateOrderLine(string orderCode, OrderLines orderLine)
        {
            var existingLine = await orderReceiveDbContext.OrderLines.Where(x => x.Order_Code == orderCode
            && x.ProductCode == orderLine.ProductCode).FirstOrDefaultAsync();

            if(existingLine == null)
            {
                orderLine.Active = true;
                orderLine.Company_Code = "ABC";
                orderLine.Company_Name = "ABC";
                orderLine.CreatedBy = "Sys";
                orderLine.CreatedDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
                orderLine.CreatedTime = DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
                orderLine.Customer_Code = "ABC";
                orderLine.Customer_Name = "ABC";
                orderLine.LineId = orderCode +DateTime.Now.Date.ToString("yyyyMMdd") + DateTime.Now.TimeOfDay.ToString().Substring(0, 8).Replace(":","");
                orderLine.Warehouse_Code = "ABC";
                orderLine.Warehouse_Name = "ABC";

                orderLine.Order_Code = orderCode;
                orderReceiveDbContext.OrderLines.Add(orderLine);
                return orderLine;
            }
            existingLine.Unit = orderLine.Unit;
            existingLine.QtyOrdered = orderLine.QtyOrdered;
            return existingLine;
        }

        public async Task<IEnumerable<OrderLines>> GetOrderLines(string orderCode)
        {
            return (await orderReceiveDbContext.OrderLines.//Inclide(o=>o.Product)
                Where(x => x.Order_Code == orderCode).ToListAsync());
        }

        public async Task<OrderLines> GetOrderLinesById(string lineID)
        {
            return await orderReceiveDbContext.OrderLines.
                Where(x => x.LineId == lineID).FirstOrDefaultAsync();
        }

        public void RemoveOrderLine(OrderLines orderLine)
        {
            orderReceiveDbContext.OrderLines.Remove(orderLine);
        }

        public async Task<bool> SaveChanges()
        {
            return (await orderReceiveDbContext.SaveChangesAsync() > 0);
        }

        public void UpdateOrderLine(OrderLines orderLine)
        {
            throw new NotImplementedException();
        }
    }
}
