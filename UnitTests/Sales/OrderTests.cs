using Domain.Services.Sales;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Sales
{
    [TestClass]
    public class OrderTests
    {
        #region GetOrders()

        [TestMethod]
        public void GetOrdersBasicTest()
        {
            var orderService = new OrderService();

            var res = orderService.GetOrders();

            Assert.IsTrue(res.Count >= 2, "Expected to find at least 2 orders with line items");
        }

        #endregion
    }
}
