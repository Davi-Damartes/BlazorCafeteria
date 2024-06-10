using FluentAssertions;
using LojaSonhoDeCafe.Api.Repositories.Carrinho;
using LojaSonhoDeCafe.Models.Entity;
using LojaSonhoDeCafe.Test.CarrinhoCompraTest.CarrinhoRepositoryTest.BancoInMemoryMetodo;

namespace LojaSonhoDeCafe.Test.CarrinhoCompraTest.CarrinhoRepositoryTest.CarrinhoRepositoryGet
{
    public class CarrinhoRepositorioGetTests
    {

        [Fact]
        public async Task CarrinhoRepositorio_ObtemItensDoCarrinhoPeloUsuarioId_ReturnListaCarrinhoItens()
        {
            //Arrange
            string usuarioId = "1";

            var dbContext = await BancoDeDadosInMemoryCarrinho.GetBancoDeDadosCarrinho();

            var carrinhoRepositorio = new CarrinhoCompraRepositoryApi(dbContext);

            //Act
            var result = await carrinhoRepositorio.ObtemItensDoCarinho(usuarioId);
            var contagem = result.Count();

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<IEnumerable<CarrinhoItem>>();
            result.Should().HaveCountGreaterThan(0);
            Assert.Equal(2, contagem);

        }
        
        [Fact]
        public async Task CarrinhoRepositorio_ObtemItemDoCarrinhoPeloUsuarioId_ReturnUmItemDoCarrinho()
        {
            //Arrange
            int carrinhoId = 1;

            var dbContext = await BancoDeDadosInMemoryCarrinho.GetBancoDeDadosCarrinho();

            var carrinhoRepositorio = new CarrinhoCompraRepositoryApi(dbContext);

            //Act
            var result = await carrinhoRepositorio.ObtemItemDoCarrinhoPorId(carrinhoId);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeAssignableTo<CarrinhoItem>();
            result.CarrinhoId.Should().Be(1);

        }
    }
}
