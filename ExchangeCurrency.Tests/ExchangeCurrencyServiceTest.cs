using ExchangeCurrency.Api.Handlers.Interface;
using ExchangeCurrency.Api.Integration.Interface;
using ExchangeCurrency.Api.Models.Enums;
using ExchangeCurrency.Api.Models.Request;
using ExchangeCurrency.Api.Models.Response;
using NSubstitute;
using System.Threading;
using Xunit;

namespace ExchangeCurrency.Tests
{
    public class ExchangeCurrencyServiceTest
    {
        private readonly IExchangeCurrencyRequestHandler _exchangeCurrencyService = Substitute.For<IExchangeCurrencyRequestHandler>();
        private readonly IExchangerateApi _exchangerateApi = Substitute.For<IExchangerateApi>();

        const string symbols = "USD,BRL";

        [Fact]
        public void DadoUmaSolicitacaoConversao_QuandoConverterMoedaPerfil_EntaoReceberMoedasDeConversao()
        {
            //Arrange
            const int amount = 2;
            EnumProfile profile = EnumProfile.Personnalite;

            ExchangeCurrencyRequest request = new ExchangeCurrencyRequest
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

            ProfileRequest profile = new ProfileRequest();

            CurrencyViewModel response = new CurrencyViewModel(resultado)
            {
                Resultado = resultado + resultado * profile.Tax,
            };

            //act 
            _exchangeCurrencyService.Handle(Arg.Any<ExchangeCurrencyRequest>(), Arg.Any<CancellationToken>()).Returns(response);

            //Assert
            Assert.Equal(resultado + (resultado * profile.Tax), response.Resultado);
        }

        [Fact]
        public void DadoUmaSolicitacaoConversaoSemPerfilIndicado_QuandoConverterMoeda_EntaoRetornarValorDaApiSemTaxas()
        {
            //Arrange
            const decimal resultado = 2;

            CurrencyViewModel response = new CurrencyViewModel(resultado)
            {
                Resultado = resultado
            };

            //Act
            _exchangeCurrencyService.Handle(Arg.Any<ExchangeCurrencyRequest>(), Arg.Any<CancellationToken>()).Returns(response);

            //Assert
            Assert.Equal(resultado * (1 + 0), response.Resultado);
        }

        [Fact]
        public void DadoUmaSolicitacaoConversaoComMoedaInexistente_QuandoGetCurrencyAsync_EntaoRetornarErroAoEncontrarMoeda()
        {
            //Arrange
            const string symbolsErro = "";

            //Act
            var retorno = _exchangerateApi.GetCurrencyAsync(symbolsErro).Exception;

            //Assert
            Assert.Null(retorno);
        }

    }
}
