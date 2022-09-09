using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderReceive.Models
{
    public class OrderLine
    {
        public string Order_Code { get; set; }

        public string Notes { get; set; }

        public string LineId { get; set; }

        public string ProductCode { get; set; }

        public string ProductDescription { get; set; }

        public string Lines_Unit { get; set; }

        public decimal QtyOrdered { get; set; }

        public decimal QtyPlanned { get; set; }
        public decimal QtyPicked { get; set; }
        public decimal QtyAllocated { get; set; }
        public Products Product { get; set; }
    }
}
