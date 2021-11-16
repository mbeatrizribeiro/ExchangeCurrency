using ExchangeCurrency.Domain.Services.Interfaces;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;

namespace ExchangeCurrency.Api.Integration
{
    public class ExchangeCurrencyService : IExchangeCurrencyService
    {
        private readonly IExchangerateapiService _exchangerateapiService;
        public ExchangeCurrencyService()
        {

        }

        public async Task<CurrencyResponse> GetExchangeCurrency(CurrencyRequest request, int profile)
        {
            var convertion = await _exchangerateapiService.GetCurrencyAsync(request);

            var retorno = JsonConvert.DeserializeObject<CurrencyResponse>(convertion.ToString());

            if (profile == (int)EnumProfile.Varejo)

            {
                var returns = new CurrencyResponse()
                {
                    Resultado = retorno.Resultado * request.TaxProfileVarejo
                };

                return returns;
            }

            if (profile == (int)EnumProfile.Personnalite)
            {
                var returns = new CurrencyResponse()
                {
                    Resultado = retorno.Resultado * request.TaxProfilePersonnalite
                };

                return returns;
            }


            if (profile == (int)EnumProfile.Private)
            {

                var returns = new CurrencyResponse()
                {
                    Resultado = retorno.Resultado * request.TaxProfilePrivate
                };
                return returns;
            }

            else throw new Exception();

        }

    }
}
