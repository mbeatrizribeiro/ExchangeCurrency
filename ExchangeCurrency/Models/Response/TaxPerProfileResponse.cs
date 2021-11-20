using ExchangeCurrency.Api.Models.Enums;
using System.ComponentModel;

namespace ExchangeCurrency.Api.Models.Response
{
    public class TaxPerProfileResponse
    {
        [DisplayName("Taxa Personnalite")]
        public decimal PersonnaliteTax { get; set; }

        [DisplayName("Taxa Varejo")]
        public decimal VarejoTax { get; set; }

        [DisplayName("Taxa Private")]
        public decimal PrivateTax { get; set; }
        
        public EnumProfile Profile { get; set; }
    }
}
