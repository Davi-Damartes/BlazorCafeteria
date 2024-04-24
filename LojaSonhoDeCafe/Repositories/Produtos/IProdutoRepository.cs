using LojaSonhoDeCafe.Entities;
using LojaSonhoDeCafe.Models.Dtos;

namespace LojaSonhoDeCafe.Repositories.Produtos
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> ObterTodosOsProdutos();
        Task<Produto> ObterProdutoPorId(Guid Id);

        Task<IEnumerable<Produto>> ObterTodosProdutosPorCategoria(int id);

        Task<IEnumerable<Categoria>> ObterCategorias( );

        Task AdicionarNovoProdutoDto(ProdutoDto produto);

        Task AtualizaProduto(ProdutoDto produtoDto);

    }
}
