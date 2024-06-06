using LojaSonhoDeCafe.Api.Banco;
using LojaSonhoDeCafe.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace LojaSonhoDeCafe.Test.ProdutoRepositoriesTest
{
    public static class BancoDeDadosRepositorioMock
    {

        private static async Task<BancoDeDado> GetBancoDeDado()
        {
            var options = new DbContextOptionsBuilder<BancoDeDado>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new BancoDeDado(options);
            databaseContext.Database.EnsureCreated();


            if (!await databaseContext.Produtos.AnyAsync()) // Negando a condição
            {
                databaseContext.Add(
                    new Categoria()
                    {
                        Id = 5,
                        Nome = "Bebidas",
                        IconeCss = "Café"
                    }
                 );

                databaseContext.Add(
                    new Categoria()
                    {
                        Id = 6,
                        Nome = "Doce",
                        IconeCss = "Bolo"
                    }
                 );

                databaseContext.Add(
                    new Produto()
                    {
                        Nome = "Calça Jeans",
                        Descricao = "Uma calça jeans clássica",
                        FotoUrl = "http://example.com/calca-jeans.jpg",
                        Preco = 59.99m,
                        QuantidadeEmEstoque = 25,
                        IsFavorito = true,
                        CategoriaId = 1
                    }
                 );
                databaseContext.Add(
                    new Produto()
                    {
                        Nome = "Camisa Polo",
                        Descricao = "Uma camisa polo elegante",
                        FotoUrl = "http://example.com/camisa-polo.jpg",
                        Preco = 39.99m,
                        QuantidadeEmEstoque = 35,
                        IsFavorito = false,
                        CategoriaId = 2
                    }
                );
                databaseContext.Add(
                    new Produto()
                    {
                        Nome = "Tênis Esportivo",
                        Descricao = "Um tênis confortável para atividades físicas",
                        FotoUrl = "http://example.com/tenis-esportivo.jpg",
                        Preco = 79.99m,
                        QuantidadeEmEstoque = 15,
                        IsFavorito = true,
                        CategoriaId = 3
                    }
                );



                await databaseContext.SaveChangesAsync();
            }
            return  databaseContext;
        }
    }

}
