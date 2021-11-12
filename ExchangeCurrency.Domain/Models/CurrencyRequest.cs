using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeCurrency.Domain.Models
{
    public class CurrencyRequest
    {
        [Required]
        [JsonProperty("from")]
        public string FromCurrency { get; set; }

        [Required]
        [JsonProperty("to")]
        public string ToCurrency { get; set; }

        [Required]
        [JsonProperty("amount")]
        public double Amount { get; set; }

        public double TaxProfilePersonnalite { get; set; }

        public double TaxProfileVarejo { get; set; }

        public double TaxProfilePrivate { get; set; }

    }
}
