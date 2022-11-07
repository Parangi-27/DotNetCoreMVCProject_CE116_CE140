using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResManage.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string foodname { get; set; }
        public int quantity { get; set; }

        public DateTime Date { get; set; }
    }
}
