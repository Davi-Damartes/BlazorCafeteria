﻿using LojaSonhoDeCafe.Models.Dtos;
using System.Net;

namespace LojaSonhoDeCafe.ServicesHttp.ProdutosHttpService
{
    public class ProdutoHttpService : IProdutoHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ProdutoHttpService> _logger;

        public ProdutoHttpService(HttpClient httpClient,
                              ILogger<ProdutoHttpService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

 

        public async Task<IEnumerable<ProdutoDto>> BuscarItensPorCategoria(int categoriaId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Produtos/{categoriaId}/ObterProdutosPorCategoria");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<ProdutoDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<ProdutoDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code - {response.StatusCode} Message - {message}");
                }
            }
            catch (Exception)
            {
                //log exception
                throw;
            }
        }


        public async Task<IEnumerable<ProdutoDto>> ObterProdutos()
        {
            try
            {
                var produtosDto = await _httpClient.GetFromJsonAsync<IEnumerable<ProdutoDto>>
                                                    ("api/produtos");
                if(produtosDto != null )
                    return produtosDto;

                return Enumerable.Empty<ProdutoDto>();
            }

            catch (Exception)
            {
                _logger.LogError("Erro ao obter Produtos");
                throw;
            }

        }
        public async Task<IEnumerable<CategoriaDto>> BuscaCategorias()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Produtos/BuscarCategorias");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CategoriaDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<CategoriaDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http Status Code - {response.StatusCode} Message - {message}");
                }
            }
            catch (Exception)
            {
                _logger.LogError("Erro ao buscar Categorias");
                throw;
            }
        }

        public async Task<IEnumerable<ProdutoDto>> ObterProdutosFavoritos()
        {
            try
            {
                var produtosFavoritosDto = await _httpClient.GetFromJsonAsync<IEnumerable<ProdutoDto>>
                                           ("api/Produtos/BuscarProdutoFavoritos");

                var retornoProdutosFavoritos = new List<ProdutoDto>();
                if (produtosFavoritosDto != null)
                {
                    foreach (var produtoFavorito in produtosFavoritosDto)
                    {
                        if (produtoFavorito.IsFavorito)
                        {
                            retornoProdutosFavoritos.Add(produtoFavorito);
                        }
                    }
                }

                return retornoProdutosFavoritos;
            }

            catch (Exception)
            {
                _logger.LogError("Erro ao obter Produtos Favoritos");
                throw;
            }
        }

        public async Task<ProdutoDto> ObterUmProduto(Guid Id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/produtos/{Id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return default!;
                    }
                    return await response.Content.ReadFromJsonAsync<ProdutoDto>()
                        ?? null!;
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    _logger.LogError($"Erro a obter produto pelo id= {Id} - {message}");
                    throw new Exception($"Status Code : {response.StatusCode} - {message}");
                }
            }
            catch (Exception)
            {
                _logger.LogError($"Erro a obter produto pelo id={Id}");
                throw;
            }

        }

        public async Task<ProdutoDto> AdicionarNovoProduto(ProdutoDto produtoDto)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/Produtos", produtoDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                    {
                        return new ProdutoDto();
                    }

                    return await response.Content.ReadFromJsonAsync<ProdutoDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"{response.StatusCode} Message -{message}");
                }

            }
            catch (Exception)
            {
                _logger.LogError("Erro ao Adicionar novo Produto");
                throw;
            }

        }

        public async Task AdicionarEstoqueAoProduto(Guid Id, int Quantidade)
        {
            try
            {
                var response = await _httpClient.PutAsync($"api/Produtos/{Id}/{Quantidade}", null);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"Erro ao atualizar produto favorito: {response.ReasonPhrase}");
                    throw new Exception("Erro ao atualizar o estoque do produto.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao atualizar o estoque {ex}");
                throw;
            }
        }

        public async Task AtualizaProdutoFavorito(ProdutoDto produtoDto)
        {
            try
            {
                var response = await _httpClient.PatchAsJsonAsync($"api/Produtos/{produtoDto.Id}/favorito", produtoDto);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"Erro ao atualizar produto favorito: {response.ReasonPhrase}");
                   
                }

            }
            catch (Exception)
            {
                _logger.LogError("Erro ao Adicionar novo Produto");
                throw;
            }
        } 
        
        public async Task AtualizaProdutoFavorito2(ProdutoDto produtoDto)
        {
            try
            {
                var response = await _httpClient.PatchAsJsonAsync($"api/Produtos/{produtoDto.Id}/favorito", produtoDto);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogError($"Erro ao atualizar produto favorito: {response.ReasonPhrase}");
                   
                }

            }
            catch (Exception)
            {
                _logger.LogError("Erro ao Adicionar novo Produto");
                throw;
            }
        }


        public async Task RemoverProduto(Guid Id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"api/produtos/{Id}");
                var responseBody = response.Content.ReadAsStringAsync();

            }
            catch (Exception)
            {
                _logger.LogError($"Erro a deletar produto!");
                throw;
            }

        }

        
    }
}
