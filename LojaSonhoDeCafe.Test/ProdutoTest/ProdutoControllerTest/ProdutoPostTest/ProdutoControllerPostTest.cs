using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Api.Controllers.ProdutoControllers;
using LojaSonhoDeCafe.Api.Repositories.Produtos;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LojaSonhoDeCafe.Test.ProdutoTest.ProdutoControllerTest.ProdutoPostTest
{
    public class CarrinhoControllerPostTest
    {

        private readonly IProdutoRepositoryApi _produtoRepository;

        public CarrinhoControllerPostTest()
        {
            _produtoRepository = A.Fake<IProdutoRepositoryApi>();
        }


        [Fact]
        public async Task ProdutosController_CrirNovoProduto_ReturnCreated201()
        {
            // Arrange

            var produtoDto = new ProdutoDto { Id = Guid.NewGuid(), Nome = "Novo Produto" };

            A.CallTo(() => _produtoRepository.ObterProdutoPorId(produtoDto.Id))
                            .Returns(Task.FromResult<Produto>(null!));

            var controller = new ProdutosController(_produtoRepository);

            // Act
            var result = await controller.CriarNovoProduto(produtoDto);

            // Assert
            result.Should().NotBeNull();

            var actionResult = Assert.IsType<ActionResult<ProdutoDto>>(result);
            var createdResult = Assert.IsType<CreatedResult>(actionResult.Result);
            createdResult.StatusCode.Should().Be(201);
            Assert.IsType<ProdutoDto>(createdResult.Value);
        }

        [Fact]
        public async Task ProdutosController_CrirNovoProduto_ReturnConflict409()
        {
            // Arrange

            var produto = A.Fake<Produto>();
            var produtoDto = A.Fake<ProdutoDto>();

            A.CallTo(() => _produtoRepository.ObterProdutoPorId(produtoDto.Id))
                            .Returns(Task.FromResult(produto));

            var controller = new ProdutosController(_produtoRepository);

            // Act
            var result = await controller.CriarNovoProduto(produtoDto);

            // Assert
            result.Should().NotBeNull();

            var actionResult = Assert.IsType<ActionResult<ProdutoDto>>(result);
            var createdResult = Assert.IsType<ConflictObjectResult>(actionResult.Result);
            createdResult.StatusCode.Should().Be(409);
            createdResult.Value.Should().Be("Produto já existe!");
        }

        [Fact]
        public async Task ProdutosController_CrirNovoProduto_ReturnInternalServerError500()
        {
            // Arrange

            var produto = A.Fake<Produto>();
            var produtoDto = A.Fake<ProdutoDto>();

            A.CallTo(() => _produtoRepository.ObterProdutoPorId(produtoDto.Id))
                                              .Throws<Exception>();

            var controller = new ProdutosController(_produtoRepository);

            // Act
            var result = await controller.CriarNovoProduto(produtoDto);

            // Assert
            result.Should().NotBeNull();

            var actionResult = Assert.IsType<ObjectResult>(result.Result);
            actionResult.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);
            actionResult.StatusCode.Should().Be(500);
            actionResult.Value.Should().Be("Erro ao acessar a base de dados");
        }
    }
}
