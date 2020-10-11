using Domain.DTOs.Sales;
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

        #region GetProducts(ProductRequest request)

        [TestMethod]
        public void GetProductsBasicTest()
        {
            var orderService = new OrderService();

            var request = new ProductRequest
            {
                TextFilter = null
            };

            var response = orderService.GetProducts(request);

            Assert.IsTrue(response.Success, response.Message);
            Assert.IsNotNull(response.Value, "Response's Value should not be null");

            Assert.IsTrue(response.Value.Count >= 3, "At least 3 products should have been returned");
        }

        [TestMethod]
        public void GetProductsCodeTest()
        {
            var orderService = new OrderService();

            var request = new ProductRequest
            {
                TextFilter = "XB"
            };

            var response = orderService.GetProducts(request);

            Assert.IsTrue(response.Success, response.Message);
            Assert.IsNotNull(response.Value, "Response's Value should not be null");

            Assert.AreEqual(2, response.Value.Count, "Expected 2 records");
        }

        [TestMethod]
        public void GetProductsCodeExactMatchTest()
        {
            var orderService = new OrderService();

            var request = new ProductRequest
            {
                TextFilter = "XBCTRL"
            };

            var response = orderService.GetProducts(request);

            Assert.IsTrue(response.Success, response.Message);
            Assert.IsNotNull(response.Value, "Response's Value should not be null");

            Assert.AreEqual(1, response.Value.Count, "Expected 1 record");
        }

        [TestMethod]
        public void GetProductsDescriptionTest()
        {
            var orderService = new OrderService();

            var request = new ProductRequest
            {
                TextFilter = "Xbox"
            };

            var response = orderService.GetProducts(request);

            Assert.IsTrue(response.Success, response.Message);
            Assert.IsNotNull(response.Value, "Response's Value should not be null");

            Assert.AreEqual(2, response.Value.Count, "Expected 2 records");
        }

        [TestMethod]
        public void GetProductsDescriptionExactMatchTest()
        {
            var orderService = new OrderService();

            var request = new ProductRequest
            {
                TextFilter = "Xbox One Controller"
            };

            var response = orderService.GetProducts(request);

            Assert.IsTrue(response.Success, response.Message);
            Assert.IsNotNull(response.Value, "Response's Value should not be null");

            Assert.AreEqual(1, response.Value.Count, "Expected 1 record");
        }

        [TestMethod]
        public void GetProductsNoMatchesTest()
        {
            var orderService = new OrderService();

            var request = new ProductRequest
            {
                TextFilter = "Does Not Exist"
            };

            var response = orderService.GetProducts(request);

            Assert.IsTrue(response.Success, response.Message);
            Assert.IsNotNull(response.Value, "Response's Value should not be null");

            Assert.AreEqual(0, response.Value.Count, "Expected 0 records");
        }

        #endregion
    }
}
