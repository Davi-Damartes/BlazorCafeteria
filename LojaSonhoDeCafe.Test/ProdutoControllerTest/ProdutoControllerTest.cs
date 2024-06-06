//using FakeItEasy;
//using FluentAssertions;
//using LojaSonhoDeCafe.Api.Controllers.ProdutoControllers;
//using LojaSonhoDeCafe.Api.Repositories.Produtos;
//using LojaSonhoDeCafe.Models.Dtos;
//using LojaSonhoDeCafe.Models.Entity;
//using Microsoft.AspNetCore.Mvc;
//using System.Net;

//namespace LojaSonhoDeCafe.Test.Controller
//{
//    public class ProdutoControllerTest
//    {
//        private readonly IProdutoRepositoryApi _produtoRepository;

//        public ProdutoControllerTest( )
//        {
//            _produtoRepository = A.Fake<IProdutoRepositoryApi>();
//        }

//        [Fact]
//        public async Task ProdutosController_ObterProdutoPorId_ReturnOk()
//        {
//            //Arrange
//            var produto = new Produto
//            {
//                Nome = "Cafeteira Expresso",
//                Descricao = "Uma cafeteira moderna que prepara um café delicioso em poucos minutos.",
//                FotoUrl = "https://example.com/cafe.jpg",
//                Preco = 299.99m,
//                QuantidadeEmEstoque = 50,
//                IsFavorito = true,
//                CategoriaId = 1, // ID da categoria
//                Categoria = new Categoria { Id = 1, Nome = "Eletrodomésticos" },
//            };

//            A.CallTo(() => _produtoRepository.ObterProdutoPorId(produto.Id))
//                .Returns(Task.FromResult(produto));

//            var contoller = new ProdutosController(_produtoRepository);

//            //Act
//            var result = await contoller.ObterProdutoId(produto.Id);


//            //Assert
//            result.Should().NotBeNull();
//            var actionResult = Assert.IsType<ActionResult<ProdutoDto>>(result);
//            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);

//            okResult.Value.Should().NotBeNull();;

//        }

//        [Fact]
//        public async Task ProdutosController_ObterProdutoPorId_ReturnNotFound()
//        {
//            // Arrange
//            var produtoId = Guid.Empty;

//            // Simular o repositório retornando null quando o produto não é encontrado
//            A.CallTo(( ) => _produtoRepository.ObterProdutoPorId(produtoId))
//                .Returns(Task.FromResult<Produto>(null!));

//            var controller = new ProdutosController(_produtoRepository);

//            // Act
//            var result = await controller.ObterProdutoId(produtoId);

//            // Assert
//            result.Should().NotBeNull();
//            var actionResult = Assert.IsType<ActionResult<ProdutoDto>>(result);
//            var notFoundResult = Assert.IsType<NotFoundObjectResult>(actionResult.Result);

//            notFoundResult.Value.Should().NotBeNull();

//        }

//        [Fact]
//        public async Task ProdutosController_ObterTodosProdutos_ReturnOk()
//        {
//            //Arrange
//            var produtos = A.Fake<IEnumerable<Produto>>();

//            var produtosDto = A.Fake<IEnumerable<ProdutoDto>>();

//            A.CallTo(( ) => _produtoRepository.ObterTodosOsProdutos())
//            .Returns(Task.FromResult(produtos));

//            var contoller = new ProdutosController(_produtoRepository);

//            //Act
//            var result = await contoller.ObterTodosItens();


//            //Assert
//            result.Should().NotBeNull();
//            var actionResult = Assert.IsType<ActionResult<IEnumerable<ProdutoDto>>>(result);
//            var okResult = Assert.IsType<OkObjectResult>(result.Result);
//        }

//        [Fact]
//        public async Task ProdutosController_ObterTodosOsItens_ReturnNotFound()
//        {
//            //Arrange
//            var produtosDto = A.Fake<IEnumerable<ProdutoDto>>();

//            A.CallTo(( ) => _produtoRepository.ObterTodosOsProdutos())
//            .Returns(Task.FromResult<IEnumerable<Produto>>(null!));

//            var contoller = new ProdutosController(_produtoRepository);

//            //Act
//            var result = await contoller.ObterTodosItens();


//            //Assert
//            result.Should().NotBeNull();
//            var actionResult = Assert.IsType<ActionResult<IEnumerable<ProdutoDto>>>(result);
//            var okResult = Assert.IsType<NotFoundObjectResult>(actionResult.Result);
//        }



