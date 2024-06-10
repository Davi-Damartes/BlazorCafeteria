using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.ServicesHttp.CarrinhoComprasHttpService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;

namespace LojaSonhoDeCafe.Test.CarrinhoCompraTest.CarrinhoServiceHttpTest.CarrinhoServiceHttpGetTest
{
    public class CarrinhoHttpGetTests
    {

        private readonly Fixture _fixture = new();
        private readonly ILogger<CarrinhoCompraHttpService> _logger;

        public CarrinhoHttpGetTests( )
        {
            _logger = A.Fake<ILogger<CarrinhoCompraHttpService>>();
        }

        [Fact]
        public async Task CarrinhoServiceHttp_ObterItensCarrinho_ReturnListCarrinhoItemDto()
        {
            //Arrange
            string usuarioId = "1";
            var listaProdutoDto = _fixture.CreateMany<Task<List<CarrinhoItemDto>>>();

            var handlerClient = new HandlerHttp(HttpStatusCode.OK, listaProdutoDto);

            var client = new HttpClient(handlerClient) 
            {
                BaseAddress = new Uri("https://www.example.com")
            };
            var carrinhoService = new CarrinhoCompraHttpService(client, _logger);

            //Act
            var result = await carrinhoService.ObterItensCarrinho(usuarioId);

            //Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(3);
            Assert.IsType<List<CarrinhoItemDto>>(result);
        }
      
    }
}
