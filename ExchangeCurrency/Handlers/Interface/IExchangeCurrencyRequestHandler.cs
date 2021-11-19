using ExchangeCurrency.Api.Models.Request;
using ExchangeCurrency.Api.Models.Response;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeCurrency.Api.Handlers.Interface
{
    public interface IExchangeCurrencyRequestHandler
    {

        Task<CurrencyViewModel> Handle(ExchangeCurrencyRequest request, CancellationToken cancellationToken);

    }


}
