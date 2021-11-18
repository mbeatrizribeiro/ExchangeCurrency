using ExchangeCurrency.Api.Integration.Interface;
using System.Threading.Tasks;
using ExchangeCurrency.Api.Models.Response;
using ExchangeCurrency.Api.Models.Request;
using MediatR;
using System.Threading;
using ExchangeCurrency.Api.Models.Interface;
using ExchangeCurrency.Api.Models.Enums;
using System;

namespace ExchangeCurrency.Api.Models.Handlers
{
    public class ExchangeCurrencyService : IExchangeCurrencyService, IRequestHandler<CurrencyInputModel, CurrencyViewModel>
    {
        private readonly IExchangerateApi _exchangerateApi;

        public ExchangeCurrencyService(IExchangerateApi exchangerateApi)
        {
            _exchangerateApi = exchangerateApi;
        }


        public async Task<CurrencyViewModel> Handle(CurrencyInputModel request, CancellationToken cancellationToken)
        {
            var retorno = await _exchangerateApi.GetCurrencyAsync($"{request.FromCurrency},{request.ToCurrency}");

            var calculo = retorno.Content.Rates[request.FromCurrency] * request.Amount / retorno.Content.Rates[request.ToCurrency];

            if (request.Profile == EnumProfile.Varejo)
            {

                Varejo varejo = new Varejo()
                {
                    Amount = request.Amount,
                    FromCurrency = request.FromCurrency,
                    ToCurrency = request.ToCurrency
                };

                return new CurrencyViewModel(calculo + (calculo * varejo.tax));
            }

            else if (request.Profile == EnumProfile.Personnalite)
            {

                Personnalite personnalite = new Personnalite()
                {
                    Amount = request.Amount,
                    FromCurrency = request.FromCurrency,
                    ToCurrency = request.ToCurrency
                };

                return new CurrencyViewModel(calculo + (calculo * personnalite.tax));
            }

            else if (request.Profile == EnumProfile.Private)
            {

                Private privateProfile = new Private()
                {
                    Amount = request.Amount,
                    FromCurrency = request.FromCurrency,
                    ToCurrency = request.ToCurrency
                };

                return new CurrencyViewModel(calculo + (calculo * privateProfile.tax));
            }

            throw new Exception("Profile não encontrado");
        }

    }
}
