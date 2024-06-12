using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.ServicesHttp.CarrinhoComprasHttpService;
using Microsoft.Extensions.Logging;
using System.Net;

namespace LojaSonhoDeCafe.Test.CarrinhoCompraTest.CarrinhoServiceHttpTest.CarrinhoServiceHttpPatchTest
{
    public class CarrinhoHttpPatchTest
    {
        private readonly Fixture _fixture = new();
        private readonly ILogger<CarrinhoCompraHttpService> _logger;

        public CarrinhoHttpPatchTest( )
        {
            _logger = A.Fake<ILogger<CarrinhoCompraHttpService>>();
        }

        [Fact]
        public async Task CarrinhoHttpPatchTest_AtualizarQuantidade_ReturnCarrinhoItemDto( )
        {
            // Arrange
            int Id = 1;
            var CarrinhoItem = _fixture.Create<CarrinhoItemAtualizaQuantidadeDto>();

            var handlerClient = new HandlerSimularHttpCall(HttpStatusCode.OK, CarrinhoItem);

            var client = new HttpClient(handlerClient)
            {
                BaseAddress = new Uri("https://www.example.com")
            };
            var carrinhoService = new CarrinhoCompraHttpService(client, _logger);

            // Act
            var result = await carrinhoService.AtualizarQuantidade(Id, CarrinhoItem);

            // Assert
            result.Should().NotBeNull();
            Assert.IsType<CarrinhoItemDto>(result);
            result.Quantidade.Should().Be(CarrinhoItem.Quantidade);
        }
    }
}
