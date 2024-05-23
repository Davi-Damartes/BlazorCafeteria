using Microsoft.EntityFrameworkCore;
using LojaSonhoDeCafe.Models.Entity;
using LojaSonhoDeCafe.Api.Banco;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Enum;

namespace LojaSonhoDeCafe.Api.Repositories.Pagamento
{
    public class PagamentoRepository2 : IPagamentoRepository2
    {
        private readonly BancoDeDado _bancoDeDados;

        public PagamentoRepository2(BancoDeDado bancoDeDados)
        {
            _bancoDeDados = bancoDeDados;
        }

        public async Task<bool> AdicionarPagamento(PagamentoDiarioDto pagamentoDiario)
        {
            if (pagamentoDiario != null)
            {
                var pagamento = new PagamentoDiario
                {
                    Usuario = pagamentoDiario.Usuario,
                    Email = pagamentoDiario.Email,
                    TotalQuantDiaria = pagamentoDiario.TotalQuantDiaria,
                    TotalPrecoDiaria = pagamentoDiario.TotalPrecoDiaria,
                    EPagamento = (ETipoPagamento)pagamentoDiario.EPagamento,
                    HoraDoPagamento = pagamentoDiario.HoraDoPagamento,
                };
                await _bancoDeDados.PagamentosDiarios.AddAsync(pagamento);
                await _bancoDeDados.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<PagamentoDiario>> BucarTodosPagamentosPeloMes(int mes)
        {
            
            var resultado =  await _bancoDeDados.PagamentosDiarios
                                      .AsQueryable()
                                        .Where(x => x.HoraDoPagamento.Month == mes)
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
    }
}
