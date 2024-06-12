using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.ServicesHttp.ProdutosHttpService;
using Microsoft.Extensions.Logging;
using System.Net;

namespace LojaSonhoDeCafe.Test.ProdutoTest.ProdutoServiceHttpTest.ProdutoServiceHttpPostTest
{
    public class ProdutoHttpPostTests
    {
        private readonly Fixture _fixture = new();
        private readonly ILogger<ProdutoHttpService> _logger;

        public ProdutoHttpPostTests()
        {
            _logger = A.Fake<ILogger<ProdutoHttpService>>();
        }

        [Fact]
        public async Task ServiceHttpClient_AdicionarProduto_ReturnUmProduto()
        {
            // Arrange
            var produtoDto = _fixture.Create<ProdutoDto>();

            var handler = new HandlerSimularHttpCall(HttpStatusCode.OK, produtoDto);

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://www.example.com")

            };
            var produtoClient = new ProdutoHttpService(client, _logger);

            // Act
            var produtoAtual = await produtoClient.AdicionarNovoProduto(produtoDto);


            // Assert
            Assert.Equal(produtoDto.Nome, produtoAtual.Nome);
            produtoAtual.Should().BeOfType<ProdutoDto>();
            produtoAtual.Should().NotBeNull();
            produtoAtual.Should().BeEquivalentTo(produtoDto);

        }

        [Fact]
        public async Task ServiceHttpClient_AdicionarEstoqueAoProduto_ReturnTrue()
        {
            // Arrange
            var produtoDto = _fixture.Create<ProdutoDto>();
            int quantidade = 10;
            var handler = new HandlerSimularHttpCall(HttpStatusCode.OK, produtoDto);

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://www.example.com")

            };
            var produtoClient = new ProdutoHttpService(client, _logger);

            // Act
            await produtoClient.AdicionarEstoqueAoProduto(produtoDto.Id, quantidade);


            // Assert
            Assert.True(true);

        }

        [Fact]
        public async Task ServiceHttpClient_AtualizaProdutoFavorito_ReturnTrue()
        {
            // Arrange
            var produtoDto = _fixture.Create<ProdutoDto>();

            var handler = new HandlerSimularHttpCall(HttpStatusCode.OK, produtoDto);

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://www.example.com")

            };
            var produtoClient = new ProdutoHttpService(client, _logger);

            // Act
            await produtoClient.AtualizaProdutoFavorito(produtoDto);


            // Assert
            Assert.True(true);

        }
    }
}
