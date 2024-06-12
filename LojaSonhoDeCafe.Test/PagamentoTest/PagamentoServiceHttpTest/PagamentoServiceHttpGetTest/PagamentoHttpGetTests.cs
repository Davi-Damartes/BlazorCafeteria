using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.ServicesHttp.PagamentoHttpService;

using Microsoft.Extensions.Logging;
using System.Net;

namespace LojaSonhoDeCafe.Test.PagamentoTest.PagamentoServiceHttpTest.PagamentoServiceHttpGetTest
{
    public class PagamentoHttpGetTests
    {
        private readonly Fixture _fixture = new();
        private readonly ILogger<PagamentoHttpService> _logger;

        public PagamentoHttpGetTests( )
        {
            _logger = A.Fake<ILogger<PagamentoHttpService>>();
        }

        [Fact]
        public async Task ObterTodosPagamentosPorMes_DeveRetornar_Lista_De_Pagamentos( )
        {
            // Arrange
            var PagamentosEsperados = _fixture.CreateMany<PagamentoDiarioDto>();

            int mesPagmento = 6;

            var handler = new HandlerSimularHttpCall(HttpStatusCode.OK, PagamentosEsperados);

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://www.example.com")
            };
            var pagamentoClient = new PagamentoHttpService(client, _logger);

            // Act
            var pagamentos = await pagamentoClient.ObterTodosPagamentosPorMes(mesPagmento);
            var contador = pagamentos.Count();

            // Assert
            pagamentos.Should().NotBeNull();
            pagamentos.Should().BeOfType<List<PagamentoDiarioDto>>();
            Assert.Equal(3, contador);
        }


        [Fact]
        public async Task ObterTodosPagamentosPorMes_DeveRetornar_ListaVazia_De_Pagamentos( )
        {
            // Arrange
            int mesPagmento = 6;

            var PagamentosEsperados = _fixture.CreateMany<PagamentoDiarioDto>();

            var handler = new HandlerSimularHttpCall(HttpStatusCode.NoContent, PagamentosEsperados);

            var client = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://www.example.com")
            };
            var produtoClient = new PagamentoHttpService(client, _logger);

            // Act
            var pagamentos = await produtoClient.ObterTodosPagamentosPorMes(mesPagmento);
            var contador = pagamentos.Count();

            // Assert
            pagamentos.Should().NotBeNull();
            Assert.Empty(pagamentos);
            pagamentos.Should().BeAssignableTo<IEnumerable<PagamentoDiarioDto>>();
            Assert.Equal(0, contador);

        }
    }
}
