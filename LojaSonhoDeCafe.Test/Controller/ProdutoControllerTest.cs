using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Api.Controllers.ProdutoControllers;
using LojaSonhoDeCafe.Api.Repositories.Produtos;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace LojaSonhoDeCafe.Test.Controller
{
    public class ProdutoControllerTest
    {
        private readonly IProdutoRepositoryApi _produtoRepository;

        public ProdutoControllerTest( )
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
                var produtoDto = A.Fake<ProdutoDto>();

            A.CallTo(() => _produtoRepository.ObterProdutoPorId(produto.Id))
                .Returns(Task.FromResult(produto));

            var contoller = new ProdutosController(_produtoRepository);

            //Act
            var result = await contoller.ObterProdutoPorId(produto.Id);


            //Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<ActionResult<ProdutoDto>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);

            okResult.Value.Should().NotBeNull();;

        }

        [Fact]
        public async Task ProdutosController_ObterTodosProdutos_ReturnOk()
        {
            //Arrange
            var produtos = A.Fake<IEnumerable<Produto>>();

            var produtosDto = A.Fake<IEnumerable<ProdutoDto>>();

            A.CallTo(( ) => _produtoRepository.ObterTodosOsProdutos())
            .Returns(Task.FromResult(produtos));

            var contoller = new ProdutosController(_produtoRepository);

            //Act
            var result = await contoller.ObterTodosItens();


            //Assert
            result.Should().NotBeNull();
        }

        [Fact]
        public async Task ProdutosController_ObterTodosItens_DeveReturnOk()
        {
            //Arrange
            var produtos = A.Fake<IEnumerable<Produto>>();

            var produtosDto = A.Fake<IEnumerable<ProdutoDto>>();

            A.CallTo(() => _produtoRepository.ObterTodosOsProdutos())
            .Returns(Task.FromResult(produtos));

            var controller = new ProdutosController(_produtoRepository);
            //Act
            var result = await controller.ObterTodosItens();

            var createdResult = result.Result as CreatedAtActionResult;

            //Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<ActionResult<IEnumerable<ProdutoDto>>>(result);
            Assert.IsType<OkObjectResult>(actionResult.Result);

        }


        [Fact]
        public async Task ProdutosController_CrirNovoProduto_ReturnCreated( )
        {
            //Arrange
            var produto = A.Fake<Produto>();
            var produtoDto2 = A.Fake<ProdutoDto>();

            A.CallTo(( ) => _produtoRepository.ObterProdutoPorId(produtoDto2.Id))
                                     .Returns(Task.FromResult<Produto>(null!));

            A.CallTo(( ) => _produtoRepository.AdicionarNovoProduto(produto))
                                     .Returns(Task.FromResult(produto));

            var controller = new ProdutosController(_produtoRepository);

            //Act
            var result = await controller.CriarNovoProduto(produtoDto2);

            //Assert
            result.Should().NotBeNull();

            var actionResult = Assert.IsType<ActionResult<ProdutoDto>>(result);
            var createdAtActionResult = Assert.IsType<CreatedResult>(actionResult.Result);
            Assert.Equal(201, createdAtActionResult.StatusCode);
        }

    }
}
