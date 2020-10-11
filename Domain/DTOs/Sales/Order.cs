using System;
using System.Collections.Generic;

namespace Domain.DTOs.Sales
{
    public class Order
    {
        public string OrderNumber { get; set; }
        public List<OrderLineItem> LineItems { get; set; }
        public DateTime CreatedTimestamp { get; set; }
    }
}
