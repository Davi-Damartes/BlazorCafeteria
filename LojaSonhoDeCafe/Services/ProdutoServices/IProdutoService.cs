using LojaSonhoDeCafe.Models.Dtos;

namespace LojaSonhoDeCafe.Services.ProdutoServices
{
    public interface IProdutoService
    {
        Task<IEnumerable<ProdutoDto>> ObterProdutos();

        Task<ProdutoDto> ObterUmProduto(Guid Id);

        Task<IEnumerable<CategoriaDto>> BuscarCategorias();

        Task<IEnumerable<ProdutoDto>> BuscarItensPorCategoria(int categoriaId);
        
        Task AdicionarProduto(ProdutoDto produto);
    }
}
