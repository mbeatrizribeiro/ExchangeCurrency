using ExchangeCurrency.Api.Models.Enums;
using ExchangeCurrency.Api.Models.Request;
using ExchangeCurrency.Api.Models.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeCurrency.Api.Models
{
    public class Varejo : CurrencyInputModel, IRequest<CurrencyViewModel>
    {
        public decimal tax = 0.5M;
        public decimal Tax
        {
            get { return tax; }
        }
    }
}
