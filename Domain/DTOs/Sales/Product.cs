using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Sales
{
    public class Product
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal CurrentPrice { get; set; }
    }
}
