using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeCurrency.Domain.Models
{
    public class ExchangeCurrencyResponse
    {
        [JsonProperty("inquerir")]
        public Inquerir Inquerir { get; set; }

        [JsonProperty("histórico")]
        public string Histórico { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("resultado")]
        public int Resultado { get; set; }
    }

    public class Inquerir
    {
        [JsonProperty("de")]
        public string De { get; set; }

        [JsonProperty("para")]
        public string Para { get; set; }

        [JsonProperty("quantidade")]
        public int Quantidade { get; set; }
    }

    public class Info
    {
        [JsonProperty("timestamp")]
        public int Timestamp { get; set; }

        [JsonProperty("taxa")]
        public int Taxa { get; set; }
    }
}
