using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderReceive.Entities
{
    public class Products
    {
        [Required]
        [Key]
        public string Product { get; set; }
        public string Unit { get; set; }
    }
}
