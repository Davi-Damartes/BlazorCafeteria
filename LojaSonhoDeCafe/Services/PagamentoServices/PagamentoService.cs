using LojaSonhoDeCafe.MapeandoDtos.PagamentoConversao;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Repositories.Pagamento;

namespace LojaSonhoDeCafe.Services.PagamentoServices
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly ILogger<PagamentoService> _logger;

        public PagamentoService(IPagamentoRepository pagamentoRepository, 
                                ILogger<PagamentoService> logger)
        {
            _pagamentoRepository = pagamentoRepository;
            _logger = logger;
        }

        public async Task<bool> AdicionarPagamento(PagamentoDiarioDto pagamentoDiarioDto)
        {
            if (pagamentoDiarioDto == null)
            {
                _logger.LogError("Pagamento inválido: objeto nulo.");
                return false;
            }

            if (!ValidarDataPagamento(pagamentoDiarioDto))
            {
                _logger.LogError("Pagamento Inválido: a loja está fechada.");
                return false;
            }

            try
            {
                var pagamento = pagamentoDiarioDto.ConvertePagamentoDtoParaPagamento();
                await _pagamentoRepository.AdicionarPagamento(pagamento);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao adicionar pagamento.");
                return false;
            }
        }

        public async Task<IEnumerable<PagamentoDiarioDto>> ObterTodosPagamentosPorMes(int mes)
        {
            try
            {
                var pagamentos = await _pagamentoRepository.BucarTodosPagamentosPeloMes(mes);
                var pagamentosDto = pagamentos.ConvertListPagamentosParaListPagamentosDto();
                return pagamentosDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter pagamentos por mês.");
                return Enumerable.Empty<PagamentoDiarioDto>();
            }
        }

        private bool ValidarDataPagamento(PagamentoDiarioDto pagamento)
        {
            var horaAbertura = new TimeSpan(07, 00, 00);
            var horaFechamento = new TimeSpan(22, 00, 00);

            TimeSpan horaPagamento = pagamento.HoraDoPagamento.TimeOfDay;

            // Verifica se a hora do pagamento está entre 07:00:00 e 19:00:00
            return horaPagamento >= horaAbertura && horaPagamento <= horaFechamento;
        }
    }
}
