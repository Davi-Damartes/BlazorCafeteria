using LojaSonhoDeCafe.Models.Dtos;

namespace LojaSonhoDeCafe.ServicesHttp.ProdutosHttpService
{
    public interface IProdutoHttpService
    {
        Task<IEnumerable<ProdutoDto>> ObterProdutos();

        Task<IEnumerable<ProdutoDto>> ObterProdutosFavoritos();

        Task<ProdutoDto> ObterUmProduto(Guid Id);

        Task<IEnumerable<CategoriaDto>> BuscaCategorias();

        Task<IEnumerable<ProdutoDto>> BuscarItensPorCategoria(int categoriaId);

        Task<ProdutoDto> AdicionarNovoProduto(ProdutoDto produto);

        Task AdicionarEstoqueAoProduto(Guid Id,int Quantidade);

        Task AtualizaProdutoFavorito(ProdutoDto produtoDto);

        Task RemoverProduto(Guid Id);



    }
}
