using LojaSonhoDeCafe.Models.Dtos;

namespace LojaSonhoDeCafe.ServicesHttp.ProdutosLocalStorage
{
    public interface ILocalStorageProdutosService
    {
        Task<IEnumerable<ProdutoDto>> GetCollection();

        Task AtualizarDadosLocalStorage(IEnumerable<ProdutoDto> novosDados);

        Task RemoveCollection();
    }
}
