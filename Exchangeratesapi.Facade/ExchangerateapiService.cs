using ExchangeCurrency.Domain.Models;
using ExchangeCurrency.Domain.Services.Interfaces;
using Exchangeratesapi.Facade;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeCurrency.Domain.Services
{
    public class ExchangerateapiService : IExchangerateapiService
    {
        //CONSTRUTOR
        public ExchangerateapiService()
        {
        }

        public async Task<CurrencyResponse> GetCurrencyAsync(object json)
        {
            try
            {
                var requestUri = RestService.For<IExchangerateapiService>("https://api.exchangeratesapi.io/");

                var body = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

                var obj = JsonConvert.DeserializeObject<CurrencyResponse>(json.ToString());

                var response = await requestUri.GetCurrencyAsync(obj.ToString());

                return response;
            }

            catch
            {
                throw;
            }
        }



    }
}
