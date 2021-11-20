using ExchangeCurrency.Api.Models.Enums;

namespace ExchangeCurrency.Api.Models.Request
{
    public class ProfileRequest 
    {
        public decimal Tax { get; set; }

        public EnumProfile Profile { get; set; }
    }
}
