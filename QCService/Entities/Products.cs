using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QCService.Entities
{
    public class Products
    {
        [Required]
        [Key]
        public string Product_Code { get; set; }
        public string Unit { get; set; }
    }
}
