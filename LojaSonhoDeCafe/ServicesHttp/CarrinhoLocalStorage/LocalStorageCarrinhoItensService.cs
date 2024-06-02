using Blazored.LocalStorage;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.ServicesHttp.CarrinhoComprasHttpService;
using SonhoDeCafe.Models;

namespace LojaSonhoDeCafe.ServicesHttp.CarrinhoLocalStorage
{
    public class LocalStorageCarrinhoItensService : ILocalStorageCarrinhoItensService
    {
        private const string Key = "CarrinhoItemCollection";

        private readonly ICarrinhoCompraHttpService _carrinhoHttpCompraService;
        private readonly ILocalStorageService _localStorageService;

        public LocalStorageCarrinhoItensService(
                                                ILocalStorageService localStorageService,
                                                ICarrinhoCompraHttpService carrinhoHttpCompraService)
        {
            _localStorageService = localStorageService;
            _carrinhoHttpCompraService = carrinhoHttpCompraService;
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
            var listaCarrinhoCompra = await _carrinhoHttpCompraService
                                            .ObterItensCarrinho(UsuarioLogado.UsuarioId);

            if (listaCarrinhoCompra != null)
            {
                await _localStorageService.SetItemAsync(Key, listaCarrinhoCompra);

            }
            return listaCarrinhoCompra ?? null!;

        }

    }
}