//        [Fact]
//        public async Task ProdutosController_AtualizarProdutoFavorito_ReturnOk()
//        {
//            //Arrange
//            var produto = A.Fake<Produto>();


//            A.CallTo(()=> _produtoRepository.ObterProdutoPorId(produto.Id))
//            .Returns(Task.FromResult(produto));


//            A.CallTo(( ) => _produtoRepository.AtualizaProdutoFavorito(produto))
//            .Returns(Task.FromResult(produto));

//            var controler = new ProdutosController(_produtoRepository);
//            //Act
//            var result = await controler.AtualizarProdutoFavoritoPorId(produto.Id);

//            //Assert
//            result.Should().NotBeNull();
//            var actionResult = Assert.IsType<OkObjectResult>(result);
//            actionResult.Value.Should().Be("Produto Atualizado com Sucesso!");
         
//        }

//        [Fact]
//        public async Task ProdutosController_AtualizarProdutoFavorito_ReturnNotFound()
//        {
//            //Arrange
//            var produto = A.Fake<Produto>();

//            A.CallTo(( ) => _produtoRepository.ObterProdutoPorId(produto.Id))
//            .Returns(Task.FromResult<Produto>(null!));


//            A.CallTo(( ) => _produtoRepository.AtualizaProdutoFavorito(produto))
//            .Returns(Task.FromResult(produto));

//            var controler = new ProdutosController(_produtoRepository);
//            //Act
//            var result = await controler.AtualizarProdutoFavoritoPorId(produto.Id);

//            //Assert
//            result.Should().NotBeNull();
//            var actionResult = Assert.IsType<NotFoundObjectResult>(result);
//            actionResult.Value.Should().Be("Produto não encontrado!");

//        }

//        [Fact]
//        public async Task ProdutosController_AdicionarEstoqueAoProduto_ReturnOk()
//        {
//            //Arrange
//            var produto = A.Fake<Produto>();
//            int quantidade = 10;

//            A.CallTo(() => _produtoRepository.ObterProdutoPorId(produto.Id))
//                .Returns(Task.FromResult(produto));

//            A.CallTo(( ) => _produtoRepository.AdicionarEstoqueAoProduto(produto.Id, quantidade))
//              .Returns(Task.FromResult(produto));


//            var controller = new ProdutosController(_produtoRepository);

//            //Act
//            var result = await controller.AdicionarEstoqueAoProduto(produto.Id, quantidade);


//            //Assert
//            result.Should().NotBeNull();
//            var actionResult = Assert.IsType<OkObjectResult>(result);
//            actionResult.Value.Should().Be("Produto Reabastecido com sucesso!");


//        }

//        [Fact]
//        public async Task ProdutosController_AdicionarEstoque_QuantidadesInvalidas_ReturnBadRequest()
//        {
//            //Arrange
//            var produto = A.Fake<Produto>();

//            int quantidade = 81;
//            int quantidade2 = 0;

//            A.CallTo(( ) => _produtoRepository.ObterProdutoPorId(produto.Id))
//                .Returns(Task.FromResult(produto));

//            A.CallTo(( ) => _produtoRepository.AdicionarEstoqueAoProduto(produto.Id, quantidade))
//              .Returns(Task.FromResult(produto));


//            var controller = new ProdutosController(_produtoRepository);

//            //Act
//            var result = await controller.AdicionarEstoqueAoProduto(produto.Id, quantidade);
//            var result2 = await controller.AdicionarEstoqueAoProduto(produto.Id, quantidade2);

//            //Assert
//            result.Should().NotBeNull();
//            var actionResult = Assert.IsType<BadRequestObjectResult>(result);
//            actionResult.Value.Should().Be("Quantidade Inválida");

//            result2.Should().NotBeNull();
//            var actionResult2 = Assert.IsType<BadRequestObjectResult>(result);
//            actionResult.Value.Should().Be("Quantidade Inválida");

//        }


//        [Fact]
//        public async Task ProdutosController_AdicionarEstoque_DeveRetornarInternalServerError_QuandoOcorreExcecao()
//        {
//            //Arrange
//            var produtoId = Guid.NewGuid();
//            int quantidade = 10;

//            A.CallTo(( ) => _produtoRepository.ObterProdutoPorId(produtoId))
//                .Throws<Exception>();


//            var controller = new ProdutosController(_produtoRepository);

