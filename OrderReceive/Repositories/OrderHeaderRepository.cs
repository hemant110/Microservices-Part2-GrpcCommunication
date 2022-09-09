using Microsoft.EntityFrameworkCore;
using OrderReceive.DBContexts;
using OrderReceive.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace OrderReceive.Repositories
{
    public class OrderHeaderRepository : IOrderHeaderRepository
    {
        private readonly OrderReceiveDbContext orderReceiveDbContext;

        public OrderHeaderRepository(OrderReceiveDbContext orderReceiveDbContext)
        {
            this.orderReceiveDbContext = orderReceiveDbContext;
        }
        public void AddOrder(OrderHeader orderHeader)
        {
            orderHeader.Active = true;
            orderHeader.Billed = "No";
            orderHeader.Company_Code = "ABC";
            orderHeader.Company_Name = "ABC";
            orderHeader.CreatedBy = "Sys";
            orderHeader.CreatedDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            orderHeader.CreatedTime = DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
            orderHeader.Customer_Code = "ABC";
            orderHeader.Customer_Name = "ABC";
            orderHeader.OrderHeaderId = new System.Guid();
            orderHeader.Order_Date = DateTime.Now.Date.ToString("yyyy-MM-dd");
            orderHeader.Order_Status = "Pending";
            orderHeader.Order_Time = DateTime.Now.TimeOfDay.ToString().Substring(0, 8);
            orderHeader.Order_Type = "Manual";
            orderHeader.Warehouse_Code = "ABC";
            orderHeader.Warehouse_Name = "ABC";

            orderReceiveDbContext.Add(orderHeader);
        }

        public async Task ClearLines(string orderCode)
        {
            var linesToClear = orderReceiveDbContext.OrderLines.Where(x => x.Order_Code == orderCode);
            orderReceiveDbContext.OrderLines.RemoveRange(linesToClear);
            await SaveChanges();
        }

        public async Task<OrderHeader> GetOrderByID(string OrderCode)
        {
            return await orderReceiveDbContext.OrderHeader.Include("OrderLines").
                Where(x => x.Order_Code == OrderCode).FirstOrDefaultAsync();
        }

        public async Task<OrderHeader> OrderExists(string orderCode)
        {
            return await orderReceiveDbContext.OrderHeader.Where(x => x.Order_Code == orderCode).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveChanges()
        {
            return (await orderReceiveDbContext.SaveChangesAsync() > 0);
        }
    }
}