using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderReceive.Models
{
    public class OrderLineForUpdate
    {
        public string Order_Code { get; set; }

        public string Notes { get; set; }

        public string LineId { get; set; }
        public string Product { get; set; }
        public string Unit { get; set; }

        public decimal QtyOrdered { get; set; }
        public string MfgDate { get; set; }

        public string MfgTime { get; set; }

        public string ExpDate { get; set; }

        public string ExpTime { get; set; }
    }
}
