using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Api.Controllers.ProdutoControllers;
using LojaSonhoDeCafe.Api.Repositories.Produtos;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LojaSonhoDeCafe.Test.ProdutoTest.ProdutoControllerTest.ProdutoPostTest
{
    public class ProdutoControllerPostTest
    {

        private readonly IProdutoRepositoryApi _produtoRepository;

        public ProdutoControllerPostTest()
        {
            _produtoRepository = A.Fake<IProdutoRepositoryApi>();
        }


        [Fact]
        public async Task ProdutosController_CrirNovoProduto_ReturnCreated()
        {
            //Arrange

            var produtoDto = new ProdutoDto { Id = Guid.NewGuid(), Nome = "Novo Produto" };

            A.CallTo(() => _produtoRepository.ObterProdutoPorId(produtoDto.Id))
                            .Returns(Task.FromResult<Produto>(null!));

            var controller = new ProdutosController(_produtoRepository);

            //Act
            var result = await controller.CriarNovoProduto(produtoDto);

            //Assert
            result.Should().NotBeNull();

            var actionResult = Assert.IsType<ActionResult<ProdutoDto>>(result);
            var createdResult = Assert.IsType<CreatedResult>(actionResult.Result);
            var resultValeue = Assert.IsType<ProdutoDto>(createdResult.Value);
        }

        [Fact]
        public async Task ProdutosController_CrirNovoProduto_ReturnConflict()
        {
            //Arrange

            var produto = A.Fake<Produto>();
            var produtoDto = A.Fake<ProdutoDto>();

            A.CallTo(() => _produtoRepository.ObterProdutoPorId(produtoDto.Id))
                            .Returns(Task.FromResult(produto));

            var controller = new ProdutosController(_produtoRepository);

            //Act
            var result = await controller.CriarNovoProduto(produtoDto);

            //Assert
            result.Should().NotBeNull();

            var actionResult = Assert.IsType<ActionResult<ProdutoDto>>(result);
            var createdResult = Assert.IsType<ConflictObjectResult>(actionResult.Result);
            createdResult.Value.Should().Be("Produto já existe!");
        }

        [Fact]
        public async Task ProdutosController_CrirNovoProduto_ReturnInternalServerError()
        {
            //Arrange

            var produto = A.Fake<Produto>();
            var produtoDto = A.Fake<ProdutoDto>();

            A.CallTo(() => _produtoRepository.ObterProdutoPorId(produtoDto.Id))
                                              .Throws<Exception>();

            var controller = new ProdutosController(_produtoRepository);

            //Act
            var result = await controller.CriarNovoProduto(produtoDto);

            //Assert
            result.Should().NotBeNull();

            var actionResult = Assert.IsType<ObjectResult>(result.Result);
            actionResult.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);
            actionResult.Value.Should().Be("Erro ao acessar a base de dados");
        }
    }
}
