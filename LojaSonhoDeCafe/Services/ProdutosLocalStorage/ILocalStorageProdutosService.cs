using LojaSonhoDeCafe.Models.Dtos;

namespace LojaSonhoDeCafe.Services.ProdutosLocalStorage
{
    public interface ILocalStorageProdutosService
    {
        Task<IEnumerable<ProdutoDto>> GetCollection();

        Task AtualizarDadosLocalStorage(IEnumerable<ProdutoDto> novosDados);

        Task RemoveCollection();
    }
}
