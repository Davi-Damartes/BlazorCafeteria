using Microsoft.EntityFrameworkCore;
using LojaSonhoDeCafe.Models.Entity;
using LojaSonhoDeCafe.Api.Banco;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Enum;

namespace LojaSonhoDeCafe.Api.Repositories.Pagamento
{
    public class PagamentoRepositoryApi : IPagamentoRepositoryApi
    {
        private readonly BancoDeDado _bancoDeDados;

        public PagamentoRepositoryApi(BancoDeDado bancoDeDados)
        {
            _bancoDeDados = bancoDeDados;
        }

        public async Task<bool> AdicionarPagamento(PagamentoDiarioDto pagamentoDiarioDto)
        {
            if (pagamentoDiarioDto != null)
            {
                var pagamento = new PagamentoDiario
                {
                    Usuario = pagamentoDiarioDto.Usuario,
                    Email = pagamentoDiarioDto.Email,
                    TotalQuantDiaria = pagamentoDiarioDto.TotalQuantDiaria,
                    TotalPrecoDiaria = pagamentoDiarioDto.TotalPrecoDiaria,
                    EPagamento = (ETipoPagamento)pagamentoDiarioDto.EPagamento,
                    HoraDoPagamento = pagamentoDiarioDto.HoraDoPagamento,

                };

                pagamento = AdicionarProdutosNoPagamento(pagamento, pagamentoDiarioDto);


                await AtualizarQuantidadeProduto(pagamento);

                await _bancoDeDados.PagamentosDiarios.AddAsync(pagamento);
                await _bancoDeDados.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<PagamentoDiario>> BucarTodosOsPagamentosXXX()
        {
                    var result = await _bancoDeDados.PagamentosDiarios.AsQueryable()
                                                                .Include(x => x.PagamentoProdutos)
                                                                .OrderBy(x => x.HoraDoPagamento)
                                                                .ToListAsync();
            
                    return result;
        }

        public async Task<IEnumerable<PagamentoProduto>> BucarTodosOsPagamentosProdutos( )
        {
            return await _bancoDeDados.PagamentoProdutos.ToListAsync();
        }



        public async Task<IEnumerable<PagamentoDiario>> BucarTodosPagamentosPeloMes(int mes)
        {
            
            var resultado =  await _bancoDeDados.PagamentosDiarios
                                      .AsQueryable()
                                        .Where(x => x.HoraDoPagamento.Month == mes)
                                        .Include(x => x.PagamentoProdutos)
                                        .OrderBy(x => x.HoraDoPagamento)
                                        .ToListAsync();
            return resultado;
        }


        public async Task<IEnumerable<Produto>> ObterTodosProdutosPorCategoria(int id)
        {
            var produtos = await _bancoDeDados
                              .Produtos
                              .Include(a => a.Categoria)
                              .Where(x => x.CategoriaId == id)
                              .ToListAsync();

            return produtos;
        }

        public async Task<IEnumerable<Categoria>> ObterCategorias( )
        {
            var categorias = await _bancoDeDados.Categorias.ToListAsync();

            return categorias;
        }

        public async Task<PagamentoDiario> BucarPagamentoPorId(Guid Id)
        {
            return await _bancoDeDados.PagamentosDiarios.FirstOrDefaultAsync(x => x.Id == Id) ?? null!;
        }
 
        private PagamentoDiario AdicionarProdutosNoPagamento(PagamentoDiario pagamento, PagamentoDiarioDto pagamentoDiarioDto)
        {

            if (pagamentoDiarioDto.ProdutosDoPagamento != null)
            {
                foreach (var produtoDto in pagamentoDiarioDto.ProdutosDoPagamento)
                {
                    var produto = new PagamentoProduto
                    {
                        ProdutoId = produtoDto.ProdutoId,
                        QuantidadeComprada = produtoDto.QuantidadeComprada,
                        ProdutoNome = produtoDto.ProdutoNome,
                        PrecoTotal = produtoDto.PrecoTotal,                
                        PagamentoDiario = pagamento
                    };

                    // Adicione o produto ao pagamento
                    pagamento.PagamentoProdutos!.Add(produto);
                }
                return pagamento;
            }

            return null!;
        }

        private async Task AtualizarQuantidadeProduto(PagamentoDiario pagamento)
        {
            foreach (var pagamentoProduto in pagamento.PagamentoProdutos!)
            {
                var produtoDb = await _bancoDeDados.Produtos
                                                   .AsQueryable()
                                                   .Include(x => x.Categoria)
                                                   .FirstOrDefaultAsync(x => x.Id == pagamentoProduto.ProdutoId);

                if (produtoDb != null)
                {
                    produtoDb.QuantidadeEmEstoque -= pagamentoProduto.QuantidadeComprada;
                }
            }
        }

        public async Task ExcluirPagamento(Guid Id)
        {
            var pagamento = await _bancoDeDados.PagamentosDiarios
                                         .AsQueryable()
                                         .Include(x => x.PagamentoProdutos)
                                         .FirstOrDefaultAsync(x => x.Id == Id);

            if(pagamento != null)
            {
                _bancoDeDados.Remove(pagamento);
                await _bancoDeDados.SaveChangesAsync();
            }
        }
    }
}
