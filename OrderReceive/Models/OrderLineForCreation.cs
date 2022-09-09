using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderReceive.Models
{
    public class OrderLineForCreation
    {
        public string ProductCode { get; set; }
        public string Unit { get; set; }

        public decimal QtyOrdered { get; set; }
        public string MfgDate { get; set; }

        public string MfgTime { get; set; }

        public string ExpDate { get; set; }

        public string ExpTime { get; set; }
    }
}
