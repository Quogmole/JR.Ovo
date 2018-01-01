using System.Linq;
using System.Net.Http;
using System.Web.Http;
using JR.Ovo.Services;
using JR.Ovo.Web.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JR.Ovo.Web.Tests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        ///     Test to check that the response from the api service is received and parsed correctly
        /// </summary>
        [TestMethod]
        public void GetAllCustomersReturnsCustomers()
        {
            // Arrange
            var service = new MockApiService();

            var controller = new CustomerController(service)
            {
                Request = new HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };

            // Act
            var response = controller.GetAllCustomers();

            // Assert
            Assert.IsTrue(response.Any());
        }

        private class MockApiService : IApiService
        {
            private static string CustomersReturnedByGetAllCustomers =>
                "{\"customers\":[{\"id\":\"be1d35af-6020-4445-9451-f13facfcfc9a\",\"firstName\":\"David\",\"lastName\":\"Bond\",\"gender\":\"Male\",\"title\":\"Mr\"}" +
                ",{\"id\":\"35dcc4b1-2659-4497-abc7-dac94ec66812\",\"firstName\":\"Chris\",\"lastName\":\"Waldron\",\"gender\":\"Male\",\"title\":\"Mr\"}," +
                "{\"id\":\"c340adc6-af7c-43c5-b2e1-5c4a79aec873\",\"firstName\":\"Chris\",\"lastName\":\"Reed\",\"gender\":\"Male\",\"title\":\"Mr\"}," +
                "{\"id\":\"452e644a-8b21-4cfb-9683-f363be7aef6f\",\"firstName\":\"Tanya\",\"lastName\":\"Rusakova\",\"gender\":\"Female\",\"title\":\"Mrs\"}]}";

            public string GetAllCustomers()
            {
                return CustomersReturnedByGetAllCustomers;
            }
        }
    }
}