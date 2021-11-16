using ExchangeCurrency.Api.Models.Enums;
using ExchangeCurrency.Api.Models.Response;
using Refit;
using System.Threading.Tasks;

namespace ExchangeCurrency.Api.Models.Interface
{
    public interface IExchangeCurrencyService
    {
       
        Task<CurrencyViewModel> GetExchangeCurrency(string from, string to, decimal amount, EnumProfile profile);

    }


}
