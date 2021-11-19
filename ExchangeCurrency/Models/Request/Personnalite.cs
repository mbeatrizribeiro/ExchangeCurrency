namespace ExchangeCurrency.Api.Models.Request
{
    public class Personnalite : ExchangeCurrencyRequest
    {
        public decimal tax = 0.8M;

        public Personnalite()
        {
        }

        public decimal Tax
        {
            get { return tax; }
        }
    }
}

