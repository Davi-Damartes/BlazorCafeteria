using LojaSonhoDeCafe.Models.Dtos;
using System.Net;
using System.Text.Json;
using System.Text;

namespace LojaSonhoDeCafe.ServicesHttp.CarrinhoComprasHttpService
{
    public class CarrinhoCompraHttpService : ICarrinhoCompraHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<CarrinhoCompraHttpService> _logger;
        public event Action<int>? OnCarrinhoCompraChanged;

        public CarrinhoCompraHttpService(HttpClient httpClient, 
                                         ILogger<CarrinhoCompraHttpService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<List<CarrinhoItemDto>> ObterItensCarrinho(string usuarioId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Carrinho/{usuarioId}/ObterItensCarrinhoDoUsuario");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CarrinhoItemDto>().ToList();
                    }

                    return await response.Content.ReadFromJsonAsync<List<CarrinhoItemDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code: {response.StatusCode} Mensagem: {message}");
                }
            }
            catch (Exception)
            {
                _logger.LogError("Erros ao Buscar Itens do Carrinho");
                throw;
            }

        }
       
        public async Task<CarrinhoItemDto> AtualizarQuantidade(int id, CarrinhoItemAtualizaQuantidadeDto atualizaQuantidadeDto)
        {
            try
            {
                var jsonRequest = JsonSerializer.Serialize(atualizaQuantidadeDto);

                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json-patch+json");

                var response = await _httpClient.PatchAsync($"api/Carrinho/{atualizaQuantidadeDto.CarrinhoId}", content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CarrinhoItemDto>();
                }
                return null!;
            }
            catch (Exception)
            {
                _logger.LogError("Erros ao Atualizar Item do Carrinho");
                throw;
            }
        }
    
        public async Task<CarrinhoItemDto> AdicionaItemCarrinhoDto(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            try
            {
                var response = await _httpClient
                              .PostAsJsonAsync<CarrinhoItemAdicionaDto>("api/Carrinho",
                               carrinhoItemAdicionaDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default(CarrinhoItemDto)!;
                    }                 
                    return await response.Content.ReadFromJsonAsync<CarrinhoItemDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"{response.StatusCode} Message -{message}");
                }
            }
            catch (Exception)
            {

                _logger.LogError("Erros ao Adcionar Item no Carrinho");
                throw;
            }
        }


        public async Task<CarrinhoItemDto> DeletaItemDoCarrinho(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Carrinho/{id}/DeletarItemCarrinho");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<CarrinhoItemDto>() ?? null!;
                }
                return default(CarrinhoItemDto)!;
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao excluir Item do carrinho");
                throw;
            }

        }


        public async Task LimpaItensCarrinhoDeCompra( )
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/Carrinho/");

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"Erro ao Esvaziar itens do Carrinho: {response.ReasonPhrase}");
                    // Você pode lançar uma exceção customizada ou tratar o erro conforme necessário
                }

            }
            catch (Exception)
            {
                _logger.LogError("Erro Esvaziar##");
                throw;
            }



        }


        //public void RaiseEventCarrinhoCompraChanged(int totalQuantidade)
        //{
        //    if (OnCarrinhoCompraChanged != null)
        //    {
        //        OnCarrinhoCompraChanged.Invoke(totalQuantidade);
        //    }

        //}

    }
}
