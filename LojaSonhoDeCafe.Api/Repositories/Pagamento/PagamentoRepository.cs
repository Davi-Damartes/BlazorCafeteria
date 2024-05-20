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
    }
}
