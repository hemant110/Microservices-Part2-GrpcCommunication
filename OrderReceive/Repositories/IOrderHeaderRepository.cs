using OrderReceive.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderReceive.Repositories
{
    public interface IOrderHeaderRepository
    {
        Task<OrderHeader> OrderExists(string OrderCode);

        Task<OrderHeader> GetOrderByID(string OrderCode);

        void AddOrder(OrderHeader orderHeader);

        Task<bool> SaveChanges();

        Task ClearLines(string orderCode);
    }
}
