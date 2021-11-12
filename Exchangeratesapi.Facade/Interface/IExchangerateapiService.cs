using ExchangeCurrency.Domain.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeCurrency.Domain.Services.Interfaces
{
    public interface IExchangerateapiService
    {
        [Get("/v1/latest?access_key=2285beb4739b3158103cf3c04a543870")]
        Task<CurrencyResponse> GetCurrencyAsync(object json);
    }


}
