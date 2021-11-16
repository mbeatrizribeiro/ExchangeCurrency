using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExchangeCurrency.Api.Models.Request
{
    public class CurrencyRequest
    {
        [Required]
        [JsonPropertyName("from")]
        public string FromCurrency { get; set; }

        [Required]
        [JsonPropertyName("to")]
        public string ToCurrency { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public decimal TaxProfilePersonnalite { get; set; }

        public decimal TaxProfileVarejo { get; set; }

        public decimal TaxProfilePrivate { get; set; }

    }
}
