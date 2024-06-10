using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Api.Repositories.Carrinho;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;
using LojaSonhoDeCafe.Test.CarrinhoCompraTest.CarrinhoRepositoryTest.BancoInMemoryMetodo;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace LojaSonhoDeCafe.Test.CarrinhoCompraTest.CarrinhoRepositoryTest.CarrinhoRepositoryPost
{
    public class CarrinhoRepositorioPostTest
    {
        [Fact]
        public async Task CarrinhoRepositorio_AdicionarItem_RetornarUmItemDoCarrinho()
        {
            //Arrange
            var dbContext = await BancoDeDadosInMemoryCarrinho.GetBancoDeDadosCarrinho();
            var produtoExistente = await dbContext.Produtos.FirstOrDefaultAsync();

            var carrinhoItemAddDto = new CarrinhoItemAdicionaDto()
            {
                CarrinhoId = 2,
                ProdutoId = produtoExistente!.Id,
                Quantidade = 10

             };

            var carrinhoRepositorio = new CarrinhoCompraRepositoryApi(dbContext);

            //Act
            var result = await carrinhoRepositorio.AdicionaItem(carrinhoItemAddDto);


            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<CarrinhoItem>();
            Assert.Equal(carrinhoItemAddDto.CarrinhoId, carrinhoItemAddDto.CarrinhoId);
            Assert.Equal(carrinhoItemAddDto.ProdutoId, carrinhoItemAddDto.ProdutoId);


        }
    }
}
