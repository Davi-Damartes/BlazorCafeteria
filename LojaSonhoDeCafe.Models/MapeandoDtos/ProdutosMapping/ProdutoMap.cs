using LojaSonhoDeCafe.Models.Dtos;
using LojaSonhoDeCafe.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace LojaSonhoDeCafe.Models.MapeandoDtos.ProdutosMapping
{
    public static class ProdutoMap
    {
        public static ProdutoDto ConverterProdutoParaDto(this Produto produto)
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
        public static Produto ConverterProdutoDtoParaProduto(this ProdutoDto produtoDto)
        {
            return new Produto
            {
                    Nome = produtoDto.Nome,
                    Descricao = produtoDto.Descricao,
                    FotoUrl = produtoDto.FotoUrl,
                    Preco = produtoDto.Preco,
                    QuantidadeEmEstoque = produtoDto.QuantidadeEmEstoque,
                    IsFavorito = produtoDto.IsFavorito,
                    CategoriaId = produtoDto.CategoriaId

            };

        }

        public static IEnumerable<ProdutoDto> ConverterProdutosParaProdutosDto(this IEnumerable<Produto> produtos)
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
        public static IEnumerable<CategoriaDto> ConverterCategoriasParaCategoriasDto(
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


    }
}
