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

        public async Task AdicionarPagamento(PagamentoDiarioDto pagamentoDiarioDto)
        {
            var LojaAberta = ValidarDataPagamento(pagamentoDiarioDto);

            if (pagamentoDiarioDto == null || LojaAberta == false)
            {
                _logger.LogError("Pagamento inválido");
                return; 
            }
            if (LojaAberta == false)
            {
                _logger.LogError("Pagamento Inválido a Loja está fechada!!!");
                return;
            }

            var pagamento = pagamentoDiarioDto.ConvertePagamentoDtoParaPagamento();


            await _pagamentoRepository.AdicionarPagamento(pagamento);
        }

        public async Task<IEnumerable<PagamentoDiarioDto>> ObterTodosPagamentosPorMes(int mes)
        {
            var pagamentos = await _pagamentoRepository.BucarTodosPagamentosPeloMes(mes);

            var pagamentosDto = pagamentos.ConvertListPagamentosParaListPagamentosDto();


            return pagamentosDto;
        }

        private bool ValidarDataPagamento(PagamentoDiarioDto pagamento)
        {
            var horaAbertura = new TimeSpan(7, 0, 0);
            var horaFechamento = new TimeSpan(19, 35, 0);

            TimeSpan horaPagamento = pagamento.HoraDoPagamento.TimeOfDay;

            // Verifica se a hora do pagamento está entre 07:00:00 e 19:00:00
            return horaPagamento >= horaAbertura && horaPagamento <= horaFechamento;
        }
    }
}
