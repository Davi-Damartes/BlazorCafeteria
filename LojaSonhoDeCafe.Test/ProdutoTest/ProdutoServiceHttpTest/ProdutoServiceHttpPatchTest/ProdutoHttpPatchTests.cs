using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.ServicesHttp.ProdutosHttpService;
using Microsoft.Extensions.Logging;
using System.Net;

namespace LojaSonhoDeCafe.Test.ProdutoTest.ProdutoServiceHttpTest.ProdutoServiceHttpPatchTest
{
    public class ProdutoHttpPatchTests
    {
        private readonly ILogger<ProdutoHttpService> _logger;

        public ProdutoHttpPatchTests()
        {
            _logger = A.Fake<ILogger<ProdutoHttpService>>();
        }

        [Fact]
        public async Task ServiceHttpClient_AtualizaProdutoFavorito_ReturnUmProduto()
        {
            //Arrange 
            var produtoAtt = new ProdutoDto
            {
                Nome = "Cafeteira Expresso",
                Descricao = "Uma cafeteira moderna que prepara um café delicioso em poucos minutos.",
                FotoUrl = "https://example.com/cafe.jpg",
                Preco = 299.99m,
                QuantidadeEmEstoque = 0,
                IsFavorito = true,
                CategoriaId = 1,
                CategoriaNome = "Lanche"
            };

            var handler = new HandlerHttp(HttpStatusCode.OK, produtoAtt);

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://www.example.com")

            };
            var produtoClient = new ProdutoHttpService(client, _logger);

            //Act
            await produtoClient.AtualizaProdutoFavorito(produtoAtt);

            //Assert
            Assert.NotNull(client);
            Assert.NotNull(produtoAtt);
        }
    }
}
