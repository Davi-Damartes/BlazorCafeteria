using Blazored.LocalStorage;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Services.ProdutoServices;
using LojaSonhoDeCafe.ServicesHttp.ProdutosHttpService;

namespace LojaSonhoDeCafe.ServicesHttp.ProdutosLocalStorage
{
    public class LocalStorageProdutosService : ILocalStorageProdutosService
    {
        private const string Key = "ProdutoCollection";

        private readonly IProdutoHttpService _produtoHttpService;
        private readonly ILocalStorageService _localStorageService;
        public LocalStorageProdutosService(IProdutoService produtoService,
                                           ILocalStorageService localStorageService,
                                           IProdutoHttpService produtoHttpService)
        {
            _localStorageService = localStorageService;
            _produtoHttpService = produtoHttpService;
        }

        public async Task AtualizarDadosLocalStorage(IEnumerable<ProdutoDto> novosDados)
        {
            try
            {
                // Armazenar os novos dados no LocalStorage
                await _localStorageService.SetItemAsync(Key, novosDados);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<ProdutoDto>> GetCollection()
        {
            return await _localStorageService.GetItemAsync<IEnumerable<ProdutoDto>>(Key)
                                                                ??
                                                          await AddCollection();
        }
        public async Task RemoveCollection()
        {
            await _localStorageService.RemoveItemAsync(Key);
        }
        private async Task<IEnumerable<ProdutoDto>> AddCollection()
        {
            var listaProdutos = await _produtoHttpService.ObterProdutos();
            if (listaProdutos != null)
            {
                await _localStorageService.SetItemAsync(Key, listaProdutos);
            }

            return listaProdutos!;
        }

    }
}
