using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.ServicesHttp.ProdutosHttpService;
using Microsoft.Extensions.Logging;
using System.Net;

namespace LojaSonhoDeCafe.ServicesHttp.PagamentoHttpService
{
    public class PagamentoHttpService : IPagamentoHttpService
    {
        private readonly HttpClient _httpClient;

        private readonly ILogger<PagamentoHttpService> _logger;
        public PagamentoHttpService(ILogger<PagamentoHttpService> logger, HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<bool> AdicionarPagamento(PagamentoDiarioDto pagamentoDiarioDto)
        {
            try
            {
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
    }
}
