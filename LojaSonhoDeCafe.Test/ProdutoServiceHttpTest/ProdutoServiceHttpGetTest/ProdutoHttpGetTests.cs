using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.ServicesHttp.ProdutosHttpService;
using Microsoft.Extensions.Logging;
using System.Net;

namespace LojaSonhoDeCafe.Test.ProdutoServiceHttpTest.ProdutoServiceHttpGetTest
{
    public class ProdutoHttpGetTests
    {

        private readonly Fixture _fixture = new();
        private readonly ILogger<ProdutoHttpService> _logger;

        public ProdutoHttpGetTests( )
        {
            _logger = A.Fake<ILogger<ProdutoHttpService>>();
        }

        [Fact]
        public async Task ServiceHttpClient_ObterProdutoPorId_ReturnUmProduto( )
        {
            var generateId = _fixture.Create<Guid>();

            var produtoEsperados = _fixture.Create<ProdutoDto>();

            var handler = new HandlerHttp(HttpStatusCode.OK, produtoEsperados);

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://www.example.com")

            };
            var produtoClient = new ProdutoHttpService(client, _logger);

            var produtoAtual = await produtoClient.ObterUmProduto(generateId);

            produtoAtual.Should().BeEquivalentTo(produtoEsperados);

        }

        [Fact]
        public async Task ServiceHttpClient_ObterProdutos_ReturnUmProduto( )
        {
            var produtoEsperados = _fixture.CreateMany<ProdutoDto>();

            var handler = new HandlerHttp(HttpStatusCode.OK, produtoEsperados);

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://www.example.com")

            };
            var produtoClient = new ProdutoHttpService(client, _logger);

            var produtoAtual = await produtoClient.ObterProdutos();

            produtoAtual.Should().BeEquivalentTo(produtoEsperados);

        }
    }
}
