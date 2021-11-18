namespace ExchangeCurrency.Api.Models.Request
{
    public class Private : CurrencyInputModel
    {
        public decimal tax = 0.9M;

        public Private()
        {
        }

        public decimal Tax
        {
            get { return tax; }
        }
    }
}
