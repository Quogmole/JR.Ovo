using System;
using System.Net.Http;

namespace JR.Ovo.Services
{
    public class ApiService : IApiService
    {
        private const string Url = "https://sheltered-depths-66346.herokuapp.com/customers"; //TODO: Add to config files

        public string GetAllCustomers()
        {
            return CustomerRequest();
        }

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