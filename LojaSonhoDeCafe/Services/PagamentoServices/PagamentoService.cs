using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Repositories.Pagamento;
using SonhoDeCafe.Server.MapeandoDto;

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
            if(pagamentoDiarioDto == null)
            {
                _logger.LogError("Pagamento inválido");
                return; 
            }

            var pagamento = pagamentoDiarioDto.ConvertePagamentoDtoParaPagamento();

            await _pagamentoRepository.AdicionarPagamento(pagamento);
        }
    }
}
