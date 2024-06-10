using FluentAssertions;
using LojaSonhoDeCafe.Api.Repositories.Carrinho;
using LojaSonhoDeCafe.Models.Entity;
using LojaSonhoDeCafe.Test.CarrinhoCompraTest.CarrinhoRepositoryTest.BancoInMemoryMetodo;

namespace LojaSonhoDeCafe.Test.CarrinhoCompraTest.CarrinhoRepositoryTest.CarrinhoRepositoryDelete
{
    public class CarrinhoRepositorioDeleteTests
    {
        [Fact]
        public async Task CarrinhoRepositorio_DeletaItem_ReturnItemDoCarrinhoDeletado( )
        {
            //Arrange
            int carrinhoId = 1;
            var dbContext = await BancoDeDadosInMemoryCarrinho.GetBancoDeDadosCarrinho();

            var carrinhoRepositorio = new CarrinhoCompraRepositoryApi(dbContext);

            //Act
            var result = await carrinhoRepositorio.DeletaItem(carrinhoId);

            //Assert
            result.Should().NotBeNull();
            Assert.IsType<CarrinhoItem>(result);
            result.CarrinhoId.Should().Be(carrinhoId);

        }


        [Fact]
        public async Task CarrinhoRepositorio_LimpaItensDoCarrinho_ReturnTrue()
        {
            //Arrange
            var dbContext = await BancoDeDadosInMemoryCarrinho.GetBancoDeDadosCarrinho();

            var carrinhoRepositorio = new CarrinhoCompraRepositoryApi(dbContext);

            //Act
            var result = await carrinhoRepositorio.LimpaItensDoCarrinho();

            //Assert
            Assert.IsType<bool>(result);
            result.Should().BeTrue();
            Assert.True(result);

        }

    }
}
