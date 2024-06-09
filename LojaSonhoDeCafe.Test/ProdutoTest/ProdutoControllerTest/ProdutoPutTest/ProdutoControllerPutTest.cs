using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Api.Controllers.ProdutoControllers;
using LojaSonhoDeCafe.Api.Repositories.Produtos;
using LojaSonhoDeCafe.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LojaSonhoDeCafe.Test.ProdutoTest.ProdutoControllerTest.ProdutoPutTest
{
    public class CarrinhoControllerPutTest
    {
        private readonly IProdutoRepositoryApi _produtoRepository;

        public CarrinhoControllerPutTest()
        {
            _produtoRepository = A.Fake<IProdutoRepositoryApi>();
        }


        [Fact]
        public async Task ProdutosController_AtualizarProdutoFavorito_ReturnOk()
        {
            //Arrange
            var produto = A.Fake<Produto>();


            A.CallTo(() => _produtoRepository.ObterProdutoPorId(produto.Id))
            .Returns(Task.FromResult(produto));


            A.CallTo(() => _produtoRepository.AtualizaProdutoFavorito(produto))
            .Returns(Task.FromResult(produto));

            var controler = new ProdutosController(_produtoRepository);
            //Act
            var result = await controler.AtualizarProdutoFavoritoPorId(produto.Id);

            //Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<OkObjectResult>(result);
            actionResult.Value.Should().Be("Produto Atualizado com Sucesso!");

        }

        [Fact]
        public async Task ProdutosController_AtualizarProdutoFavorito_ReturnNotFound()
        {
            //Arrange
            var produto = A.Fake<Produto>();

            A.CallTo(() => _produtoRepository.ObterProdutoPorId(produto.Id))
            .Returns(Task.FromResult<Produto>(null!));


            A.CallTo(() => _produtoRepository.AtualizaProdutoFavorito(produto))
            .Returns(Task.FromResult(produto));

            var controler = new ProdutosController(_produtoRepository);
            //Act
            var result = await controler.AtualizarProdutoFavoritoPorId(produto.Id);

            //Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<NotFoundObjectResult>(result);
            actionResult.Value.Should().Be("Produto não encontrado!");

        }

        [Fact]
        public async Task ProdutosController_AdicionarEstoqueAoProduto_ReturnOk()
        {
            //Arrange
            var produto = A.Fake<Produto>();
            int quantidade = 10;

            A.CallTo(() => _produtoRepository.ObterProdutoPorId(produto.Id))
                .Returns(Task.FromResult(produto));

            A.CallTo(() => _produtoRepository.AdicionarEstoqueAoProduto(produto.Id, quantidade))
              .Returns(Task.FromResult(produto));


            var controller = new ProdutosController(_produtoRepository);

            //Act
            var result = await controller.AdicionarEstoqueAoProduto(produto.Id, quantidade);


            //Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<OkObjectResult>(result);
            actionResult.Value.Should().Be("Produto Reabastecido com sucesso!");


        }

        [Fact]
        public async Task ProdutosController_AdicionarEstoque_QuantidadesInvalidas_ReturnBadRequest()
        {
            //Arrange
            var produto = A.Fake<Produto>();

            int quantidade = 81;
            int quantidade2 = 0;

            A.CallTo(() => _produtoRepository.ObterProdutoPorId(produto.Id))
                .Returns(Task.FromResult(produto));

            A.CallTo(() => _produtoRepository.AdicionarEstoqueAoProduto(produto.Id, quantidade))
              .Returns(Task.FromResult(produto));


            var controller = new ProdutosController(_produtoRepository);

            //Act
            var result = await controller.AdicionarEstoqueAoProduto(produto.Id, quantidade);
            var result2 = await controller.AdicionarEstoqueAoProduto(produto.Id, quantidade2);

            //Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
            actionResult.Value.Should().Be("Quantidade Inválida");

            result2.Should().NotBeNull();
            var actionResult2 = Assert.IsType<BadRequestObjectResult>(result);
            actionResult.Value.Should().Be("Quantidade Inválida");

        }


        [Fact]
        public async Task ProdutosController_AdicionarEstoque_DeveRetornarInternalServerError()
        {
            //Arrange
            var produtoId = Guid.NewGuid();
            int quantidade = 10;

            A.CallTo(() => _produtoRepository.ObterProdutoPorId(produtoId))
                .Throws<Exception>();


            var controller = new ProdutosController(_produtoRepository);

            //Act
            var result = await controller.AdicionarEstoqueAoProduto(produtoId, quantidade);

            //Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<ObjectResult>(result);
            actionResult.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);
            actionResult.Value.Should().Be("Erro ao acessar a base de dados");

        }

    }
}
