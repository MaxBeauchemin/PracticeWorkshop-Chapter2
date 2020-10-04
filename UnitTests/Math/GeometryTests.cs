using Domain.DTOs.Math;
using Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Math
{
    [TestClass]
    public class GeometryTests
    {
        #region Response<CartesianCoordinates> PolarToCartesian(PolarCoordinates request)

        [TestMethod]
        public void PolarToCartesianBaseTest()
        {
            var request = new PolarCoordinates
            {
                Angle = 22.6,
                DistanceFromOrigin = 13
            };

            var response = GeometryService.PolarToCartesian(request);

            Assert.IsNotNull(response, "Response should never be null");
            Assert.IsTrue(response.Success, "Response.Success should be true!");
            Assert.IsNotNull(response.Value, "The [Value] property of the Response object should not be null");
            Assert.IsNotNull(response.Value.XLocation, "X Location should not be null");
            Assert.IsNotNull(response.Value.YLocation, "Y Location should not be null");
            Assert.AreEqual(12.002, response.Value.XLocation.Value, 0.001, "X Location is incorrect");
            Assert.AreEqual(4.996, response.Value.YLocation.Value, 0.001, "Y Location is incorrect");
        }

        [TestMethod]
        public void PolarToCartesianLargeAngleTest()
        {
            var request = new PolarCoordinates
            {
                Angle = (360 * 3) + 22.6,
                DistanceFromOrigin = 13
            };

            var response = GeometryService.PolarToCartesian(request);

            Assert.IsNotNull(response, "Response should never be null");
            Assert.IsTrue(response.Success, "Response.Success should be true!");
            Assert.IsNotNull(response.Value, "The [Value] property of the Response object should not be null");
            Assert.IsNotNull(response.Value.XLocation, "X Location should not be null");
            Assert.IsNotNull(response.Value.YLocation, "Y Location should not be null");
            Assert.AreEqual(12.002, response.Value.XLocation.Value, 0.001, "X Location is incorrect");
            Assert.AreEqual(4.996, response.Value.YLocation.Value, 0.001, "Y Location is incorrect");
        }

        [TestMethod]
        public void PolarToCartesianZeroDistanceTest()
        {
            var request = new PolarCoordinates
            {
                Angle = 19.25,
                DistanceFromOrigin = 0
            };

            var response = GeometryService.PolarToCartesian(request);

            Assert.IsNotNull(response, "Response should never be null");
            Assert.IsTrue(response.Success, "Response.Success should be true!");
            Assert.IsNotNull(response.Value, "The [Value] property of the Response object should not be null");
            Assert.IsNotNull(response.Value.XLocation, "X Location should not be null");
            Assert.IsNotNull(response.Value.YLocation, "Y Location should not be null");
            Assert.AreEqual(0, response.Value.XLocation.Value, 0.001, "X Location is incorrect");
            Assert.AreEqual(0, response.Value.YLocation.Value, 0.001, "Y Location is incorrect");
        }

        [TestMethod]
        public void PolarToCartesianOriginTest()
        {
            var request = new PolarCoordinates
            {
                Angle = 0,
                DistanceFromOrigin = 0
            };

            var response = GeometryService.PolarToCartesian(request);

            Assert.IsNotNull(response, "Response should never be null");
            Assert.IsTrue(response.Success, "Response.Success should be true!");
            Assert.IsNotNull(response.Value, "The [Value] property of the Response object should not be null");
            Assert.IsNotNull(response.Value.XLocation, "X Location should not be null");
            Assert.IsNotNull(response.Value.YLocation, "Y Location should not be null");
            Assert.AreEqual(0, response.Value.XLocation.Value, 0.001, "X Location is incorrect");
            Assert.AreEqual(0, response.Value.YLocation.Value, 0.001, "Y Location is incorrect");
        }

        [TestMethod]
        public void PolarToCartesianNullRequestTest()
        {
            var response = GeometryService.PolarToCartesian(null);

            Assert.IsNotNull(response, "Response should never be null");
            Assert.IsFalse(response.Success, "Response.Success should be [False] since a null request was supplied");
        }

        [TestMethod]
        public void PolarToCartesianNullDistanceToOriginTest()
        {
            var request = new PolarCoordinates
            {
                Angle = 22.6
            };

            var response = GeometryService.PolarToCartesian(request);

            Assert.IsNotNull(response, "Response should never be null");
            Assert.IsFalse(response.Success, "Response.Success should be [False] since an invalid request was supplied");
        }

        [TestMethod]
        public void PolarToCartesianNullAngleTest()
        {
            var request = new PolarCoordinates
            {
                DistanceFromOrigin = 13
            };

            var response = GeometryService.PolarToCartesian(request);

            Assert.IsNotNull(response, "Response should never be null");
            Assert.IsFalse(response.Success, "Response.Success should be [False] since an invalid request was supplied");
        }

        [TestMethod]
        public void PolarToCartesianNegativeDistanceTest()
        {
            var request = new PolarCoordinates
            {
                Angle = 22.6,
                DistanceFromOrigin = -13
            };

            var response = GeometryService.PolarToCartesian(request);

            Assert.IsNotNull(response, "Response should never be null");
            Assert.IsFalse(response.Success, "Response.Success should be [False] since an invalid request was supplied");
        }

        #endregion
    }
}
