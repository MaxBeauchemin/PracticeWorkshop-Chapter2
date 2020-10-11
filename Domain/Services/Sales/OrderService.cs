using System.Collections.Generic;
using System.Linq;
using Domain.DTOs.Sales;
using Domain.Services.Common;

namespace Domain.Services.Sales
{
    public class OrderService
    {
        public List<Order> GetOrders()
        {
            var output = new List<Order>();

            var sqlQuery = @"SELECT o.OrderId, o.OrderNumber, o.CreatedTimestamp, o.CreatedBy, p.Code as ProductCode, p.Description as ProductDescription, p.CurrentPrice as ProductCurrentPrice
                             FROM dbo.OrderLineItems li
                                INNER JOIN dbo.Orders o
                                    ON li.OrderId = o.OrderId
                                INNER JOIN dbo.Products p
                                    ON p.ProductId = li.ProductId";

            var sqlResponse = Database.Read<OrderItemsSqlResult>(sqlQuery);

            if (sqlResponse.Success)
            {
                var rows = sqlResponse.Value;

                var orderNumbers = rows.Select(r => r.OrderNumber).Distinct();

                foreach (var orderNumber in orderNumbers)
                {
                    var orderRows = rows.Where(r => r.OrderNumber == orderNumber);

                    var firstRow = orderRows.First();

                    var orderDto = new Order
                    {
                        OrderNumber = firstRow.OrderNumber,
                        CreatedTimestamp = firstRow.CreatedTimestamp,
                        LineItems = orderRows.Select(r => new OrderLineItem
                        {
                            ProductCode = r.ProductCode,
                            ProductDescription = r.ProductDescription,
                            ProductPrice = r.ProductCurrentPrice
                        }).ToList()
                    };

                    output.Add(orderDto);
                }
            }

            return output;
        }
    }
}
