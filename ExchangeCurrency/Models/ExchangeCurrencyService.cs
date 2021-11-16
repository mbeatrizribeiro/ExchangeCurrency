using ExchangeCurrency.Api.Integration.Interface;
using System.Threading.Tasks;
using ExchangeCurrency.Api.Models.Interface;
using ExchangeCurrency.Api.Models.Response;
using ExchangeCurrency.Api.Models.Request;
using ExchangeCurrency.Api.Models.Enums;

namespace ExchangeCurrency.Api.Models
{
    public class ExchangeCurrencyService : IExchangeCurrencyService
    {
        private readonly IExchangerateApi _exchangerateApi;

        public ExchangeCurrencyService(IExchangerateApi exchangerateApi)
        {
            _exchangerateApi = exchangerateApi;
        }

        public async Task<CurrencyViewModel> GetExchangeCurrency(string from, string to, decimal amount, EnumProfile profile)
        {
            var retorno = await _exchangerateApi.GetCurrencyAsync($"{from},{to}");

            var response = new CurrencyViewModel(retorno.Content.Rates[to] * amount / retorno.Content.Rates[from] );

            return response;
        }

    }
}
