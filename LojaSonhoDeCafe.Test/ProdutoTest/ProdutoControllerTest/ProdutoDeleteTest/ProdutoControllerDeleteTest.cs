using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Api.Controllers.ProdutoControllers;
using LojaSonhoDeCafe.Api.Repositories.Produtos;
using LojaSonhoDeCafe.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace LojaSonhoDeCafe.Test.ProdutoTest.ProdutoControllerTest.ProdutoDeleteTest
{
    public class CarrinhoControllerDeleteTest
    {
        private readonly IProdutoRepositoryApi _produtoRepository;

        public CarrinhoControllerDeleteTest()
        {
            _produtoRepository = A.Fake<IProdutoRepositoryApi>();
        }

        [Fact]
        public async Task ProdutosController_DeletarProduto_DeveRetornarOk()
        {
            //Arragne
            var produto = A.Fake<Produto>();
            var produtoId = Guid.NewGuid();

            A.CallTo(() => _produtoRepository.ObterProdutoPorId(produtoId))
                .Returns(Task.FromResult(produto));

            var controller = new ProdutosController(_produtoRepository);


            //Act
            var result = await controller.DeletarProduto(produtoId);


            //Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<OkObjectResult>(result);
            actionResult.Value.Should().Be("Produto Excluído com sucesso!");
        }

        [Fact]
        public async Task ProdutosController_DeletarProduto_DeveRetornarNotFound()
        {
            //Arragne
            var produto = A.Fake<Produto>();
            var produtoId = Guid.NewGuid();

            A.CallTo(() => _produtoRepository.ObterProdutoPorId(produtoId))
                .Returns(Task.FromResult(produto));

            var controller = new ProdutosController(_produtoRepository);


            //Act
            var result = await controller.DeletarProduto(produtoId);


            //Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<OkObjectResult>(result);
            actionResult.Value.Should().Be("Produto Excluído com sucesso!");

        }
    }
}
