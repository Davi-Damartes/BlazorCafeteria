using Microsoft.EntityFrameworkCore;
using LojaSonhoDeCafe.Models.Entity;
using LojaSonhoDeCafe.Api.Banco;

namespace LojaSonhoDeCafe.Api.Repositories.Pagamento
{
    public class PagamentoRepository : IPagamentoRepository2
    {
        private readonly BancoDeDado _bancoDeDados;

        public PagamentoRepository(BancoDeDado bancoDeDados)
        {
            _bancoDeDados = bancoDeDados;
        }

        public async Task AdicionarPagamento(PagamentoDiario pagamentoDiario)
        {
            if (pagamentoDiario != null)
            {
                await _bancoDeDados.PagamentosDiarios.AddAsync(pagamentoDiario);
                await _bancoDeDados.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<PagamentoDiario>> BucarTodosPagamentosPeloMes(int mes)
        {
            return await _bancoDeDados.PagamentosDiarios
                               .AsQueryable()
                               .Where(x => x.HoraDoPagamento.Month == mes)
                               .OrderBy(x => x.HoraDoPagamento)
                               .ToListAsync();
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
