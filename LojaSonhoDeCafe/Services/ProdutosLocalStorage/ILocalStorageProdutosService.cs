using LojaSonhoDeCafe.Models.Dtos;

namespace LojaSonhoDeCafe.Services.ProdutosLocalStorage
{
    public interface ILocalStorageProdutosService
    {
        Task<IEnumerable<ProdutoDto>> GetCollection();

        Task RemoveCollection();
    }
}
