using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderReceive.Entities
{
    public class OrderHeader
    {
        public Guid OrderHeaderId { get; set; }
        [Required]
        public string Order_Code { get; set; }

        [Required]
        public string Order_Date { get; set; }

        [Required]
        public string Order_Time { get; set; }

        public Collection<OrderLines> OrderLines { get; set; }

        public string Order_Notes { get; set; }

        public string Order_Type { get; set; }

        [Required]
        public string Order_Status { get; set; }

        [Required]
        public string Customer_Code { get; set; }

        [Required]
        public string Customer_Name { get; set; }

        [Required]
        public string Warehouse_Code { get; set; }

        [Required]
        public string Warehouse_Name { get; set; }

        [Required]
        public string Company_Code { get; set; }

        [Required]
        public string Company_Name { get; set; }

        public string Billed { get; set; }

        [Required]
        public bool Active { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        [Required]
        public string CreatedDate { get; set; }

        [Required]
        public string CreatedTime { get; set; }

        public string UpdatedBy { get; set; }

        public string UpdatedDate { get; set; }

        public string UpdatedTime { get; set; }

        public string DeletedBy { get; set; }

        public string DeletedDate { get; set; }

        public string DeletedTime { get; set; }
    }
}
