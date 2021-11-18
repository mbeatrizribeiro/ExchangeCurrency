using ExchangeCurrency.Api.Models.Request;
using ExchangeCurrency.Api.Models.Response;
using MediatR;

namespace ExchangeCurrency.Api.Models
{
    public class Private : CurrencyInputModel, IRequest<CurrencyViewModel>
    {
        public decimal tax = 0.9M;
        public decimal Tax
        {
            get { return tax; }
        }
    }
}
