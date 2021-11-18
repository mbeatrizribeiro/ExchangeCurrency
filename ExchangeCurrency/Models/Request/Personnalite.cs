namespace ExchangeCurrency.Api.Models.Request
{
    public class Personnalite : CurrencyInputModel
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

