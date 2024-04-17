using LojaSonhoDeCafe.Entities;

namespace LojaSonhoDeCafe.Repositories.Produtos
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> ObterTodosOsProdutos();
        Task<Produto> ObterProdutoPorId(Guid Id);

        Task<IEnumerable<Produto>> ObterTodosProdutosPorCategoria(int id);

    }
}
