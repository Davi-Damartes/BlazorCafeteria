using LojaSonhoDeCafe.Models.Dtos;

namespace LojaSonhoDeCafe.Services.CarrinhoLocalStorage
{
    public interface ILocalStorageCarrinhoItensService
    {
        Task <List<CarrinhoItemDto>> GetCollection();
        Task SaveCollection(List<CarrinhoItemDto> carrinhoItemDtos);
        Task RemoveCollection();
    }
}
