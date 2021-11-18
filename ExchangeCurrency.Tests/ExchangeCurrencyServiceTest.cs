using ExchangeCurrency.Api.Integration.Interface;
using ExchangeCurrency.Api.Models.Enums;
using ExchangeCurrency.Api.Models.Interface;
using ExchangeCurrency.Api.Models.Request;
using ExchangeCurrency.Api.Models.Response;
using NSubstitute;
using System.Threading;
using Xunit;

namespace ExchangeCurrency.Tests
{
    public class ExchangeCurrencyServiceTest
    {
        private readonly IExchangeCurrencyService _exchangeCurrencyService = Substitute.For<IExchangeCurrencyService>();
        private readonly IExchangerateApi _exchangerateApi = Substitute.For<IExchangerateApi>();

        const string symbols = "USD,BRL";

        [Fact]
        public void DadoUmaSolicitacaoConversao_QuandoConverterMoedaPerfil_EntaoReceberMoedasDeConversao()
        {
            //Arrange
            const int amount = 2;
            EnumProfile profile = EnumProfile.Personnalite;

            CurrencyInputModel request = new CurrencyInputModel
            {
                Amount = amount,
                Profile = profile
            };

            //act 
            _exchangerateApi.GetCurrencyAsync(symbols);

            //Assert
            Assert.Equal(request.FromCurrency, request.ToCurrency);
        }

        [Fact]
        public void DadoUmaSolicitacaoConversaoComPerfilIndicado_QuandoConverterMoeda_EntaoRetornarConversaoMoedasComTaxa()
        {
            //Arrange
            const decimal resultado = 2;
            Personnalite profile = new Personnalite();

            CurrencyViewModel response = new CurrencyViewModel(resultado)
            {
                Resultado = resultado + resultado * profile.Tax,
            };

            //act 
            _exchangeCurrencyService.Handle(Arg.Any<CurrencyInputModel>(), Arg.Any<CancellationToken>()).Returns(response);

            //Assert
            Assert.Equal(resultado + (resultado * profile.Tax), response.Resultado);
        }
    }
}
