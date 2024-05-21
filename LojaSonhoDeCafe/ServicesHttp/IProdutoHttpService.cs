using LojaSonhoDeCafe.Models.Dtos;

namespace LojaSonhoDeCafe.Services.Produto2Services
{
    public interface IProdutoHttpService
    {
        Task<IEnumerable<ProdutoDto>> ObterProdutos();

        Task<IEnumerable<ProdutoDto>> ObterProdutosFavoritos();

        Task<ProdutoDto> ObterUmProduto(Guid Id);

        Task<IEnumerable<CategoriaDto>> BuscaCategorias();

        Task<IEnumerable<ProdutoDto>> BuscarItensPorCategoria(int categoriaId);

        Task<ProdutoDto> AdicionarNovoProduto(ProdutoDto produto);

        //Task AtualizaProdutoService(ProdutoDto produtoDto);

        Task RemoverProduto(Guid Id);



    }
}
