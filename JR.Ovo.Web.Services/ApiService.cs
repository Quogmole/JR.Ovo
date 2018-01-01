using System;
using System.Net.Http;

namespace JR.Ovo.Services
{
    /// <summary>
    /// Service to access the Ovo api
    /// </summary>
    /// <seealso cref="JR.Ovo.Services.IApiService" />
    // ReSharper disable once ClassNeverInstantiated.Global
    public class ApiService : IApiService
    {
        private const string Url = "https://sheltered-depths-66346.herokuapp.com/customers"; //TODO: Add to config file

        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns></returns>
        public string GetAllCustomers()
        {
            return CustomerRequest();
        }

        /// <summary>
        /// Gets the customer request.
        /// </summary>
        /// <returns></returns>
        private static string CustomerRequest()
        {
            using (var httpClient = new HttpClient())
            {
                var response = httpClient.GetStringAsync(new Uri(Url)).Result;

                return response;
            }
        }
    }
}