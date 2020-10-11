using System;
using System.Collections.Generic;
using System.Linq;
using Domain.DTOs.Common;
using Domain.DTOs.Sales;
using Domain.Resources;
using Domain.Services.Common;
using Domain.Types;

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

        /// <summary>
        /// This method should return all Product records which match the search criteria provided
        ///     - TextFilter (optional)
        ///         Filters products based on Code or Description containing the text
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Response<List<Product>> GetProducts(ProductRequest request)
        {
            var response = new Response<List<Product>>();
            var cMethodName = "OrderService.GetProducts(..)";

            try
            {
                if (request == null)
                {
                    throw new ArgumentException(DomainResource.NullRequest);
                }

                var sqlQuery = @"<Your SQL Code Here>";

                var sqlResponse = Database.Read<Product>(sqlQuery);

                if (sqlResponse.Success)
                {
                    response.Value = sqlResponse.Value;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

                var logData = new
                {
                    Request = request,
                    Exception = ex
                };

                var msg = string.Format(DomainResource.ErrorOccuredInXY, cMethodName, ex.Message);

                LoggerService.Log(LogArea.Sales, GeneralHelper.ExceptionLogType(ex), msg, logData);
            }

            return response;
        }
    }
}
