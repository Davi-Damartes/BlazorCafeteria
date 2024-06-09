using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Api.Controllers.ProdutoControllers;
using LojaSonhoDeCafe.Api.Repositories.Produtos;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace LojaSonhoDeCafe.Test.ProdutoTest.ProdutoControllerTest.ProdutoGetTest
{
    public class ProdutoControllerPutTest
    {
        private readonly IProdutoRepositoryApi _produtoRepository;

        public ProdutoControllerPutTest()
        {
            _produtoRepository = A.Fake<IProdutoRepositoryApi>();
        }

        [Fact]
        public async Task ProdutosController_ObterProdutoPorId_ReturnOk()
        {
            //Arrange
            var produto = new Produto
            {
                Nome = "Cafeteira Expresso",
                Descricao = "Uma cafeteira moderna que prepara um café delicioso em poucos minutos.",
                FotoUrl = "https://example.com/cafe.jpg",
                Preco = 299.99m,
                QuantidadeEmEstoque = 50,
                IsFavorito = true,
                CategoriaId = 1, // ID da categoria
                Categoria = new Categoria { Id = 1, Nome = "Eletrodomésticos" },
            };

            A.CallTo(() => _produtoRepository.ObterProdutoPorId(produto.Id))
                .Returns(Task.FromResult(produto));

            var contoller = new ProdutosController(_produtoRepository);

            //Act
            var result = await contoller.ObterProdutoId(produto.Id);


            //Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<ActionResult<ProdutoDto>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);

            okResult.Value.Should().NotBeNull();
            

        }

        [Fact]
        public async Task ProdutosController_ObterProdutoPorId_ReturnNotFound()
        {
            // Arrange
            var produtoId = Guid.Empty;

            // Simular o repositório retornando null quando o produto não é encontrado
            A.CallTo(() => _produtoRepository.ObterProdutoPorId(produtoId))
                .Returns(Task.FromResult<Produto>(null!));

            var controller = new ProdutosController(_produtoRepository);

            // Act
            var result = await controller.ObterProdutoId(produtoId);

            // Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<ActionResult<ProdutoDto>>(result);
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(actionResult.Result);
            notFoundResult.Value.Should().BeEquivalentTo("Produto não encontrado!");
            notFoundResult.StatusCode.Should().Be(404);

        }

        [Fact]
        public async Task ProdutosController_ObterTodosProdutos_ReturnOk200()
        {
            //Arrange
            var produtos = A.Fake<IEnumerable<Produto>>();

            var produtosDto = A.Fake<IEnumerable<ProdutoDto>>();

            A.CallTo(() => _produtoRepository.ObterTodosOsProdutos())
            .Returns(Task.FromResult(produtos));

            var contoller = new ProdutosController(_produtoRepository);

            //Act
            var result = await contoller.ObterTodosItens();


            //Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<ActionResult<IEnumerable<ProdutoDto>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            okResult.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task ProdutosController_ObterTodosOsItens_ReturnNotFound()
        {
            //Arrange
            var produtosDto = A.Fake<IEnumerable<ProdutoDto>>();

            A.CallTo(() => _produtoRepository.ObterTodosOsProdutos())
            .Returns(Task.FromResult<IEnumerable<Produto>>(null!));

            var contoller = new ProdutosController(_produtoRepository);

            //Act
            var result = await contoller.ObterTodosItens();


            //Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<ActionResult<IEnumerable<ProdutoDto>>>(result);
            var okResult = Assert.IsType<NotFoundObjectResult>(actionResult.Result);
            okResult.StatusCode.Should().Be(404);
        }
    }
}
