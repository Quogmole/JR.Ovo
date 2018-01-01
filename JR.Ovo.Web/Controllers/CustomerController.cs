using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using JR.Ovo.Services;
using JR.Ovo.Web.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JR.Ovo.Web.Controllers
{
    public class CustomerController : ApiController
    {
        private readonly IApiService _apiService;

        /// <inheritdoc />
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:JR.Ovo.Web.Controllers.CustomerController" /> class.
        /// </summary>
        /// <param name="apiService">The API service.</param>
        /// <exception cref="T:System.ArgumentNullException">apiService</exception>
        public CustomerController(IApiService apiService)
        {
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
        }

        /// <summary>
        ///     Gets all customers.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Customer> GetAllCustomers()
        {
            var response = _apiService.GetAllCustomers();

            if (string.IsNullOrWhiteSpace(response)) return new List<Customer>();

            var customers = JObject.Parse(response).SelectToken("customers").ToString();

            var lst = JsonConvert.DeserializeObject<List<Customer>>(customers);

            if (lst != null && lst.Any()) return lst.OrderBy(c => c.LastName);

            return new List<Customer>();
        }

        /// <summary>
        ///     Gets the customer by id.
        /// </summary>
        /// <param name="id">the customer id</param>
        /// <returns></returns>
        public IHttpActionResult GetCustomerById(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return NotFound();

            //check that id is a valid guid
            if (!Guid.TryParse(id, out var idGuid)) return NotFound();

            //this is acceptable given the known small dataset
            var customer = GetAllCustomers().FirstOrDefault(c => c.Id == idGuid.ToString());

            if (customer == null) return NotFound();

            return Ok(customer);
        }
    }
}