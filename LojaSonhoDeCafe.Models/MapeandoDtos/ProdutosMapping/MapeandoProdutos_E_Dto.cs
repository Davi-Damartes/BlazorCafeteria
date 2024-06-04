using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;

namespace LojaSonhoDeCafe.Models.MapeandoDtos.ProdutosMapping
{
    public static class MapeandoDto
    {
        public static IEnumerable<CategoriaDto> ConverterCategoriasParaDto(
                                           this IEnumerable<Categoria> categorias)
        {
            return (from categoria in categorias
                    select new CategoriaDto
                    {
                        Id = categoria.Id,
                        Nome = categoria.Nome,
                        IconeCss = categoria.IconeCss
                    }).ToList();
        }

        public static IEnumerable<ProdutoDto> ConvertProdutosParaDto(this IEnumerable<Produto> produtos)
        {
            return (from produto in produtos
                    select new ProdutoDto
                    {
                        Id = produto.Id,
                        Nome = produto.Nome,
                        Descricao = produto.Descricao,
                        FotoUrl = produto.FotoUrl,
                        Preco = produto.Preco,
                        QuantidadeEmEstoque = produto.QuantidadeEmEstoque,
                        IsFavorito = produto.IsFavorito,
                        CategoriaId = produto.CategoriaId,
                        CategoriaNome = produto.Categoria.Nome
                    }).ToList();

        }

        public static ProdutoDto ConvertProdutoParaDto(this Produto produto)
        {
            return new ProdutoDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                FotoUrl = produto.FotoUrl,
                Preco = produto.Preco,
                QuantidadeEmEstoque = produto.QuantidadeEmEstoque,
                IsFavorito = produto.IsFavorito,
                CategoriaId = produto.Categoria.Id,
                CategoriaNome = produto.Categoria.Nome
            };
        }
        public static Produto ConvertProdutoDtoParaProduto(this ProdutoDto produtoDto)
        {
            return new Produto
            {
                    Id = produtoDto.Id,
                    Nome = produtoDto.Nome,
                    Descricao = produtoDto.Descricao,
                    FotoUrl = produtoDto.FotoUrl,
                    Preco = produtoDto.Preco,
                    QuantidadeEmEstoque = produtoDto.QuantidadeEmEstoque,
                    IsFavorito = produtoDto.IsFavorito,
                    CategoriaId = produtoDto.CategoriaId,
                    Categoria = produtoDto.CategoriaNome != null ? new Categoria { Id = produtoDto.CategoriaId, Nome = produtoDto.CategoriaNome } : null
            
            };
        }

        public static IEnumerable<CarrinhoItemDto> ConverterCarrinhoItensParaDto(
        this IEnumerable<CarrinhoItem> carrinhoItens, IEnumerable<Produto> produtos)
        {
            return (from carrinhoItem in carrinhoItens
                    join produto in produtos
                    on carrinhoItem.ProdutoId equals produto.Id
                    select new CarrinhoItemDto
                    {
                        Id = carrinhoItem.Id,
                        ProdutoId = carrinhoItem.ProdutoId,
                        ProdutoNome = produto.Nome,
                        ProdutoDescricao = produto.Descricao,
                        ProdutoFotoUrl = produto.FotoUrl,
                        Preco = produto.Preco,
                        CarrinhoId = carrinhoItem.CarrinhoId,
                        Quantidade = carrinhoItem.Quantidade,
                        QuantidadeEmEstoque = produto.QuantidadeEmEstoque,
                        PrecoTotal = produto.Preco * carrinhoItem.Quantidade
                    }).ToList();
        }

        public static CarrinhoItemDto ConverterCarrinhoItemParaDto(this CarrinhoItem carrinhoItem,
                                            Produto produto)
        {
            return new CarrinhoItemDto
            {
                Id = carrinhoItem.Id,
                ProdutoId = carrinhoItem.ProdutoId,
                ProdutoNome = produto.Nome,
                ProdutoDescricao = produto.Descricao,
                ProdutoFotoUrl = produto.FotoUrl,
                Preco = produto.Preco,
                CarrinhoId = carrinhoItem.CarrinhoId,
                Quantidade = carrinhoItem.Quantidade,
                PrecoTotal = produto.Preco * carrinhoItem.Quantidade
            };
        }

        public static CarrinhoItemDto ConverteCarrinhoItemParaCarrinhoDto(this CarrinhoItem carrinhoItem,
                                                                            Produto produto)
        {
            return new CarrinhoItemDto
            {
                Id = carrinhoItem.Id,
                CarrinhoId = carrinhoItem.CarrinhoId,
                ProdutoId = carrinhoItem.ProdutoId,
                Quantidade = carrinhoItem.Quantidade,
                ProdutoNome = produto?.Nome,
                ProdutoDescricao = produto?.Descricao,
                ProdutoFotoUrl = produto?.FotoUrl,
                Preco = produto!.Preco,
                PrecoTotal = (produto?.Preco ?? 0) * carrinhoItem.Quantidade
            };
        }

    }
}
