using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Api.Controllers.CarrinhoController;
using LojaSonhoDeCafe.Api.Repositories.Carrinho;
using LojaSonhoDeCafe.Api.Repositories.Produtos;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaSonhoDeCafe.Test.CarrinhoCompraTest.CarrinhoControllerTest.CarrinhoDeleteTest
{
    public class CarrinhoControllerDeleteTest
    {
        private readonly ICarrinhoCompraRepositoryApi _carrinhoRepository;
        private readonly IProdutoRepositoryApi _produtoRepository;
        public CarrinhoControllerDeleteTest( )
        {
            _carrinhoRepository = A.Fake<ICarrinhoCompraRepositoryApi>();
            _produtoRepository = A.Fake<IProdutoRepositoryApi>();
        }

        [Fact]
        public async Task CarrinhoController_DeletarItemCarrinho_ReturnOK200()
        {
            //Arrange
            int IdCarrinho = 1;
            var carrinhoItem = A.Fake<CarrinhoItem>();
            var produto = A.Fake<Produto>();

            A.CallTo(( ) => _carrinhoRepository.DeletaItem(IdCarrinho))
                            .Returns(Task.FromResult(carrinhoItem));

            A.CallTo(( ) => _produtoRepository.ObterProdutoPorId(carrinhoItem.ProdutoId))
                            .Returns(Task.FromResult(produto));

            var carrinhoController = new CarrinhoController(_carrinhoRepository, _produtoRepository);

            //Act
            var result = await carrinhoController.DeletarItemCarrinho(IdCarrinho);

            //Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<ActionResult<CarrinhoItemDto>>(result);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            okResult.Should().NotBeNull();
            okResult.Value.Should().BeOfType<CarrinhoItemDto>();
            okResult.StatusCode.Should().Be(StatusCodes.Status200OK);

        }
        
        [Fact]
        public async Task CarrinhoController_DeletarItemCarrinho_ReturnNotFound404()
        {
            //Arrange
            int IdCarrinho = 1;
            var carrinhoItem = A.Fake<CarrinhoItem>();
            var produto = A.Fake<Produto>();

            A.CallTo(( ) => _carrinhoRepository.DeletaItem(IdCarrinho))
                            .Returns(Task.FromResult<CarrinhoItem>(null!));

            A.CallTo(( ) => _produtoRepository.ObterProdutoPorId(carrinhoItem.ProdutoId))
                            .Returns(Task.FromResult(produto));

            var carrinhoController = new CarrinhoController(_carrinhoRepository, _produtoRepository);

            //Act
            var result = await carrinhoController.DeletarItemCarrinho(IdCarrinho);

            //Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<ActionResult<CarrinhoItemDto>>(result);
            var okResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            okResult.Should().NotBeNull();
            okResult.Value.Should().Be("Item do Carrinho não encotrado");
            okResult.StatusCode.Should().Be(StatusCodes.Status404NotFound);

        }
        
        [Fact]
        public async Task CarrinhoController_DeletarItemCarrinho_ReturnException500()
        {
            //Arrange
            int IdCarrinho = 1;
            var carrinhoItem = A.Fake<CarrinhoItem>();
            var produto = A.Fake<Produto>();

            A.CallTo(( ) => _carrinhoRepository.DeletaItem(IdCarrinho))
                            .Throws(new Exception("Erro ao acessar Base de Dados"));

            A.CallTo(( ) => _produtoRepository.ObterProdutoPorId(carrinhoItem.ProdutoId))
                            .Returns(Task.FromResult(produto));

            var carrinhoController = new CarrinhoController(_carrinhoRepository, _produtoRepository);

            //Act
            var result = await carrinhoController.DeletarItemCarrinho(IdCarrinho);

            //Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<ActionResult<CarrinhoItemDto>>(result);
            var okResult = Assert.IsType<ObjectResult>(result.Result);
            okResult.Should().NotBeNull();
            okResult.Value.Should().Be("Erro ao acessar Base de Dados");
            okResult.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);

        }
    }
}
