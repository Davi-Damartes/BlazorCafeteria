using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;
using LojaSonhoDeCafe.ServicesHttp.ProdutosHttpService;
using Microsoft.Extensions.Logging;
using System.Net;

namespace LojaSonhoDeCafe.Test.ProdutoServiceHttpTest.ProdutoServiceHttpPutTest
{
    public class ProdutoHttpPutTests
    {

        private readonly Fixture _fixture = new();
        private readonly ILogger<ProdutoHttpService> _logger;

        public ProdutoHttpPutTests()
        {
            _logger = A.Fake<ILogger<ProdutoHttpService>>();
        }

        [Fact]
        public async Task ServiceHttpClient_ObterProdutoPorId_ReturnUmProduto( )
        {
            //Arrange 
            var generateId = _fixture.Create<Guid>();

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

            int quantidade = 25;
            var handler = new HandlerHttp(HttpStatusCode.OK, produtoAtt);

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://www.example.com")

            };
            var produtoClient = new ProdutoHttpService(client, _logger);
            

            //Act
            await produtoClient.AtualizaProdutoFavorito(produtoAtt);

            //Assert

        }
    }
}
