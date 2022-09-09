using OrderReceive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderReceive.Repositories
{
    public interface IOrderLinesRepository
    {
        Task<OrderLines> GetOrderLinesById(string lineID);
        Task<IEnumerable<OrderLines>> GetOrderLines(string orderCode);
        Task<OrderLines> AddOrUpdateOrderLine(string lineCode, OrderLines orderLine);
        void UpdateOrderLine(OrderLines orderLine);
        void RemoveOrderLine(OrderLines orderLine);
        Task<bool> SaveChanges();
    }
}
