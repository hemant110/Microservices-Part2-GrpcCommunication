using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderReceive.Entities
{
    public class QualityCheck
    {
        public string Product_Code { get; set; }
        public string QC_List { get; set; }
        public string QC_ListDate { get; set; }
        public string QC_ListTime { get; set; }
    }
}
