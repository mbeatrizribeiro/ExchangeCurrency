using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;

namespace ExchangeCurrency.Api.Integration
{
    public class ExchangeratesapiConnect
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ExchangeratesapiConnect(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }
        public HttpClient GetClient()
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["v1/convert"]);

            return client;
        }

    }
}
    
