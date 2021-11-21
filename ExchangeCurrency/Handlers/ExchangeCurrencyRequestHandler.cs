using ExchangeCurrency.Api.Integration.Interface;
using System.Threading.Tasks;
using ExchangeCurrency.Api.Models.Response;
using ExchangeCurrency.Api.Models.Request;
using MediatR;
using System.Threading;
using ExchangeCurrency.Api.Handlers.Interface;
using ExchangeCurrency.Api.Service.Interface;

namespace ExchangeCurrency.Api.Handlers
{
    public class ExchangeCurrencyRequestHandler : IExchangeCurrencyRequestHandler, IRequestHandler<ExchangeCurrencyRequest, CurrencyViewModel>
    {
        private readonly IExchangerateApi _exchangerateApi;
        private readonly ITaxPerProfileService _taxPerProfileService;

        public ExchangeCurrencyRequestHandler(IExchangerateApi exchangerateApi, ITaxPerProfileService taxPerProfileService)
        {
            _exchangerateApi = exchangerateApi;
            _taxPerProfileService = taxPerProfileService;
        }


        public async Task<CurrencyViewModel> Handle(ExchangeCurrencyRequest request, CancellationToken cancellationToken)
        {
            var retorno = await _exchangerateApi.GetCurrencyAsync($"{request.FromCurrency},{request.ToCurrency}");

            TaxPerProfileResponse valorTaxa = new TaxPerProfileResponse()
            {
               Profile = request.Profile
            };

            var taxaProfile = _taxPerProfileService.GetTax(valorTaxa);
                

            var calculo = retorno.Content.Rates[request.FromCurrency] * request.Amount / retorno.Content.Rates[request.ToCurrency];

            var calculoItau = calculo * (1 + taxaProfile);

            var valor = decimal.Round(calculoItau, 2);

            return new CurrencyViewModel(valor);
        }

    }
}
