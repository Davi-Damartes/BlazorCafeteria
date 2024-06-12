using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.ServicesHttp.PagamentoHttpService;
using Microsoft.Extensions.Logging;
using System.Net;

namespace LojaSonhoDeCafe.Test.PagamentoTest.PagamentoServiceHttpTest.PagamentoServiceHttpPostTest
{
    public class PagamentoHttpPostTest
    {
        private readonly Fixture _fixture = new();
        private readonly ILogger<PagamentoHttpService> _logger;

        public PagamentoHttpPostTest( )
        {
            _logger = A.Fake<ILogger<PagamentoHttpService>>();
        }

        [Fact]
        public async Task ObterTodosPagamentosPorMes_DeveRetornar_True( )
        {
            // Arrange
            bool valorEsperado = true;
            
            var pagamentoDiarioDto = _fixture.Create<PagamentoDiarioDto>();
            var handler = new HandlerSimularHttpCall(HttpStatusCode.OK, valorEsperado);

            pagamentoDiarioDto.HoraDoPagamento = new DateTime(2024,06,12, 15, 30, 00);

            var pagamentoClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://www.example.com")
            };

            var pagamentoService = new PagamentoHttpService(pagamentoClient, _logger);

            // Act
            var resultado = await pagamentoService.AdicionarPagamento(pagamentoDiarioDto);
            
            // Assert
            resultado.Should().BeTrue();
            Assert.IsType<bool>(resultado);

        }  
        
        [Fact]
        public async Task ObterTodosPagamentosPorMes_DataInvalidas_DeveRetornar_False( )
        {
            // Arrange
            bool valorEsperado = false;
            
            var pagamentoDiarioDto = _fixture.Create<PagamentoDiarioDto>();
            pagamentoDiarioDto.HoraDoPagamento = new DateTime(2024, 06, 12, 06, 59, 59);


            var pagamentoDiarioDto2 = _fixture.Create<PagamentoDiarioDto>();
            pagamentoDiarioDto2.HoraDoPagamento = new DateTime(2024, 06, 12, 22, 00, 01);

            var handler = new HandlerSimularHttpCall(HttpStatusCode.OK, valorEsperado);

            var pagamentoClient = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://www.example.com")
            };

            var pagamentoService = new PagamentoHttpService(pagamentoClient, _logger);

            // Act
            var resultadoAntes7 = await pagamentoService.AdicionarPagamento(pagamentoDiarioDto);

            var resultadoDepois22 = await pagamentoService.AdicionarPagamento(pagamentoDiarioDto2);

            // Assert
            resultadoAntes7.Should().BeFalse();
            Assert.IsType<bool>(resultadoAntes7);

            resultadoDepois22.Should().BeFalse();
            Assert.IsType<bool>(resultadoDepois22);

        }
        

    }
}
