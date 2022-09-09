using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QCService.Entities
{
    public class QualityCheck
    {
        public Guid QualityCheckId { get; set; }
        [Required]
        public string Product_Code { get; set; }
        [Required]
        public string QC_Tag { get; set; }
        [Required]
        public string QC_List { get; set; }
        [Required]
        public string QC_ListDate { get; set; }
        [Required]
        public string QC_ListTime { get; set; }
        public string QC_By { get; set; }
        public string QC_Status { get; set; }
        public string QC_Notes { get; set; }
        public string QC_Action { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
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