//            //Act
//            var result = await controller.AdicionarEstoqueAoProduto(produtoId, quantidade);

//            //Assert
//            result.Should().NotBeNull();
//            var actionResult = Assert.IsType<ObjectResult>(result);
//            actionResult.StatusCode.Should().Be((int) HttpStatusCode.InternalServerError);
//            actionResult.Value.Should().Be("Erro ao acessar a base de dados");

//        }



//        [Fact]
//        public async Task ProdutosController_CrirNovoProduto_ReturnCreated()
//        {
//            //Arrange

//            var produtoDto = new ProdutoDto { Id = Guid.NewGuid(), Nome = "Novo Produto" };

//            A.CallTo(( ) => _produtoRepository.ObterProdutoPorId(produtoDto.Id))
//                            .Returns(Task.FromResult<Produto>(null!));

//            var controller = new ProdutosController(_produtoRepository);

//            //Act
//            var result = await controller.CriarNovoProduto(produtoDto);

//            //Assert
//            result.Should().NotBeNull();

//            var actionResult = Assert.IsType<ActionResult<ProdutoDto>>(result);
//            var createdResult = Assert.IsType<CreatedResult>(actionResult.Result);
//            var resultValeue = Assert.IsType<ProdutoDto>(createdResult.Value);
//        }

//        [Fact]
//        public async Task ProdutosController_CrirNovoProduto_ReturnConflict()
//        {
//            //Arrange

//            var produto = A.Fake<Produto>();
//            var produtoDto = A.Fake<ProdutoDto>();

//            A.CallTo(( ) => _produtoRepository.ObterProdutoPorId(produtoDto.Id))
//                            .Returns(Task.FromResult<Produto>(produto));

//            var controller = new ProdutosController(_produtoRepository);

//            //Act
//            var result = await controller.CriarNovoProduto(produtoDto);

//            //Assert
//            result.Should().NotBeNull();

//            var actionResult = Assert.IsType<ActionResult<ProdutoDto>>(result);
//            var createdResult = Assert.IsType<ConflictObjectResult>(actionResult.Result);
//            createdResult.Value.Should().Be("Produto já existe!");
//        }

//        [Fact]
//        public async Task ProdutosController_CrirNovoProduto_ReturnInternalServerError()
//        {
//            //Arrange

//            var produto = A.Fake<Produto>();
//            var produtoDto = A.Fake<ProdutoDto>();

//            A.CallTo(( ) => _produtoRepository.ObterProdutoPorId(produtoDto.Id))
//                                              .Throws<Exception>();

//            var controller = new ProdutosController(_produtoRepository);

//            //Act
//            var result = await controller.CriarNovoProduto(produtoDto);

//            //Assert
//            result.Should().NotBeNull();

//            var actionResult = Assert.IsType<ObjectResult>(result.Result);
//            actionResult.StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);
//            actionResult.Value.Should().Be("Erro ao acessar a base de dados");
//        }



//        [Fact]
//        public async Task ProdutosController_DeletarProduto_DeveRetornarOk()
//        {
//            //Arragne
//            var produto = A.Fake<Produto>();
//            var produtoId = Guid.NewGuid();

//            A.CallTo(( ) => _produtoRepository.ObterProdutoPorId(produtoId))
//                .Returns(Task.FromResult(produto));

//            var controller = new ProdutosController(_produtoRepository);


//            //Act
//            var resutl = await controller.DeletarProduto(produtoId);


//            //Assert
//            resutl.Should().NotBeNull();
//            var actionResult = Assert.IsType<OkObjectResult>(resutl);
//            actionResult.Value.Should().Be("Produto Excluído com sucesso!");



//        }

//        [Fact]
//        public async Task ProdutosController_DeletarProduto_DeveRetornarNotFound()
//        {
//            //Arragne
//            var produto = A.Fake<Produto>();
//            var produtoId = Guid.NewGuid();

//            A.CallTo(( ) => _produtoRepository.ObterProdutoPorId(produtoId))
//                .Returns(Task.FromResult(produto));

//            var controller = new ProdutosController(_produtoRepository);


//            //Act
//            var resutl = await controller.DeletarProduto(produtoId);


//            //Assert
//            resutl.Should().NotBeNull();
//            var actionResult = Assert.IsType<OkObjectResult>(resutl);
//            actionResult.Value.Should().Be("Produto Excluído com sucesso!");

//        }
//    }
//}
