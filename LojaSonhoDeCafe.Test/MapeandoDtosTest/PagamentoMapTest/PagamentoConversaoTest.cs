using FluentAssertions;
using LojaSonhoDeCafe.Enum;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;
using LojaSonhoDeCafe.Models.MapeandoDtos.PagamentoConversao;

namespace LojaSonhoDeCafe.Test.MapeandoDtosTest.PagamentoMapTest
{
    public class PagamentoConversaoTest
    {
        public class CarrinhoConversaoTest
        {
            [Fact]
            public void ConverterPagamentoDto_Para_PagamentoDiario( )
            {
                // Arrange
                var pagamentoDiarioDto = new PagamentoDiarioDto
                {
                    Usuario = "João Silva",
                    Email = "joao.silva@example.com",
                    TotalQuantDiaria = 5,
                    TotalPrecoDiaria = 150.75M,
                    EPagamento = EPagamentoDto.mastercard,
                    HoraDoPagamento = DateTime.Now,
                    ProdutosDoPagamento = new List<PagamentoProdutoDto>
                    {
                        new PagamentoProdutoDto
                        {
                            ProdutoId = Guid.NewGuid(),
                            QuantidadeComprada = 2,
                            ProdutoNome = "Produto A",
                            PrecoTotal = 50.25M
                        },
                        new PagamentoProdutoDto
                        {
                            ProdutoId = Guid.NewGuid(),
                            QuantidadeComprada = 3,
                            ProdutoNome = "Produto B",
                            PrecoTotal = 100.50M
                        }
                    }
                };

                // Act
                var pagamentoDiario = pagamentoDiarioDto.ConvertePagamentoDtoParaPagamento();

                // Assert
                pagamentoDiario.Should().NotBeNull();

                pagamentoDiario.Usuario.Should().Be(pagamentoDiarioDto.Usuario);
                pagamentoDiario.Email.Should().Be(pagamentoDiarioDto.Email);
                pagamentoDiario.TotalPrecoDiaria.Should().Be(pagamentoDiarioDto.TotalPrecoDiaria);

            }
        
            [Fact]
            public void ConverterListaPagamentoDiarios_Para_ListaPagamentoDiariosDto( )
            {
                // Arrange
                    var listaPagamentosDiarios = new List<PagamentoDiario>
                    {
                        new PagamentoDiario
                        {
                            Usuario = "João Silva",
                            Email = "joao.silva@example.com",
                            TotalQuantDiaria = 5,
                            TotalPrecoDiaria = 150.75M,
                            EPagamento = ETipoPagamento.codigoBarra,
                            HoraDoPagamento = DateTime.Now.AddHours(-2),
                            PagamentoProdutos = new List<PagamentoProduto>
                            {
                                new PagamentoProduto
                                {
                                    ProdutoId = Guid.NewGuid(),
                                    QuantidadeComprada = 2,
                                    ProdutoNome = "Produto A",
                                    PrecoTotal = 50.25M
                                },
                                new PagamentoProduto
                                {
                                    ProdutoId = Guid.NewGuid(),
                                    QuantidadeComprada = 3,
                                    ProdutoNome = "Produto B",
                                    PrecoTotal = 100.50M
                                }
                            }
                        },
                        new PagamentoDiario
                        {
                            Usuario = "Maria Oliveira",
                            Email = "maria.oliveira@example.com",
                            TotalQuantDiaria = 3,
                            TotalPrecoDiaria = 90.00M,
                            EPagamento = ETipoPagamento.paypal,
                            HoraDoPagamento = DateTime.Now.AddHours(-1),
                            PagamentoProdutos = new List<PagamentoProduto>
                            {
                                new PagamentoProduto
                                {
                                    ProdutoId = Guid.NewGuid(),
                                    QuantidadeComprada = 1,
                                    ProdutoNome = "Produto C",
                                    PrecoTotal = 30.00M
                                },
                                new PagamentoProduto
                                {
                                    ProdutoId = Guid.NewGuid(),
                                    QuantidadeComprada = 2,
                                    ProdutoNome = "Produto D",
                                    PrecoTotal = 60.00M
                                }
                            }
                        },
                        new PagamentoDiario
                        {
                            Usuario = "Carlos Lima",
                            Email = "carlos.lima@example.com",
                            TotalQuantDiaria = 7,
                            TotalPrecoDiaria = 210.99M,
                            EPagamento = ETipoPagamento.mastercard,
                            HoraDoPagamento = DateTime.Now.AddMinutes(-30),
                            PagamentoProdutos = new List<PagamentoProduto>
                            {
                                new PagamentoProduto
                                {
                                    ProdutoId = Guid.NewGuid(),
                                    QuantidadeComprada = 4,
                                    ProdutoNome = "Produto E",
                                    PrecoTotal = 80.00M
                                },
                                new PagamentoProduto
                                {
                                    ProdutoId = Guid.NewGuid(),
                                    QuantidadeComprada = 3,
                                    ProdutoNome = "Produto F",
                                    PrecoTotal = 130.99M
                                }
                            }
                        }
                    };

                // Act
                var listaPagamentosDiariosDto = listaPagamentosDiarios.ConverteListPagamentosParaListPagamentosDto();

                // Assert
                listaPagamentosDiariosDto.Should().NotBeNull();

                Assert.Equal(3, listaPagamentosDiariosDto.Count());

                listaPagamentosDiariosDto.First().Usuario.Should().Be(listaPagamentosDiarios.First().Usuario);
                listaPagamentosDiariosDto.First().ProdutosDoPagamento.First().QuantidadeComprada
                    .Should().Be(listaPagamentosDiarios.First().PagamentoProdutos!.First().QuantidadeComprada);
                listaPagamentosDiariosDto.First().ProdutosDoPagamento.First().ProdutoNome
                    .Should().Be(listaPagamentosDiarios.First().PagamentoProdutos!.First().ProdutoNome);
                listaPagamentosDiariosDto.First().ProdutosDoPagamento.First().ProdutoId
                    .Should().Be(listaPagamentosDiarios.First().PagamentoProdutos!.First().ProdutoId);

                listaPagamentosDiariosDto.First().Usuario.Should().Be(listaPagamentosDiarios.First().Usuario);

            }
        }
    }
}
