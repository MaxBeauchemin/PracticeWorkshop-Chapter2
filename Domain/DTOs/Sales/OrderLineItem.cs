namespace Domain.DTOs.Sales
{
    public class OrderLineItem
    {
        public string ProductCode { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
    }
}
