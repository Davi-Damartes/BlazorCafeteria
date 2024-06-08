using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.ServicesHttp.ProdutosHttpService;
using Microsoft.Extensions.Logging;
using System.Net;

namespace LojaSonhoDeCafe.Test.ProdutoServiceHttpTest.ProdutoServiceHttpPostTest
{
    public class ProdutoHttpPostTests
    {

        private readonly Fixture _fixture = new();
        private readonly ILogger<ProdutoHttpService> _logger;

        public ProdutoHttpPostTests( )
        {
            _logger = A.Fake<ILogger<ProdutoHttpService>>();
        }

        [Fact]
        public async Task ServiceHttpClient_AdicionarProduto_ReturnUmProduto( )
        {
            var produto = _fixture.Create<ProdutoDto>();

            var handler = new HandlerHttp(HttpStatusCode.OK, produto);

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://www.example.com")

            };
            var produtoClient = new ProdutoHttpService(client, _logger);

            var produtoAtual = await produtoClient.AdicionarNovoProduto(produto);

            var produtoId = await produtoClient.ObterUmProduto(produto.Id);

            produtoAtual.Should().BeEquivalentTo(produto);

            produtoAtual.Should().BeEquivalentTo(produtoId);

        }
    }
}
