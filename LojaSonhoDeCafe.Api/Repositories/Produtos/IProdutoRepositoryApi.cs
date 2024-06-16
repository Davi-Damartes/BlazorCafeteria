using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;

namespace LojaSonhoDeCafe.Api.Repositories.Produtos
{
    public interface IProdutoRepositoryApi
    {
        Task<IEnumerable<Produto>> ObterTodosOsProdutos();

        Task<Produto> ObterProdutoPorId(Guid Id);

        Task<IEnumerable<Produto>> ObterTodosProdutosPorCategoria(int id);

        Task<IEnumerable<Produto>> ObterProdutosFavoritos();

        Task<IEnumerable<Categoria>> ObterCategorias();

        Task AdicionarNovoProduto(Produto produto);

        Task AdicionarEstoqueAoProduto(Guid Id, int Quantidade);

        Task AtualizaProdutoFavorito(Guid produtoId);

        Task ExcluirProduto(Guid Id);



    }
}
