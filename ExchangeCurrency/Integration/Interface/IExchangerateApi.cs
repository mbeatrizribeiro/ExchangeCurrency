using ExchangeCurrency.Api.Models.Request;
using ExchangeCurrency.Api.Models.Response;
using Refit;
using System.Threading.Tasks;

namespace ExchangeCurrency.Api.Integration.Interface
{
    public interface IExchangerateApi
    {
        [Get("/v1/latest")]
        Task<ApiResponse<CurrencyResponse>> GetCurrencyAsync([Query]string symbols, [Query]string access_key = "916da8ce87cb9a72cd9a6552acf6d79d");
    }


}
