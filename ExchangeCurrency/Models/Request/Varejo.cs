﻿namespace ExchangeCurrency.Api.Models.Request
{
    public class Varejo : CurrencyInputModel
    {

        public Varejo()
        {
        }

        public decimal tax = 0.5M;
        public decimal Tax
        {
            get { return tax; }
        }

    }
}