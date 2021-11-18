using ExchangeCurrency.Api.Integration.Interface;
using ExchangeCurrency.Api.Models;
using ExchangeCurrency.Api.Models.Interface;
using ExchangeCurrency.Api.Models.Response;
using NSubstitute;
using Xunit;

namespace ExchangeCurrency.Tests
{
    public class ExchangeCurrencyServiceTest
    {
        private readonly IExchangeCurrencyService _exchangeCurrencyService;
        private readonly IExchangerateApi _exchangerateApi;

        [Fact]
        public void DadoUmaSolicitacaoConversaoSemParametros_QuandoConverterMoeda_EntaoVerificarMoedasConversao()
        {
            //Arrange
            const string symbols = "USD,BRL";
            
            var exchangeRateApi = Substitute.For<IExchangerateApi>();

            //Act

            //Assert
            exchangeRateApi.DidNotReceive().GetCurrencyAsync(Arg.Any<string>());
        }

        //public void DadoUmaSolicitacaoConversaoVarejo_QuandoConverterMoedaPerfilVarejo_EntaoRetornarValorDeConversaoComTaxas() 
        //{
        //    //Arrange
        //    var varejo = new Varejo() { };

        //    IExchangerateApi api = Substitute.For<IExchangerateApi>();

        //    IExchangeCurrencyService service = Substitute.For<IExchangeCurrencyService>();

        //    api.GetCurrencyAsync(Arg.Any<string>()).Returns<CurrencyViewModel>;

        //    //Act

        //    //Assert
        //}
    }
}
