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
        private readonly IProdutoRepository2 _produtoRepository;
        public ProdutoControllerTest( )
        {
            _produtoRepository = A.Fake<IProdutoRepository2>();
        }

        [Fact]
        public async Task ProdutosController_ObterTodosProdutos_ReturnOk( )
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
        public async Task ProdutosController_CrirNovoProduto_ReturnCreated( )
        {
            //Arrange
            var produto = A.Fake<Produto>();
            var produtoDto = new ProdutoDto
            {
                Id = produto.Id, // ID existente
                Nome = "Produto Teste",
                Descricao = "Descrição Teste",
                FotoUrl = "http://exemplo.com/foto.jpg",
                Preco = 100,
                QuantidadeEmEstoque = 10,
                IsFavorito = false,
                CategoriaId = 1,
                CategoriaNome = "Lanche",
            };

            A.CallTo(( ) => _produtoRepository.ObterProdutoPorId(produtoDto.Id))
                                     .Returns(Task.FromResult<Produto>(null));

            A.CallTo(( ) => _produtoRepository.AdicionarNovoProdutoDto(produtoDto))
                                     .Returns(Task.FromResult(produto));

            var controller = new ProdutosController(_produtoRepository);

            //Act
            var result = await controller.CriarNovoProduto(produtoDto);

            //Assert
            result.Should().NotBeNull();

            var createdResult = result.Result as CreatedAtActionResult;
            createdResult!.StatusCode.Should().Be(201);
            createdResult.ActionName.Should().Be(nameof(ProdutosController.CriarNovoProduto));
            createdResult.RouteValues["id"].Should().Be(produtoDto.Id);
            createdResult.Value.Should().BeEquivalentTo(produtoDto);
        }

    }
}
