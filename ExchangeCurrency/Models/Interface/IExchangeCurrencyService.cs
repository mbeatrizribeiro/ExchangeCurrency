using ExchangeCurrency.Api.Models.Response;
using System.Threading;
using System.Threading.Tasks;

namespace ExchangeCurrency.Api.Models.Interface
{
    public interface IExchangeCurrencyService 
    {
       
        Task<CurrencyViewModel> Handle(Varejo request, CancellationToken cancellationToken);
        Task<CurrencyViewModel> Handle(Personnalite request, CancellationToken cancellationToken);
        Task<CurrencyViewModel> Handle(Private request, CancellationToken cancellationToken);

    }


}
