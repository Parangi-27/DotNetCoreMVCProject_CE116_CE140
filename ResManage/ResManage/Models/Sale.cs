using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResManage.Models
{
    public class Sale
    {
        public int Id { get; set; }

        public string Pname { get; set; }

        public int Pquantity { get; set; }

        public DateTime Pdate { get; set; }
    }
}
