using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.ServicesHttp.CarrinhoComprasHttpService;
using Microsoft.Extensions.Logging;
using System.Net;

namespace LojaSonhoDeCafe.Test.CarrinhoCompraTest.CarrinhoServiceHttpTest.CarrinhoServiceHttpPostTest
{
    public class CarrinhoHttpPostTest
    {
        private readonly Fixture _fixture = new();
        private readonly ILogger<CarrinhoCompraHttpService> _logger;

        public CarrinhoHttpPostTest( )
        {
            _logger = A.Fake<ILogger<CarrinhoCompraHttpService>>();
        }

        [Fact]
        public async Task CarrinhoServiceHttp_AdicionaItemCarrinhoDto_ReturnCarrinhoItemDto( )
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
            var result = await carrinhoService.AdicionaItemCarrinhoDto(CarrinhoItem);

            // Assert
            result.Should().NotBeNull(); 
            Assert.IsType<CarrinhoItemDto>(result);
            result.CarrinhoId.Should().Be(CarrinhoItem.CarrinhoId);

        }
    }
}
