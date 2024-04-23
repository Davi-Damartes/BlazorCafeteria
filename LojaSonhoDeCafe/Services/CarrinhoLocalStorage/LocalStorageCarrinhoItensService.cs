using Blazored.LocalStorage;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Services.CarrinhoCompraServices;
using SonhoDeCafe.Models;

namespace LojaSonhoDeCafe.Services.CarrinhoLocalStorage
{
    public class LocalStorageCarrinhoItensService : ILocalStorageCarrinhoItensService
    {
        private const string Key = "CarrinhoItemCollection";

        private readonly ICarrinhoCompraService _carrinhoCompraService;
        private readonly ILocalStorageService _localStorageService;

        public LocalStorageCarrinhoItensService(ICarrinhoCompraService carrinhoCompraService, 
                                                ILocalStorageService localStorageService)
        {
            _carrinhoCompraService = carrinhoCompraService;
            _localStorageService = localStorageService;
        }

        public async Task<List<CarrinhoItemDto>> GetCollection()
        {
            return await _localStorageService
                                    .GetItemAsync<List<CarrinhoItemDto>>(Key)
                                                    ??
                                    await AddCollection();

        }

        public async Task RemoveCollection()
        {
            await _localStorageService.RemoveItemAsync(Key);
        }

        public async Task SaveCollection(List<CarrinhoItemDto> carrinhoItemDtos)
        {
            await _localStorageService.SetItemAsync(Key, carrinhoItemDtos);
        }


        private async Task<List<CarrinhoItemDto>> AddCollection()
        {
            var listaCarrinhoCompra = await _carrinhoCompraService
                                            .ObterItens(UsuarioLogado.UsuarioId);

            if(listaCarrinhoCompra != null)
            {
                await _localStorageService.SetItemAsync(Key, listaCarrinhoCompra);

            }
            return listaCarrinhoCompra ?? null!;

        }

    }
}
