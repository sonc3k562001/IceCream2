using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ice_Cream.Models
{
    public class Bill
    {
        public long id { get; set; }
        public string catePayment { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
