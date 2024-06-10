using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Api.Repositories.Carrinho;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;
using LojaSonhoDeCafe.Test.CarrinhoCompraTest.CarrinhoRepositoryTest.BancoInMemoryMetodo;

namespace LojaSonhoDeCafe.Test.CarrinhoCompraTest.CarrinhoRepositoryTest.CarrinhoRepositoryPut
{
    public class CarrinhoRepositorioPutTest
    {
        [Fact]
        public async Task CarrinhoRepositorio_AtualizarQuantidadeItem_ReturnaItemDoCarrinho( )
        {
            //Arrange
            int ItemId = 1;
            var carrinhoItemDto = A.Fake<CarrinhoItemAtualizaQuantidadeDto>();

            var dbContext = await BancoDeDadosInMemoryCarrinho.GetBancoDeDadosCarrinho();

            var carrinhoRepositorio = new CarrinhoCompraRepositoryApi(dbContext);

            //Act
            var result = await carrinhoRepositorio.AtualizaQuantidade(ItemId, carrinhoItemDto);
            
            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<CarrinhoItem>();
            Assert.Equal(1, result.CarrinhoId);
            Assert.Equal(carrinhoItemDto.Quantidade, result.Quantidade);
            
        }
    }
}
