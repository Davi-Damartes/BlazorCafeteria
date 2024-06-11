using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Api.Controllers.PagamentoController;
using LojaSonhoDeCafe.Api.Repositories.Pagamento;
using LojaSonhoDeCafe.Api.Repositories.Produtos;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LojaSonhoDeCafe.Test.PagamentoTest.PagamentoControllerTest.PagamentoGetTest
{
    public class PagamentoControllerGet
    {
        private readonly IPagamentoRepositoryApi _pagamentoRepository;
        public PagamentoControllerGet( )
        {
            _pagamentoRepository = A.Fake<IPagamentoRepositoryApi>();
        }

        [Fact]
        public async Task PagamentoController_BuscarTodosPagamentos_ReturnOk_E_IEnumerablePagamentoDto( )
        {
            // Arrange
            var pagamentoDto = A.Fake<IEnumerable<PagamentoDiario>>();

            A.CallTo(( ) => _pagamentoRepository.BucarTodosOsPagamentos())
                .Returns(Task.FromResult( pagamentoDto));

            var pagamentoController = new PagamentoController(_pagamentoRepository); 
            // Act
            var result = await pagamentoController.BuscarTodosPagamentos();

            // Assert
            result.Should().NotBeNull();       
            var actionResult = Assert.IsType<ActionResult<IEnumerable<PagamentoDiarioDto>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            okResult.StatusCode.Should().Be(200);
        } 

         [Fact]
        public async Task PagamentoController_BuscarTodosPagamentos_ReturnException( )
        {
            // Arrange
            var pagamentoDto = A.Fake<IEnumerable<PagamentoDiario>>();

            A.CallTo(( ) => _pagamentoRepository.BucarTodosOsPagamentos())
                .Throws(new Exception());

            var pagamentoController = new PagamentoController(_pagamentoRepository); 
            // Act
            var result = await pagamentoController.BuscarTodosPagamentos();

            // Assert
            result.Should().NotBeNull();       
            var actionResult = Assert.IsType<ActionResult<IEnumerable<PagamentoDiarioDto>>>(result);
            var okResult = Assert.IsType<ObjectResult>(actionResult.Result);
            okResult.Value.Should().Be("Erro ao acessar a base de dados");
            okResult.StatusCode.Should().Be(500);
        } 


        [Fact]
        public async Task PagamentoController_BuscarTodosPagamentosProdutos_ReturnPagamentoProduto200()
        {
            // Arrange
            var pagamentoProduto = A.Fake<IEnumerable<PagamentoProduto>>();

            A.CallTo(( ) => _pagamentoRepository.BucarTodosOsPagamentosDeProdutos())
                .Returns(Task.FromResult(pagamentoProduto));

            var pagamentoController = new PagamentoController(_pagamentoRepository); 
            // Act
            var result = await pagamentoController.BuscarTodosPagamentosProdutos();

            // Assert
            result.Should().NotBeNull();       
            var actionResult = Assert.IsType<ActionResult<IEnumerable<PagamentoProduto>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            okResult.StatusCode.Should().Be(200);
        }
        
        [Fact]
        public async Task PagamentoController_BuscarPagamentoPorId_ReturnPagamentoDiarioOk200()
        {
            // Arrange
            var Id = Guid.NewGuid();
            var pagamentoProduto = A.Fake<PagamentoDiario>();

            A.CallTo(( ) => _pagamentoRepository.BucarPagamentoPorId(Id))
                .Returns(Task.FromResult(pagamentoProduto));

            var pagamentoController = new PagamentoController(_pagamentoRepository); 
            // Act
            var result = await pagamentoController.BuscarPagamentoPorId(Id);

            // Assert
            result.Should().NotBeNull();       
            var actionResult = Assert.IsType<ActionResult<PagamentoDiarioDto>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            okResult.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task PagamentoController_BuscarPagamentoPorId_ReturnException( )
        {
            // Arrange
            var Id = Guid.NewGuid();
            var pagamentoDto = A.Fake<IEnumerable<PagamentoDiario>>();

            A.CallTo(( ) => _pagamentoRepository.BucarPagamentoPorId(Id))
                .Throws(new Exception());

            var pagamentoController = new PagamentoController(_pagamentoRepository);
            // Act
            var result = await pagamentoController.BuscarPagamentoPorId(Id);

            // Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<ActionResult<PagamentoDiarioDto>>(result);
            var okResult = Assert.IsType<ObjectResult>(actionResult.Result);
            okResult.Value.Should().Be("Erro ao acessar a base de dados");
            okResult.StatusCode.Should().Be(500);
        }


        [Fact]
        public async Task PagamentoController_BuscarPagamentoPeloMes_ReturnIEnumerablePagamentoDiarioDtoOk200( )
        {
            // Arrange
            int mes = 1;
            var pagamentoProduto = A.Fake<IEnumerable<PagamentoDiario>>();

            A.CallTo(( ) => _pagamentoRepository.BucarTodosPagamentosPeloMes(mes))
                .Returns(Task.FromResult(pagamentoProduto));

            var pagamentoController = new PagamentoController(_pagamentoRepository); 
            // Act
            var result = await pagamentoController.BuscarPagamentoPeloMes(mes);

            // Assert
            result.Should().NotBeNull();       
            var actionResult = Assert.IsType<ActionResult<IEnumerable<PagamentoDiarioDto>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            okResult.StatusCode.Should().Be(200);
        }
        
        [Fact]
        public async Task PagamentoController_BuscarPagamentoPeloMes_ReturnBadRequest400( )
        {
            // Arrange
            int mes = 13;
            int mes2 = 0;
            var pagamentoProduto = A.Fake<IEnumerable<PagamentoDiario>>();

            A.CallTo(( ) => _pagamentoRepository.BucarTodosPagamentosPeloMes(mes))
                .Returns(Task.FromResult(pagamentoProduto));

            var pagamentoController = new PagamentoController(_pagamentoRepository); 
            // Act
            var result = await pagamentoController.BuscarPagamentoPeloMes(mes);
            var result2 = await pagamentoController.BuscarPagamentoPeloMes(mes2);

            // Assert
            result.Should().NotBeNull();       
            var actionResult = Assert.IsType<ActionResult<IEnumerable<PagamentoDiarioDto>>>(result);
            var okResult = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            okResult.Value.Should().BeEquivalentTo("Mês inválido");
            okResult.StatusCode.Should().Be(400);
            
            result2.Should().NotBeNull();       
            var actionResult2 = Assert.IsType<ActionResult<IEnumerable<PagamentoDiarioDto>>>(result2);
            var okResult2 = Assert.IsType<BadRequestObjectResult>(actionResult.Result);
            okResult2.Value.Should().BeEquivalentTo("Mês inválido");
            okResult2.StatusCode.Should().Be(400);
        }
    }
}
