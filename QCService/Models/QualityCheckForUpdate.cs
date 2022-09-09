using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QCService.Models
{
    public class QualityCheckForUpdate
    {
        public Guid QualityCheckId { get; set; }
        public string Product_Code { get; set; }
        public string QC_Tag { get; set; }
        public string QC_List { get; set; }
        public string QC_ListDate { get; set; }
        public string QC_ListTime { get; set; }
        public string QC_By { get; set; }
        public string QC_Status { get; set; }
        public string QC_Notes { get; set; }
        public string QC_Action { get; set; }

        public bool Active { get; set; }

        public bool IsDeleted { get; set; }

        public string UpdatedBy { get; set; }

        public string UpdatedDate { get; set; }

        public string UpdatedTime { get; set; }
    }
}
