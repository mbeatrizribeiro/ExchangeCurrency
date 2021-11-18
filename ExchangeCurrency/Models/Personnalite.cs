using ExchangeCurrency.Api.Models.Request;
using ExchangeCurrency.Api.Models.Response;
using MediatR;

namespace ExchangeCurrency.Api.Models
{
    public class Personnalite : CurrencyInputModel, IRequest<CurrencyViewModel>
    {
        public decimal tax = 0.8M;
        public decimal Tax
        {
            get { return tax; }
        }
    }
}

