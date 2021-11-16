using ExchangeCurrency.Api.Models.Request;
using ExchangeCurrency.Api.Models.Response;
using System.Threading.Tasks;

namespace ExchangeCurrency.Api.Integration.Interface
{
    public interface IExchangerateapiService
    {
        Task<CurrencyResponse> GetCurrencyAsync(CurrencyRequest json);
    }
}