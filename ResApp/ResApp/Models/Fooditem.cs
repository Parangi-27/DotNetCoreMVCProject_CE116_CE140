using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ResApp.Models
{
    public class Fooditem
    {
        public int Id { get; set; }
        [Required]
        public string Itemname { get; set; }
        public double price { get; set; }

    }
}
