using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Api.Controllers.CarrinhoController;
using LojaSonhoDeCafe.Api.Repositories.Carrinho;
using LojaSonhoDeCafe.Api.Repositories.Produtos;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaSonhoDeCafe.Test.CarrinhoCompraTest.CarrinhoControllerTest.CarrinhoPutTest
{
    public class CarrinhoControllerPutTest
    {
        private readonly ICarrinhoCompraRepositoryApi _carrinhoRepository;
        private readonly IProdutoRepositoryApi _produtoRepository;
        public CarrinhoControllerPutTest( )
        {
            _carrinhoRepository = A.Fake<ICarrinhoCompraRepositoryApi>();
            _produtoRepository = A.Fake<IProdutoRepositoryApi>();
        }

        [Fact]
        public async Task CarrinhoController_AtualizaQuantidadeItemNoCarrinho_ReturnOK200( )
        {
            //Arrange
            int Id = 1;
            var carrinhoItemAttDTO = A.Fake<CarrinhoItemAtualizaQuantidadeDto>();

            var carrinhoItem = A.Fake<CarrinhoItem>();
            var produto = A.Fake<Produto>();


            A.CallTo(()=> _carrinhoRepository.AtualizaQuantidade(Id, carrinhoItemAttDTO))
                         .Returns(Task.FromResult(carrinhoItem));

            A.CallTo(( ) => _produtoRepository.ObterProdutoPorId(carrinhoItem.ProdutoId))
            .Returns(Task.FromResult(produto));

            var carrinhoController = new CarrinhoController(_carrinhoRepository, _produtoRepository);

            //Act
            var result = await carrinhoController.AtualizaQuantidadeItemNoCarrinho(Id, carrinhoItemAttDTO);
            //Assert

            result.Should().NotBeNull();
            var actionResult = Assert.IsType<ActionResult<CarrinhoItemDto>>(result);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            okResult.Value.Should().BeOfType<CarrinhoItemDto>();
            okResult.StatusCode.Should().Be(200);
        } 
        
        [Fact]
        public async Task CarrinhoController_AtualizaQuantidadeItemNoCarrinho_ReturnNotFound404( )
        {
            //Arrange
            int Id = 1;
            var carrinhoItemAttDTO = A.Fake<CarrinhoItemAtualizaQuantidadeDto>();

            var carrinhoItem = A.Fake<CarrinhoItem>();
            var produto = A.Fake<Produto>();


            A.CallTo(()=> _carrinhoRepository.AtualizaQuantidade(Id, carrinhoItemAttDTO))
                         .Returns(Task.FromResult<CarrinhoItem>(null!));

            A.CallTo(( ) => _produtoRepository.ObterProdutoPorId(carrinhoItem.ProdutoId))
            .Returns(Task.FromResult(produto));

            var carrinhoController = new CarrinhoController(_carrinhoRepository, _produtoRepository);

            //Act
            var result = await carrinhoController.AtualizaQuantidadeItemNoCarrinho(Id, carrinhoItemAttDTO);
            //Assert

            result.Should().NotBeNull();
            var actionResult = Assert.IsType<ActionResult<CarrinhoItemDto>>(result);
            var okResult = Assert.IsType<NotFoundObjectResult>(actionResult.Result);
            okResult.Value.Should().Be("Item do Carrinho não encontrado!");
            okResult.StatusCode.Should().Be(404);
        }
        
        [Fact]
        public async Task CarrinhoController_AtualizaQuantidadeItemNoCarrinho_ReturnException500()
        {
            //Arrange
            int Id = 1;
            var carrinhoItemAttDTO = A.Fake<CarrinhoItemAtualizaQuantidadeDto>();

            var carrinhoItem = A.Fake<CarrinhoItem>();
            var produto = A.Fake<Produto>();


            A.CallTo(()=> _carrinhoRepository.AtualizaQuantidade(Id, carrinhoItemAttDTO))
                         .Throws(new Exception("Erro na base de Dados!"));

            A.CallTo(( ) => _produtoRepository.ObterProdutoPorId(carrinhoItem.ProdutoId))
                         .Returns(Task.FromResult(produto));
                        
            var carrinhoController = new CarrinhoController(_carrinhoRepository, _produtoRepository);

            //Act
            var result = await carrinhoController.AtualizaQuantidadeItemNoCarrinho(Id, carrinhoItemAttDTO);
            //Assert

            result.Should().NotBeNull();
            var actionResult = Assert.IsType<ActionResult<CarrinhoItemDto>>(result);
            var objectResult = Assert.IsType<ObjectResult>(actionResult.Result);
            objectResult.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
            objectResult.Value.Should().Be("Erro na base de Dados!");
        }
    }
}
