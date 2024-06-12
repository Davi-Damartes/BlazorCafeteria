using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Api.Controllers.PagamentoController;
using LojaSonhoDeCafe.Api.Repositories.Pagamento;
using LojaSonhoDeCafe.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace LojaSonhoDeCafe.Test.PagamentoTest.PagamentoControllerTest.PagamentoPostTest
{
    public class PagamentoControllerPost
    {
        private readonly IPagamentoRepositoryApi _pagamentoRepositoryApi;
        public PagamentoControllerPost()
        {
            _pagamentoRepositoryApi = A.Fake<IPagamentoRepositoryApi>();
        }

        [Fact]
        public async Task RealizarPagamento_DeveRetornarOk200_QuandoPagamento_ForRealizado( )
        {
            // Arrange
            var pagamentoDiario = A.Fake<PagamentoDiarioDto>();
            bool booleano = true;

            A.CallTo(()=> _pagamentoRepositoryApi.AdicionarPagamento(pagamentoDiario))
                .Returns(Task.FromResult(booleano));

            var pagamentoController = new PagamentoController(_pagamentoRepositoryApi);

            // Act
            var result = await pagamentoController.RealizarPagamento(pagamentoDiario);

            // Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<ActionResult<bool>>(result);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            okResult.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task RealizarPagamento_DeveRetornarBadRequest400_QuandoPagamento_NAOForRealizado()
        {
            // Arrange
            var listaPagamentosProduto = A.Fake<List<PagamentoProdutoDto>>();
            var HoraTeste = new DateTime(2024, 06, 11, 07, 59, 59);
            var pagamentoDiario = new PagamentoDiarioDto
            {
                Usuario = "UsuarioTeste",
                Email = "email@teste.com",
                TotalQuantDiaria = 10,
                TotalPrecoDiaria = 123.45m,
                EPagamento = EPagamentoDto.Dinheiro,
                HoraDoPagamento = HoraTeste,
                ProdutosDoPagamento = listaPagamentosProduto
            };


            A.CallTo(()=> _pagamentoRepositoryApi.AdicionarPagamento(pagamentoDiario))
                .Returns(Task.FromResult(false));

            var pagamentoController = new PagamentoController(_pagamentoRepositoryApi);

            // Act
            var result = await pagamentoController.RealizarPagamento(pagamentoDiario);

            // Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<ActionResult<bool>>(result);
            var okResult = Assert.IsType<BadRequestObjectResult>(result.Result);
            okResult.Value.Should().Be("Erro ao realizar Pagamento");
            okResult.StatusCode.Should().Be(400);
        }
        
        [Fact]
        public async Task RealizarPagamento_DeveRetornarBadRequest400_QuandoPagamento_ForaDoHorarioComercial( )
        {
            // Arrange
            var listaPagamentosProduto = A.Fake<List<PagamentoProdutoDto>>();

            var horaAntes07 = new DateTime(2024, 06, 11, 06, 59, 59);
            var pagamentoDiarioAntes07H = new PagamentoDiarioDto
            {
                Usuario = "UsuarioTeste",
                Email = "email@teste.com",
                TotalQuantDiaria = 10,
                TotalPrecoDiaria = 123.45m,
                EPagamento = EPagamentoDto.Dinheiro,
                HoraDoPagamento = horaAntes07,
                ProdutosDoPagamento = listaPagamentosProduto
            };

            var horaDepois22 = new DateTime(2024, 06, 11, 22, 00, 01);
            var pagamentoDiarioDepois22H = new PagamentoDiarioDto
            {
                Usuario = "UsuarioTeste",
                Email = "email@teste.com",
                TotalQuantDiaria = 10,
                TotalPrecoDiaria = 123.45m,
                EPagamento = EPagamentoDto.Dinheiro,
                HoraDoPagamento = horaDepois22,
                ProdutosDoPagamento = listaPagamentosProduto
            };


            A.CallTo(()=> _pagamentoRepositoryApi.AdicionarPagamento(pagamentoDiarioAntes07H))
                .Returns(Task.FromResult(true));

            A.CallTo(()=> _pagamentoRepositoryApi.AdicionarPagamento(pagamentoDiarioDepois22H))
                .Returns(Task.FromResult(true));

            var pagamentoController = new PagamentoController(_pagamentoRepositoryApi);

            // Act
            var resultadoAnterior07 = await pagamentoController.RealizarPagamento(pagamentoDiarioAntes07H);
            var resultadoDepois22 = await pagamentoController.RealizarPagamento(pagamentoDiarioDepois22H);

            // Assert

            // Teste para Antes das 07.
            resultadoAnterior07.Should().NotBeNull();
            var actionResult = Assert.IsType<ActionResult<bool>>(resultadoAnterior07);
            var okResult = Assert.IsType<BadRequestObjectResult>(resultadoAnterior07.Result);
            okResult.Value.Should().Be("A loja está fechada. O pagamento não pôde ser processado.");
            okResult.StatusCode.Should().Be(400);


            // Teste para Depois das 22.
            resultadoDepois22.Should().NotBeNull();
            var actionResult22 = Assert.IsType<ActionResult<bool>>(resultadoDepois22);
            var okResult22 = Assert.IsType<BadRequestObjectResult>(resultadoDepois22.Result);
            okResult22.Value.Should().Be("A loja está fechada. O pagamento não pôde ser processado.");
            okResult22.StatusCode.Should().Be(400);
        }
        
        [Fact]
        public async Task PagamentoController_RealizarPagamento_DeveRetornarException500( )
        {
            // Arrange
            var listaPagamentosProduto = A.Fake<List<PagamentoProdutoDto>>();

            var horaAntes07 = new DateTime(2024, 06, 11, 06, 59, 59);
            var pagamentoDiario = new PagamentoDiarioDto
            {
                Usuario = "UsuarioTeste",
                Email = "email@teste.com",
                TotalQuantDiaria = 10,
                TotalPrecoDiaria = 123.45m,
                EPagamento = EPagamentoDto.Dinheiro,
                HoraDoPagamento = horaAntes07,
                ProdutosDoPagamento = listaPagamentosProduto
            };

            A.CallTo(()=> _pagamentoRepositoryApi.AdicionarPagamento(pagamentoDiario))
                .Throws(new Exception());


            var pagamentoController = new PagamentoController(_pagamentoRepositoryApi);

            // Act
            var result = await pagamentoController.RealizarPagamento(pagamentoDiario);

            // Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<ActionResult<bool>>(result);
            var okResult = Assert.IsType<ObjectResult>(result.Result);
            okResult.Value.Should().Be("Erro ao acessar a base de dados");
            okResult.StatusCode.Should().Be(500);
        }

    }
}
