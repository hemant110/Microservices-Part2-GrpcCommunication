using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderReceive.Messages
{
    public class OrderCreatedMessage
    {

        public string Order_Code { get; set; }
        public string Order_Date { get; set; }
        public string Order_Time { get; set; }
        public string Order_Type { get; set; }
        public string Order_Invoice { get; set; }
        public string Order_InvoiceDate { get; set; }
        public string Order_InvoiceTime { get; set; }
        public decimal Order_NoOfLines { get; set; }
        public string Order_ToWarehouse { get; set; }
        public string Company_Code { get; set; }
        public string Warehouse_Code { get; set; }
        public string Customer_Code { get; set; }

        public List<OrderLineMessage> OrderLines { get; set; }
    }
}
