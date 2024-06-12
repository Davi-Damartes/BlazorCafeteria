using LojaSonhoDeCafe.Models.Dtos;
using System.Net;

namespace LojaSonhoDeCafe.ServicesHttp.PagamentoHttpService
{
    public class PagamentoHttpService : IPagamentoHttpService
    {
        private readonly HttpClient _httpClient;

        private readonly ILogger<PagamentoHttpService> _logger;
        public PagamentoHttpService(HttpClient httpClient, ILogger<PagamentoHttpService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<IEnumerable<PagamentoDiarioDto>> ObterTodosPagamentosPorMes(int mes)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Pagamento/{mes}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<PagamentoDiarioDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<PagamentoDiarioDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code - {response.StatusCode} Message - {message}");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao Realizar Pagamento {ex}");
                throw;
            }
        }

        public async Task<bool> AdicionarPagamento(PagamentoDiarioDto pagamentoDiarioDto)
        {
            try
            {
                if (!ValidarDataPagamento(pagamentoDiarioDto))
                {
                    _logger.LogError("Pagamento Inválido: A loja está fechada.");
                    return false;
                }

                var response = await _httpClient.PostAsJsonAsync("api/Pagamento", pagamentoDiarioDto);
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return false;
                    }
                    return true;
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code - {response.StatusCode} Message - {message}");
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao Realizar Pagamento {ex}");
                throw;
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
