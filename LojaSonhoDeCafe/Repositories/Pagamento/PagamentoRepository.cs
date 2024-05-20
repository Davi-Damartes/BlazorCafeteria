using LojaSonhoDeCafe.Data;
using LojaSonhoDeCafe.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace LojaSonhoDeCafe.Repositories.Pagamento
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly BancoDeDados _bancoDeDados;

        public PagamentoRepository(BancoDeDados bancoDeDados)
        {
            _bancoDeDados = bancoDeDados;
        }

        public async Task AdicionarPagamento(PagamentoDiario pagamentoDiario)
        {
            if(pagamentoDiario != null)
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
