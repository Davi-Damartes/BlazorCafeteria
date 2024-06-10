using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.ServicesHttp.ProdutosHttpService;
using Microsoft.Extensions.Logging;
using System.Net;

namespace LojaSonhoDeCafe.Test.ProdutoTest.ProdutoServiceHttpTest.ProdutoServiceHttpGetTest
{
    public class ProdutoHttpGetTests
    {

        private readonly Fixture _fixture = new();
        private readonly ILogger<ProdutoHttpService> _logger;

        public ProdutoHttpGetTests()
        {
            _logger = A.Fake<ILogger<ProdutoHttpService>>();
        }

        [Fact]
        public async Task ServiceHttpClient_ObterProdutoPorId_DeveReturnarUmProduto()
        {
            //Arrange
            var generateId = _fixture.Create<Guid>();

            var produtoEsperados = _fixture.Create<ProdutoDto>();

            var handler = new HandlerHttp(HttpStatusCode.OK, produtoEsperados);

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://www.example.com")
            };
            var produtoClient = new ProdutoHttpService(client, _logger);

            //Act
            var produtoAtual = await produtoClient.ObterUmProduto(generateId);

            //Assert
            produtoAtual.Should().NotBeNull();
            produtoAtual.Should().BeOfType<ProdutoDto>();
            produtoAtual.Should().BeEquivalentTo(produtoEsperados);
        }

        [Fact]
        public async Task ServiceHttpClient_ObterProdutosFavoritos_DeveReturnarProdutoFavoritos()
        {
            // Arrange
            var ProdutosFavoritosEsperados = _fixture.CreateMany<ProdutoDto>();
            var handler = new HandlerHttp(HttpStatusCode.OK, ProdutosFavoritosEsperados);
            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://www.example.com")
            };
            var produtoClient = new ProdutoHttpService(client, _logger);

            // Act
            var produtosFavoritos = await produtoClient.ObterProdutosFavoritos();

            // Assert
            produtosFavoritos.Should().NotBeNull();
            Assert.Equal(2, produtosFavoritos.Count());
            foreach (var produto in produtosFavoritos)
            {
                Assert.True(produto.IsFavorito);
            }
        }



        [Fact]
        public async Task ServiceHttpClient_ObterProdutos_DeveReturnarIEnumerableProdutos()
        {
            // Arrange
            var produtosEsperados = _fixture.CreateMany<ProdutoDto>();
            var handler = new HandlerHttp(HttpStatusCode.OK, produtosEsperados);
            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://www.example.com")
            };
            var produtoClient = new ProdutoHttpService(client, _logger);

            // Act
            var produtosAtuais = await produtoClient.ObterProdutos();

            // Assert
            produtosAtuais.Should().BeEquivalentTo(produtosEsperados);
            produtosAtuais.Should().NotBeNull();
            produtosAtuais.Count().Should().Be(3);
        }

        [Fact]
        public async Task ServiceHttpClient_BuscarCategorias_ReturnIEnumerableCategorias()
        {
            // Arrange
            var categoriaEsperadas = _fixture.CreateMany<CategoriaDto>();
            var handler = new HandlerHttp(HttpStatusCode.OK, categoriaEsperadas);
            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://www.example.com")
            };
            var produtoClient = new ProdutoHttpService(client, _logger);

            // Act
            var CategoriasAtuais = await produtoClient.BuscaCategorias();

            // Assert
            Assert.Equal(3, CategoriasAtuais.Count());
            Assert.IsAssignableFrom<IEnumerable<CategoriaDto>>(CategoriasAtuais);
            CategoriasAtuais.Should().BeEquivalentTo(categoriaEsperadas);
            CategoriasAtuais.Should().NotBeNull();
            CategoriasAtuais.Count().Should().Be(3);
        }

    }
}
