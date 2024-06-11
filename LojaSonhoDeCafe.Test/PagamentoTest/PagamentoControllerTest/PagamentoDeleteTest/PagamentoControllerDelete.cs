using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Api.Controllers.PagamentoController;
using LojaSonhoDeCafe.Api.Repositories.Pagamento;
using LojaSonhoDeCafe.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace LojaSonhoDeCafe.Test.PagamentoTest.PagamentoControllerTest.PagamentoDeleteTest
{
    public class PagamentoControllerDelete
    {
        private readonly IPagamentoRepositoryApi _pagamentoRepositoryApi;
        public PagamentoControllerDelete( )
        {
            _pagamentoRepositoryApi = A.Fake<IPagamentoRepositoryApi>();
        }

        [Fact]
        public async Task PagamenetoController_DeletarPagamento_ReturnOk200()
        {
            // Arrange 
            var Id = Guid.NewGuid();


            A.CallTo(( ) => _pagamentoRepositoryApi.ExcluirPagamento(Id));

            var pagamentoController = new PagamentoController(_pagamentoRepositoryApi);

            // Act
            var result = await pagamentoController.DeletarPagamento(Id);

            // Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<OkObjectResult>(result);
            actionResult.StatusCode.Should().Be(200);
            actionResult.Value.Should().Be("Pagamento deletado com sucesso");

        }
        
        [Fact]
        public async Task PagamenetoController_DeletarPagamento_ReturnNotFound404( )
        {
            // Arrange 
            var Id = Guid.NewGuid();
            var pagamentoDiario = A.Fake<PagamentoDiario>();

            A.CallTo(( ) => _pagamentoRepositoryApi.BucarPagamentoPorId(Id))
                     .Returns(Task.FromResult<PagamentoDiario>(null!));

            A.CallTo(( ) => _pagamentoRepositoryApi.ExcluirPagamento(Id));

            var pagamentoController = new PagamentoController(_pagamentoRepositoryApi);

            // Act
            var result = await pagamentoController.DeletarPagamento(Id);

            // Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<NotFoundObjectResult>(result);
            actionResult.StatusCode.Should().Be(404);
            actionResult.Value.Should().Be("Pagamento não encontrado!");

        } 
        
        [Fact]
        public async Task PagamenetoController_DeletarPagamento_ReturnException( )
        {
            // Arrange 
            var Id = Guid.NewGuid();
            var pagamentoDiario = A.Fake<PagamentoDiario>();

            A.CallTo(( ) => _pagamentoRepositoryApi.BucarPagamentoPorId(Id))
                     .Throws(new Exception());

            A.CallTo(( ) => _pagamentoRepositoryApi.ExcluirPagamento(Id));

            var pagamentoController = new PagamentoController(_pagamentoRepositoryApi);

            // Act
            var result = await pagamentoController.DeletarPagamento(Id);

            // Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<ObjectResult>(result);
            actionResult.StatusCode.Should().Be(500);
            actionResult.Value.Should().Be("Erro ao acessar a base de dados");

        }

    }
}
