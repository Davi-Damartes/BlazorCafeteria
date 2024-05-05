using LojaSonhoDeCafe.Entities;
using Microsoft.EntityFrameworkCore;

namespace LojaSonhoDeCafe.Data
{
    public class BancoDeDados : DbContext
    {
        public BancoDeDados(DbContextOptions<BancoDeDados> options ) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Produto>().HasData(
            //    // Produtos da categoria "Cafés"
            //    new Produto
            //    {                   
            //        Nome = "Café Espresso",
            //        Descricao = "Café forte e encorpado, ideal para quem gosta de um sabor intenso.",
            //        FotoUrl = "/Imagens/Cafes/espresso.jpg",
            //        Preco = 3.50m,
            //        QuantidadeEmEstoque = 100,
            //        CategoriaId = 1
            //    },
            //    new Produto
            //    {                  
            //        Nome = "Café Latte",
            //        Descricao = "Café suave e cremoso, feito com leite vaporizado.",
            //        FotoUrl = "/Imagens/Cafes/latte.jpg",
            //        Preco = 4.00m,
            //        QuantidadeEmEstoque = 80,
            //        CategoriaId = 1
            //    },
            //     new Produto
            //     {
            //         Nome = "Café Capuccino",
            //         Descricao = "Café cremoso com uma generosa camada de espuma de leite e canela por cima.",
            //         FotoUrl = "/Imagens/Cafes/capuccino.jpg",
            //         Preco = 4.50m,
            //         QuantidadeEmEstoque = 70,
            //         CategoriaId = 1 // Categoria de Cafés
            //     });

            //modelBuilder.Entity<Produto>().HasData(
            //    // Produtos da categoria "Salgados"
            //    new Produto
            //    {           
            //        Nome = "Croissant de Queijo",
            //        Descricao = "Croissant recheado com queijo derretido.",
            //        FotoUrl = "/Imagens/Salgados/croissant_queijo.jpg",
            //        Preco = 5.00m,
            //        QuantidadeEmEstoque = 60,
            //        CategoriaId = 2
            //    },
            //    new Produto
            //    {

            //        Nome = "Pão de Queijo",
            //        Descricao = "Pão de queijo quentinho e delicioso.",
            //        FotoUrl = "/Imagens/Salgados/pao_queijo.jpg",
            //        Preco = 3.00m,
            //        QuantidadeEmEstoque = 70,
            //        CategoriaId = 2
            //    },
            //     new Produto
            //     {

            //         Nome = "Coxinha de Frango",
            //         Descricao = "Coxinha deliciosa e crocante.",
            //         FotoUrl = "/Imagens/Salgados/coxinha_de_frango.jpg",
            //         Preco = 3.00m,
            //         QuantidadeEmEstoque = 70,
            //         CategoriaId = 2
            //     });

            //    modelBuilder.Entity<Produto>().HasData(
            //        // Produtos da categoria "Doces"
            //        new Produto
            //        {

            //            Nome = "Bolo de Cenoura com Chocolate",
            //            Descricao = "Bolo de cenoura macio coberto com ganache de chocolate.",
            //            FotoUrl = "/Imagens/Doces/bolo_cenoura.jpg",
            //            Preco = 6.50m,
            //            QuantidadeEmEstoque = 30,
            //            CategoriaId = 3
            //        },
            //        new Produto
            //        {

            //            Nome = "Torta de Limão",
            //            Descricao = "Torta cremosa de limão com uma base crocante.",
            //            FotoUrl = "/Imagens/Doces/torta_limao.jpg",
            //            Preco = 7.00m,
            //            QuantidadeEmEstoque = 40,
            //            CategoriaId = 3
            //        });

            //    modelBuilder.Entity<Produto>().HasData(
            //        // Produtos da categoria "Lanches"
            //        new Produto
            //        {

            //            Nome = "Sanduíche de Frango com Cream Cheese",
            //            Descricao = "Sanduíche fresco com frango grelhado e cream cheese.",
            //            FotoUrl = "/Imagens/Lanches/sanduiche_frango.jpg",
            //            Preco = 8.00m,
            //            QuantidadeEmEstoque = 50,
            //            CategoriaId = 4
            //        },
            //        new Produto
            //        {

            //            Nome = "Baguete de Presunto e Queijo",
            //            Descricao = "Baguete recheada com presunto, queijo e vegetais frescos.",
            //            FotoUrl = "/Imagens/Lanches/baguete.jpg",
            //            Preco = 7.50m,
            //            QuantidadeEmEstoque = 40,
            //            CategoriaId = 4
            //        });


            //modelBuilder.Entity<Categoria>().HasData(new Categoria
            //{
            //    Id = 1,
            //    Nome = "Bebidas",
            //    IconeCss = "fa-solid fa-wine-glass"
            //});

            //modelBuilder.Entity<Categoria>().HasData(new Categoria
            //{
            //    Id = 2,
            //    Nome = "Salgados",
            //    IconeCss = "fa-solid fa-bread-slice"
            //});

            //modelBuilder.Entity<Categoria>().HasData(new Categoria
            //{
            //    Id = 3,
            //    Nome = "Doces",
            //    IconeCss = "fa-solid fa-cake-candles"
            //});

            //modelBuilder.Entity<Categoria>().HasData(new Categoria
            //{
            //    Id = 4,
            //    Nome = "Lanches",
            //    IconeCss = "fa-solid fa-burger"
            //});

            //         //Add users
            //        modelBuilder.Entity<Usuario>().HasData(new Usuario
            //        {
            //            Id = Guid.NewGuid(),
            //            NomeUsuario = "Macoratti"

            //        });
            //        modelBuilder.Entity<Usuario>().HasData(new Usuario
            //        {
            //            Id = Guid.NewGuid(),
            //            NomeUsuario = "Janice"

            //        });

            //        //Create Shopping Carrinho for Users
            //        modelBuilder.Entity<Carrinho>().HasData(new Carrinho
            //        {
            //            Id = 1,
            //            UsuarioId = "1",

            //        });
            //        modelBuilder.Entity<Carrinho>().HasData(new Carrinho
            //        {
            //            Id = 2,
            //            UsuarioId = "2",

            //        });


            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                Id = 1,
                Nome = "Bebidas",
                IconeCss = "fa-solid fa-wine-glass"
            });

            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                Id = 2,
                Nome = "Salgados",
                IconeCss = "fa-solid fa-bread-slice"
            });

            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                Id = 3,
                Nome = "Doces",
                IconeCss = "fa-solid fa-cake-candles"
            });

            modelBuilder.Entity<Categoria>().HasData(new Categoria
            {
                Id = 4,
                Nome = "Lanches",
                IconeCss = "fa-solid fa-burger"
            });

        }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Carrinho> Carrinhos { get; set; }

        public DbSet<CarrinhoItem> CarrinhoItens { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<PagamentoDiario> PagamentosDiarios { get; set; }


    }
}
