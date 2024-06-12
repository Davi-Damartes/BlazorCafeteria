using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.ServicesHttp.CarrinhoComprasHttpService;
using Microsoft.Extensions.Logging;
using System.Net;

namespace LojaSonhoDeCafe.Test.CarrinhoCompraTest.CarrinhoServiceHttpTest.CarrinhoServiceHttpDeleteTest
{
    public class CarrinhoHttpDeleteTest
    {

        private readonly Fixture _fixture = new();
        private readonly ILogger<CarrinhoCompraHttpService> _logger;

        public CarrinhoHttpDeleteTest( )
        {
            _logger = A.Fake<ILogger<CarrinhoCompraHttpService>>();
        }

        [Fact]
        public async Task CarrinhoServiceHttp_DeletaItemDoCarrinho_ReturnCarrinhoItemDto()
        {
            // Arrange
            int Id = 1;
            var CarrinhoItem = _fixture.Create<CarrinhoItemAdicionaDto>();

            var handlerClient = new HandlerSimularHttpCall(HttpStatusCode.OK, CarrinhoItem);

            var client = new HttpClient(handlerClient)
            {
                BaseAddress = new Uri("https://www.example.com")
            };
            var carrinhoService = new CarrinhoCompraHttpService(client, _logger);

            // Act
            var result = await carrinhoService.DeletaItemDoCarrinho(Id);

            // Assert
            result.Should().NotBeNull();
            Assert.IsType<CarrinhoItemDto>(result);
        }
        
        [Fact]
        public async Task CarrinhoServiceHttp_LimpaItensDoCarrinho_ReturnCarrinhoItemDto()
        {
            // Arrange
            var CarrinhoItem = _fixture.Create<CarrinhoItemAdicionaDto>();

            var handlerClient = new HandlerSimularHttpCall(HttpStatusCode.OK, CarrinhoItem);

            var client = new HttpClient(handlerClient)
            {
                BaseAddress = new Uri("https://www.example.com")
            };
            var carrinhoService = new CarrinhoCompraHttpService(client, _logger);

            // Act
            await carrinhoService.LimpaItensCarrinhoDeCompra();

            // Assert
            CarrinhoItem.Should().NotBeNull();
            client.BaseAddress.Should().Be("https://www.example.com");
            carrinhoService.Should().NotBeNull();
        }

    }
}
