using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ExchangeCurrency.Api.Models.Response
{

    public class CurrencyResponse
    {
        public bool Success { get; set; }
        public int Timestamp { get; set; }
        public string Base { get; set; }
        public string Date { get; set; }
        public Dictionary<string, decimal> Rates { get; set; }
    }

   

    public record CurrencyViewModel(decimal Resultado);
}
