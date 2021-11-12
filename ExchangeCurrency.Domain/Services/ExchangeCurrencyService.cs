using ExchangeCurrency.Domain.Models;
using ExchangeCurrency.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace ExchangeCurrency.Domain.Services
{
    public class ExchangeCurrencyService : IExchangeCurrencyService
    {
        private readonly IExchangerateapiService _exchangerateapiService;
        public ExchangeCurrencyService()
        {

        }

        public async Task<double> GetExchangeCurrency([FromBody] string from, [FromBody] string to, [FromBody] double amount, int profile)
        {
            var request = new CurrencyRequest()
            {
                Amount = amount,
                FromCurrency = from,
                ToCurrency = to,
            };

            var convertion = await _exchangerateapiService.GetCurrencyAsync(request);

            var retorno = JsonConvert.DeserializeObject<CurrencyResponse>(convertion.Resultado.ToString());

            if (profile == (int)EnumProfile.Varejo)
            {
                retorno.Resultado = retorno.Resultado * request.TaxProfileVarejo;
                return retorno.Resultado;
            }

            if (profile == (int)EnumProfile.Personnalite)
            {
                retorno.Resultado = retorno.Resultado * request.TaxProfilePersonnalite;
                return retorno.Resultado;
            }


            if (profile == (int)EnumProfile.Private)
            {
                retorno.Resultado = retorno.Resultado * request.TaxProfilePrivate;
                return retorno.Resultado;
            }

            else throw new Exception();

        }

    }
}
