using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Api.Controllers.CarrinhoController;
using LojaSonhoDeCafe.Api.Repositories.Carrinho;
using LojaSonhoDeCafe.Api.Repositories.Produtos;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;
using Microsoft.AspNetCore.Mvc;

namespace LojaSonhoDeCafe.Test.CarrinhoCompraTest.CarrinhoControllerTest.CarrinhoPostTest
{
    public class CarrinhoControllerPostTest
    {
        private readonly ICarrinhoCompraRepositoryApi _carrinhoRepository;
        private readonly IProdutoRepositoryApi _produtoRepository;
        public CarrinhoControllerPostTest( )
        {
            _carrinhoRepository = A.Fake<ICarrinhoCompraRepositoryApi>();
            _produtoRepository = A.Fake<IProdutoRepositoryApi>();
        }

        [Fact]
        public async Task CarrinhoController_AdicionarItemCarrinho_ReturnCreatedAtAction201( )
        {
            var carrinhoItemAddDto = A.Fake<CarrinhoItemAdicionaDto>();
            var carrinhoItem = A.Fake<CarrinhoItem>();

            var produto = A.Fake<Produto>();
            // sArrange
            A.CallTo(( ) => _carrinhoRepository.AdicionaItem(carrinhoItemAddDto))
                            .Returns(Task.FromResult(carrinhoItem));


            A.CallTo(( ) => _produtoRepository.ObterProdutoPorId(carrinhoItemAddDto.ProdutoId))
                            .Returns(Task.FromResult(produto));
            var carrinhoController = new CarrinhoController(_carrinhoRepository, _produtoRepository);

            // Act
            var result = await carrinhoController.AdicionarItemCarrinho(carrinhoItemAddDto);

            // Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<ActionResult<CarrinhoItemDto>>(result);
            var createdObjectResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            createdObjectResult.Value.Should().BeOfType<CarrinhoItemDto>();
            createdObjectResult.StatusCode.Should().Be(201);

        }

        [Fact]
        public async Task CarrinhoController_AdicionarItemCarrinho_ReturnNotFound404( )
        {
            var carrinhoItemAddDto = A.Fake<CarrinhoItemAdicionaDto>();
            var carrinhoItem = A.Fake<CarrinhoItem>();

            var produto = A.Fake<Produto>();
            // sArrange
            A.CallTo(( ) => _carrinhoRepository.AdicionaItem(carrinhoItemAddDto))
                            .Returns(Task.FromResult<CarrinhoItem>(null!));


            A.CallTo(( ) => _produtoRepository.ObterProdutoPorId(carrinhoItemAddDto.ProdutoId))
                            .Returns(Task.FromResult(produto));
            var carrinhoController = new CarrinhoController(_carrinhoRepository, _produtoRepository);

            // Act
            var result = await carrinhoController.AdicionarItemCarrinho(carrinhoItemAddDto);

            // Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<ActionResult<CarrinhoItemDto>>(result);
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result.Result);
            notFoundObjectResult.Value.Should().Be("Erro ao adicionar item ao carrinho");
            notFoundObjectResult.StatusCode.Should().Be(404);

        }

        [Fact]
        public async Task CarrinhoController_AdicionarItemCarrinho_ReturnException500( )
        {
            var carrinhoItemAddDto = A.Fake<CarrinhoItemAdicionaDto>();
            var carrinhoItem = A.Fake<CarrinhoItem>();

            var produto = A.Fake<Produto>();
            // sArrange
            A.CallTo(( ) => _carrinhoRepository.AdicionaItem(carrinhoItemAddDto))
                            .Throws(new Exception("Erro ao acessar base de Dados!"));


            A.CallTo(( ) => _produtoRepository.ObterProdutoPorId(carrinhoItemAddDto.ProdutoId))
                            .Returns(Task.FromResult(produto));
            var carrinhoController = new CarrinhoController(_carrinhoRepository, _produtoRepository);

            // Act
            var result = await carrinhoController.AdicionarItemCarrinho(carrinhoItemAddDto);

            // Assert
            result.Should().NotBeNull();
            var actionResult = Assert.IsType<ActionResult<CarrinhoItemDto>>(result);
            var objectResult = Assert.IsType<ObjectResult>(result.Result);
            objectResult.StatusCode.Should().Be(500);
            objectResult.Value.Should().Be("Erro ao acessar base de Dados!");

        }
    }
}
