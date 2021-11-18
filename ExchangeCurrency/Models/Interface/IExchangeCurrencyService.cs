using ExchangeCurrency.Api.Models.Request;
using ExchangeCurrency.Api.Models.Response;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeCurrency.Api.Models.Interface
{
    public interface IExchangeCurrencyService 
    {

        Task<CurrencyViewModel> Handle(CurrencyInputModel request, CancellationToken cancellationToken);

    }


}
