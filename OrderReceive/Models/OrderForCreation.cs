using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderReceive.Models
{
    public class OrderForCreation
    {
        [Required]
        public string Order_Code { get; set; }
    }
}
