using Blazored.LocalStorage;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Services.ProdutoServices;

namespace LojaSonhoDeCafe.Services.ProdutosLocalStorage
{
    public class LocalStorageProdutosService : ILocalStorageProdutosService
    {
        private const string Key = "ProdutoCollection";

        private readonly IProdutoService _produtoService;
        private readonly ILocalStorageService _localStorageService;

        public LocalStorageProdutosService(IProdutoService produtoService,
                                           ILocalStorageService localStorageService)
        {
            _produtoService = produtoService;
            _localStorageService = localStorageService;
        }



        public async Task AtualizarDadosLocalStorage(IEnumerable<ProdutoDto> novosDados)
        {
            try
            {
                // Armazenar os novos dados no LocalStorage
                await _localStorageService.SetItemAsync<IEnumerable<ProdutoDto>>(Key, novosDados);
            }
            catch (Exception)
            {
                // Lidar com qualquer erro de armazenamento
                throw;
            }
        }

        private async Task<IEnumerable<ProdutoDto>> AddCollection( )
        {
            var listaProdutos = await _produtoService.ObterProdutos();
            if (listaProdutos != null)
            {
                await _localStorageService.SetItemAsync(Key, listaProdutos ?? Enumerable.Empty<ProdutoDto>());
            }

            return listaProdutos ?? Enumerable.Empty<ProdutoDto>();
        }

        public async Task RemoveCollection( )
        {
            await _localStorageService.RemoveItemAsync(Key);
        }
        public async Task<IEnumerable<ProdutoDto>> GetCollection( )
        {
            return await _localStorageService
                                            .GetItemAsync<IEnumerable<ProdutoDto>>(Key)
                                                                ??
                                            await AddCollection();
        }
    }
}
