using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ResApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string cusName { get; set; }
  
    }
}
