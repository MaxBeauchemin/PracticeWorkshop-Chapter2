using System;

namespace Domain.DTOs.Sales
{
    public class OrderItemsSqlResult
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime CreatedTimestamp { get; set; }
        public string CreatedBy { get; set; }
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductCurrentPrice { get; set; }
    }
}
