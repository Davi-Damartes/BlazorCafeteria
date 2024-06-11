using AutoFixture;
using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Api.Controllers.CarrinhoController;
using LojaSonhoDeCafe.Api.Repositories.Carrinho;
using LojaSonhoDeCafe.Api.Repositories.Produtos;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace LojaSonhoDeCafe.Test.CarrinhoCompraTest.CarrinhoControllerTest.CarrinhoGetTest
{
    public class CarrinhoControllerGetTest
    {

        private readonly ICarrinhoCompraRepositoryApi _carrinhoRepository;
        private readonly IProdutoRepositoryApi _produtoRepository;

        public CarrinhoControllerGetTest( )
        {
            _carrinhoRepository = A.Fake<ICarrinhoCompraRepositoryApi>();
            _produtoRepository = A.Fake<IProdutoRepositoryApi>();
        }

        [Fact]
        public async Task CarrinhoController_ObterItensCarrinhoDoUsuario_ReturnOK200( )
        {
            // Arrange
            string usuarioId = "1";

            var carrinhosItens = A.Fake<IEnumerable<CarrinhoItem>>();

            var produtosLista = A.Fake<IEnumerable<Produto>>();

            A.CallTo(( ) => _carrinhoRepository.ObtemItensDoCarinho(usuarioId))
                .Returns(Task.FromResult(carrinhosItens));

            A.CallTo(( ) => _produtoRepository.ObterTodosOsProdutos())
               .Returns(Task.FromResult(produtosLista));

            var carrinhoController = new CarrinhoController(_carrinhoRepository, _produtoRepository);

            // Act
            var result = await carrinhoController.ObterItensCarrinhoDoUsuario(usuarioId);

            // Assert
            Assert.NotNull(result);
            var actionResult = Assert.IsType<ActionResult<IEnumerable<CarrinhoItemDto>>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            okResult.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task CarrinhoController_ObterItensCarrinhoDoUsuario_ReturnNotFound404( )
        {
            // Arrange
            string usuarioId = "1";

            var carrinhosItens = A.Fake<IEnumerable<CarrinhoItem>>();

            var produtosLista = A.Fake<IEnumerable<Produto>>();

            A.CallTo(( ) => _carrinhoRepository.ObtemItensDoCarinho(usuarioId))
                .Returns(Task.FromResult<IEnumerable<CarrinhoItem>>(null!));

            A.CallTo(( ) => _produtoRepository.ObterTodosOsProdutos())
               .Returns(Task.FromResult(produtosLista));

            var carrinhoController = new CarrinhoController(_carrinhoRepository, _produtoRepository);

            // Act
            var result = await carrinhoController.ObterItensCarrinhoDoUsuario(usuarioId);

            // Assert

            Assert.NotNull(result);
            var actionResult = Assert.IsType<ActionResult<IEnumerable<CarrinhoItemDto>>>(result);
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(actionResult.Result);
            notFoundResult.Value.Should().BeEquivalentTo("Itens do Carrinho não encontrados!");
            notFoundResult.StatusCode.Should().Be(404);
        }


        [Fact]
        public async Task CarrinhoController_ObterItemCarrinhoIdo_ReturnOK200( )
        {
            // Arrange
            int Id = 1;

            var produtoId = Guid.NewGuid();

            var carrinhoItem = A.Fake<CarrinhoItem>();

            var produto = A.Fake<Produto>();

            A.CallTo(( ) => _carrinhoRepository.ObtemItemDoCarrinhoPorId(Id))
                .Returns(Task.FromResult(carrinhoItem));

            A.CallTo(( ) => _produtoRepository.ObterProdutoPorId(produtoId))
               .Returns(Task.FromResult(produto));

            var carrinhoController = new CarrinhoController(_carrinhoRepository, _produtoRepository);

            // Act
            var result = await carrinhoController.ObterItemCarrinhoId(Id);

            // Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<ActionResult<CarrinhoItemDto>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            okResult.StatusCode.Should().Be(200);
        }

    }
}
