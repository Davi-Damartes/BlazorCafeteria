using LojaSonhoDeCafe.Api.Banco;
using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace LojaSonhoDeCafe.Api.Repositories.Produtos
{
    public class ProdutoRepository2 : IProdutoRepository2
    {
        private readonly BancoDeDado _bancoDeDados;
        public ProdutoRepository2(BancoDeDado bancoDeDados)
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

        public async Task<IEnumerable<Produto>> ObterTodosOsProdutos()
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

        public async Task<IEnumerable<Categoria>> ObterCategorias()
        {
            var categorias = await _bancoDeDados.Categorias.ToListAsync();

            return categorias;
        }

        public async Task<IEnumerable<Produto>> ObterProdutosFavoritos()
        {
            var produtosFavoritos = await _bancoDeDados
                                .Produtos.AsQueryable()
                                .Include(a => a.Categoria)
                                .Where(x => x.IsFavorito == true)
                                .ToListAsync();

            return produtosFavoritos;
               
        }

        public async Task AdicionarNovoProdutoDto(ProdutoDto produtoDto)
        {
            if (await ProdutoIdJaExisteAsync(produtoDto.Id) == false)
            {

                var produto = new Produto
                {
                    Nome = produtoDto.Nome,
                    Descricao = produtoDto.Descricao,
                    FotoUrl = produtoDto.FotoUrl,
                    Preco = produtoDto.Preco,
                    QuantidadeEmEstoque = produtoDto.QuantidadeEmEstoque,
                    IsFavorito = produtoDto.IsFavorito,
                    CategoriaId = produtoDto.CategoriaId
                   
                };

                await _bancoDeDados.Produtos.AddAsync(produto);
                await _bancoDeDados.SaveChangesAsync();

            }

        }

        public async Task AtualizaProdutoFavorito(ProdutoDto produtoDto)
        {
            var produto = await _bancoDeDados.Produtos.SingleOrDefaultAsync(x => x.Id == produtoDto.Id); 
             if(produto != null)
            { 
                produto.IsFavorito = produtoDto.IsFavorito;
                await _bancoDeDados.SaveChangesAsync();
            }
        }


        public async Task ExcluirProduto(Guid Id)
        {
            var produtoExiste = await ProdutoIdJaExisteAsync(Id);

            if (produtoExiste == true)
            {
                var produtoExclusao = await _bancoDeDados
                                            .Produtos
                                            .SingleOrDefaultAsync(x => x.Id == Id);

                _bancoDeDados.Produtos.Remove(produtoExclusao!);
                await _bancoDeDados.SaveChangesAsync();

            }
        }



        public async Task<bool> ProdutoIdJaExisteAsync(Guid produtoId)
        {
            return await _bancoDeDados.Produtos.AnyAsync(p => p.Id == produtoId);
        }

    }
}
