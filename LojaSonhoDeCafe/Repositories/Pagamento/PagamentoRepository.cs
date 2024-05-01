using LojaSonhoDeCafe.Data;
using LojaSonhoDeCafe.Entities;

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
            }

        }
    }
}
