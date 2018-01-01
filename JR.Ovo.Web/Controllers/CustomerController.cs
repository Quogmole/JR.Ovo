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

        public CustomerController(IApiService apiService)
        {
            if (apiService == null)
                throw new ArgumentNullException(nameof(apiService));
            _apiService = apiService;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var response = _apiService.GetAllCustomers();

            if (string.IsNullOrWhiteSpace(response)) return new List<Customer>();

            var customers = JObject.Parse(response).SelectToken("customers").ToString();

            var lst = JsonConvert.DeserializeObject<List<Customer>>(customers);

            if (lst != null && lst.Any())
            {
                return lst.OrderBy(c => c.LastName);
            }

            return new List<Customer>();
        }

        public IHttpActionResult GetCustomerById(string id)
        {
            var customer = GetAllCustomers().FirstOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }
    }
}