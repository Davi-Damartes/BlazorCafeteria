using LojaSonhoDeCafe.Models.Dtos;
using System.Net;
using System.Text.Json;
using System.Text;

namespace LojaSonhoDeCafe.ServicesHttp.CarrinhoComprasHttpService
{
    public class CarrinhoCompraHttpService : ICarrinhoCompraHttpService
    {
        private readonly ILogger<CarrinhoCompraHttpService> _logger;
        private readonly HttpClient _httpClient;
        public event Action<int>? OnCarrinhoCompraChanged;

        public CarrinhoCompraHttpService(ILogger<CarrinhoCompraHttpService> logger,
                                        HttpClient httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        public async Task<CarrinhoItemDto> AdicionaItemCarrinhoDto(CarrinhoItemAdicionaDto carrinhoItemAdicionaDto)
        {
            try
            {
                var response = await _httpClient
                              .PostAsJsonAsync<CarrinhoItemAdicionaDto>("api/Carrinho",
                               carrinhoItemAdicionaDto);

                if (response.IsSuccessStatusCode)// status code entre 200 a 299
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        // retorna o valor "padrão" ou vazio
                        // para uma objeto do tipo carrinhoItemDto
                        return default(CarrinhoItemDto);
                    }
                    //le o conteudo HTTP e retorna o valor resultante
                    //da serialização do conteudo JSON para o objeto Dto
                    return await response.Content.ReadFromJsonAsync<CarrinhoItemDto>();
                }
                else
                {
                    //serializa o conteudo HTTP como uma string
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"{response.StatusCode} Message -{message}");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<List<CarrinhoItemDto>> ObterItensCarrinho(string usuarioId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Carrinho/{usuarioId}/ObterItensCarrinhoDoUsuario");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
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
