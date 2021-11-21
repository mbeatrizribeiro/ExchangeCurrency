using ExchangeCurrency.Api.Models.Response;
using ExchangeCurrency.Api.Models.Request;
using ExchangeCurrency.Api.Models.Enums;
using System;
using ExchangeCurrency.Api.Service.Interface;

namespace ExchangeCurrency.Api.Service
{
    public class TaxPerProfileService : ITaxPerProfileService
    {
        public TaxPerProfileService()
        {
        }

        public decimal SetTax(ProfileRequest request)
        {
            TaxPerProfileResponse response = new TaxPerProfileResponse();

            if (request.Profile == EnumProfile.Varejo)
            {
                response.VarejoTax = request.Tax;
                return response.VarejoTax;
            }

            else if (request.Profile == EnumProfile.Private)
            {
                response.PrivateTax = request.Tax;
                return response.PrivateTax;
            }

            else if (request.Profile == EnumProfile.Personnalite)
            {
                response.PersonnaliteTax = request.Tax;
                return response.PersonnaliteTax;
            }

            throw new Exception("Profile não encontrado");
        }

        public decimal GetTax(TaxPerProfileResponse request)
        {
            if (request.Profile == EnumProfile.Personnalite)
            {
                return request.PersonnaliteTax;
            }

            else if (request.Profile == EnumProfile.Private)
            {
                return request.PrivateTax;
            }
            if (request.Profile == EnumProfile.Varejo)
            {
                return request.VarejoTax;
            }

            throw new Exception("Profile não encontrado");
        }
    }
}
