using ExchangeCurrency.Api.Integration.Interface;
using System.Threading.Tasks;
using ExchangeCurrency.Api.Models.Response;
using MediatR;
using System.Threading;
using ExchangeCurrency.Api.Models.Interface;

namespace ExchangeCurrency.Api.Models
{
    public class ExchangeCurrencyService : IExchangeCurrencyService, IRequestHandler<Varejo, CurrencyViewModel>
    {
        private readonly IExchangerateApi _exchangerateApi;

        public ExchangeCurrencyService(IExchangerateApi exchangerateApi)
        {
            _exchangerateApi = exchangerateApi;
        }

        public async Task<CurrencyViewModel> Handle(Varejo request, CancellationToken cancellationToken)
        {
            var retorno = await _exchangerateApi.GetCurrencyAsync($"{request.FromCurrency},{request.ToCurrency}");

            var calculo = retorno.Content.Rates[request.FromCurrency] * request.Amount / retorno.Content.Rates[request.ToCurrency];

            var response = new CurrencyViewModel(calculo + (calculo * request.tax));

            return response;
        }

        public async Task<CurrencyViewModel> Handle(Personnalite request, CancellationToken cancellationToken)
        {
            var retorno = await _exchangerateApi.GetCurrencyAsync($"{request.FromCurrency},{request.ToCurrency}");

            var calculo = retorno.Content.Rates[request.FromCurrency] * request.Amount / retorno.Content.Rates[request.ToCurrency];

            var response = new CurrencyViewModel(calculo + (calculo * request.tax));

            return response;
        }

        public async Task<CurrencyViewModel> Handle(Private request, CancellationToken cancellationToken)
        {
            var retorno = await _exchangerateApi.GetCurrencyAsync($"{request.FromCurrency},{request.ToCurrency}");

            var calculo = retorno.Content.Rates[request.FromCurrency] * request.Amount / retorno.Content.Rates[request.ToCurrency];

            var response = new CurrencyViewModel(calculo + (calculo * request.tax));

            return response;
        }

    }
}
