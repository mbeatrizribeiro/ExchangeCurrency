using ExchangeCurrency.Api.Models.Request;
using ExchangeCurrency.Api.Models.Response;

namespace ExchangeCurrency.Api.Service.Interface
{
    public interface ITaxPerProfileService
    {
        decimal SetTax(ProfileRequest request);
        decimal GetTax(TaxPerProfileResponse request);
    }
}
