using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderReceive.Entities
{
    public class OrderChangeProduct
    {
        public Guid Id { get; set; }
        public string Order_Code { get; set; }
        public Guid UserId { get; set; }
        public string LineId { get; set; }
        public string Product { get; set; }
        public string Unit { get; set; }
        public DateTimeOffset InsertedAt { get; set; }
        public OrderChangeTypeEnum OrderChangeType { get; set; }
    }
}
