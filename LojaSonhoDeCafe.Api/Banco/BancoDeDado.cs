using LojaSonhoDeCafe.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace LojaSonhoDeCafe.Api.Banco
{
    public class BancoDeDado : DbContext
    {
        public BancoDeDado(DbContextOptions<BancoDeDado> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            //Add users
            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = Guid.NewGuid(),
                NomeUsuario = "David"

            });
            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                Id = Guid.NewGuid(),
                NomeUsuario = "Adm"

            });

            //Create Shopping Carrinho for Users
            modelBuilder.Entity<Carrinho>().HasData(new Carrinho
            {
                Id = 1,
                UsuarioId = "1",

            });
            modelBuilder.Entity<Carrinho>().HasData(new Carrinho
            {
                Id = 2,
                UsuarioId = "2",

            });

            modelBuilder.Entity<PagamentoProduto>()
                        .HasOne(pp => pp.PagamentoDiario)
                        .WithMany(pd => pd.PagamentoProdutos)
                        .HasForeignKey(pp => pp.PagamentoDiarioId);

        }

        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Carrinho> Carrinhos { get; set; }

        public DbSet<CarrinhoItem> CarrinhoItens { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<PagamentoDiario> PagamentosDiarios { get; set; }

        public DbSet<PagamentoProduto> PagamentoProdutos { get; set; }

    }
}
