using FakeItEasy;
using FluentAssertions;
using LojaSonhoDeCafe.Api.Repositories.Pagamento;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Test.PagamentoTest.PagamentoRepositorioTest.BancoInMemoryMetodo;
using Microsoft.EntityFrameworkCore;

namespace LojaSonhoDeCafe.Test.PagamentoTest.PagamentoRepositorioTest.PagamentoRepositorioPost
{
    public class PagamentoRepositorioPostTest
    {

        [Fact]
        public async Task PagRepositorio_AdicionarPagamento_ReturnTrue()
        {

            // Arrange 
            var listaPagamentoDiario = A.Fake<List<PagamentoProdutoDto>>();

            var pagamentoDiario = new PagamentoDiarioDto
            {
                Usuario = "UsuarioTeste",
                Email = "email@teste.com",
                TotalQuantDiaria = 10,
                TotalPrecoDiaria = 123.45m,
                EPagamento = EPagamentoDto.boleto,
                HoraDoPagamento = DateTime.Now,
                ProdutosDoPagamento = listaPagamentoDiario
            };

            var dbContext = await BancoDeDadosInMemoryPag.GetBancoDeDadoPag();


            var repositorioPagamento = new PagamentoRepositoryApi(dbContext);
            

            // Act 
            var result = await repositorioPagamento.AdicionarPagamento(pagamentoDiario);

            // Assert
            result.Should().BeTrue();

            var pagamentoAdicionado = await dbContext.PagamentosDiarios
                                                     .FirstOrDefaultAsync(p => p.Usuario == pagamentoDiario.Usuario);
            pagamentoAdicionado.Should().NotBeNull();

        }
        
        [Fact]
        public async Task PagRepositorio_AdicionarPagamento_ReturnFalse()
        {
            // Arrange 
            PagamentoDiarioDto? pagamentoDiarioDto = null;

            var dbContext = await BancoDeDadosInMemoryPag.GetBancoDeDadoPag();


            var repositorioPagamento = new PagamentoRepositoryApi(dbContext);

            // Act 
            var result = await repositorioPagamento.AdicionarPagamento(pagamentoDiarioDto!);

            // Assert
            result.Should().BeFalse();

        }
    }

}
