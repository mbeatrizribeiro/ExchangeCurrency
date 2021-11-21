using ExchangeCurrency.Api.Models.Enums;
using ExchangeCurrency.Api.Models.Response;
using MediatR;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ExchangeCurrency.Api.Models.Request
{
    public class ExchangeCurrencyRequest : IRequest<CurrencyViewModel>
    {
        [Required]
        [DisplayName("De")]
        public string FromCurrency { get; set; }

        [Required]
        [DisplayName("Para")]
        public string ToCurrency { get; set; }

        [Required]
        [DisplayName("Quantidade")]
        public decimal Amount { get; set; }

        public EnumProfile Profile { get; set; }

    }

 }
