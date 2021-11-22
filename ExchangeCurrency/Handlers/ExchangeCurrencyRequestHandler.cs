using ExchangeCurrency.Api.Integration.Interface;
using System.Threading.Tasks;
using ExchangeCurrency.Api.Models.Response;
using ExchangeCurrency.Api.Models.Request;
using MediatR;
using System.Threading;
using ExchangeCurrency.Api.Handlers.Interface;

namespace ExchangeCurrency.Api.Handlers
{
    public class ExchangeCurrencyRequestHandler : IExchangeCurrencyRequestHandler, IRequestHandler<ExchangeCurrencyRequest, CurrencyViewModel>
    {
        private readonly IExchangerateApi _exchangerateApi;

        public ExchangeCurrencyRequestHandler(IExchangerateApi exchangerateApi)
        {
            _exchangerateApi = exchangerateApi;
        }


        public async Task<CurrencyViewModel> Handle(ExchangeCurrencyRequest request, CancellationToken cancellationToken)
        {
            var retorno = await _exchangerateApi.GetCurrencyAsync($"{request.FromCurrency},{request.ToCurrency}");

            var calculo = retorno.Content.Rates[request.FromCurrency] * request.Amount / retorno.Content.Rates[request.ToCurrency];

            ProfileRequest profile = new ProfileRequest()
            {
                Profile = request.Profile,
                Tax = request.Tax
            };

            decimal calculoItau = calculo * (1 + profile.Tax);

            return new CurrencyViewModel(decimal.Round(calculoItau, 2));
        }

    }
}
