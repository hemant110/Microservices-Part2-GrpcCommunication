using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderReceive.Messages
{
    public class OrderLineMessage
    {
        public string LineId { get; set; }
        public string Product { get; set; }
        public string PackConfig { get; set; }
        public string HandlingConfig { get; set; }
        public decimal HandlingRatio { get; set; }
        public string Unit { get; set; }
        public decimal QtyOrdered { get; set; }
        public decimal QtyDelivered { get; set; }
        public decimal QtyReturned { get; set; }
        public string Origin { get; set; }
        public string MfgDate { get; set; }
        public string MfgTime { get; set; }
        public string ExpDate { get; set; }
        public string ExpTime { get; set; }
    }
}
