using LojaSonhoDeCafe.Data;
using LojaSonhoDeCafe.Entities;
using LojaSonhoDeCafe.Repositories.Produtos;
using Microsoft.EntityFrameworkCore;

namespace SonhoDeCafe.Server.Repositories.Produtos
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly BancoDeDados _bancoDeDados;
        public ProdutoRepository(BancoDeDados bancoDeDados)
        {
            _bancoDeDados = bancoDeDados;
        }
      
        public async Task<Produto> ObterProdutoPorId(Guid Id)
        {
            var produto = await _bancoDeDados
                                .Produtos
                                .Include(a => a.Categoria)
                                .FirstOrDefaultAsync(x => x.Id == Id);

            if (produto == null)
            {
                return null!;
            }

            return produto;
        }

        public async Task<IEnumerable<Produto>> ObterTodosOsProdutos( )
        {
            var produtos = await _bancoDeDados
                                .Produtos
                                .Include(a => a.Categoria)
                                .ToListAsync();

            if (produtos == null)
            {
                return Enumerable.Empty<Produto>();
            }

            return produtos;
        }

        public async Task<IEnumerable<Produto>> ObterTodosProdutosPorCategoria(int id)
        {
            var produtos = await _bancoDeDados
                              .Produtos
                              .Include(a => a.Categoria)
                              .Where(x => x.CategoriaId == id)
                              .ToListAsync();

            return produtos;
        }

        public async Task<IEnumerable<Categoria>> ObterCategorias( )
        {
            var categorias = await _bancoDeDados.Categorias.ToListAsync();

            return categorias;
        }
    }
}
