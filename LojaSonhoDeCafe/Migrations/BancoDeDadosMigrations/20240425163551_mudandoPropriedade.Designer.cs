﻿// <auto-generated />
using System;
using LojaSonhoDeCafe.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LojaSonhoDeCafe.Migrations.BancoDeDadosMigrations
{
    [DbContext(typeof(BancoDeDados))]
    [Migration("20240425163551_mudandoPropriedade")]
    partial class mudandoPropriedade
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LojaSonhoDeCafe.Entities.Carrinho", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("UsuarioId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Carrinhos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UsuarioId = "1"
                        },
                        new
                        {
                            Id = 2,
                            UsuarioId = "2"
                        });
                });

            modelBuilder.Entity("LojaSonhoDeCafe.Entities.CarrinhoItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarrinhoId")
                        .HasColumnType("int");

                    b.Property<Guid>("ProdutoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarrinhoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("CarrinhoItens");
                });

            modelBuilder.Entity("LojaSonhoDeCafe.Entities.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IconeCss")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IconeCss = "fa-coffee",
                            Nome = "Cafés"
                        },
                        new
                        {
                            Id = 2,
                            IconeCss = "fa-cookie",
                            Nome = "Salgados"
                        },
                        new
                        {
                            Id = 3,
                            IconeCss = "fa-birthday-cake",
                            Nome = "Doces"
                        },
                        new
                        {
                            Id = 4,
                            IconeCss = "fa-hamburger",
                            Nome = "Lanches"
                        });
                });

            modelBuilder.Entity("LojaSonhoDeCafe.Entities.Produto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Descricao")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FotoUrl")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsFavorito")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<int>("QuantidadeEmEstoque")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Produtos");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b9d8b895-059f-4bfc-b763-e24cd369ea22"),
                            CategoriaId = 1,
                            Descricao = "Café forte e encorpado, ideal para quem gosta de um sabor intenso.",
                            FotoUrl = "/Imagens/Cafes/espresso.jpg",
                            IsFavorito = false,
                            Nome = "Café Espresso",
                            Preco = 3.50m,
                            QuantidadeEmEstoque = 100
                        },
                        new
                        {
                            Id = new Guid("0472a8ce-a0d1-4e50-b5ab-2558e0ebc5b3"),
                            CategoriaId = 1,
                            Descricao = "Café suave e cremoso, feito com leite vaporizado.",
                            FotoUrl = "/Imagens/Cafes/latte.jpg",
                            IsFavorito = false,
                            Nome = "Café Latte",
                            Preco = 4.00m,
                            QuantidadeEmEstoque = 80
                        },
                        new
                        {
                            Id = new Guid("4fb4b936-0308-4352-a856-02afdacc9518"),
                            CategoriaId = 1,
                            Descricao = "Café cremoso com uma generosa camada de espuma de leite e canela por cima.",
                            FotoUrl = "/Imagens/Cafes/capuccino.jpg",
                            IsFavorito = false,
                            Nome = "Café Capuccino",
                            Preco = 4.50m,
                            QuantidadeEmEstoque = 70
                        },
                        new
                        {
                            Id = new Guid("c0409de3-30c9-41aa-96e3-3b2bed3abb82"),
                            CategoriaId = 2,
                            Descricao = "Croissant recheado com queijo derretido.",
                            FotoUrl = "/Imagens/Salgados/croissant_queijo.jpg",
                            IsFavorito = false,
                            Nome = "Croissant de Queijo",
                            Preco = 5.00m,
                            QuantidadeEmEstoque = 60
                        },
                        new
                        {
                            Id = new Guid("5fc4cff6-aa99-46b7-b17e-c88cf66e2ac0"),
                            CategoriaId = 2,
                            Descricao = "Pão de queijo quentinho e delicioso.",
                            FotoUrl = "/Imagens/Salgados/pao_queijo.jpg",
                            IsFavorito = false,
                            Nome = "Pão de Queijo",
                            Preco = 3.00m,
                            QuantidadeEmEstoque = 70
                        },
                        new
                        {
                            Id = new Guid("ec630299-52ec-4b32-9739-0f0c1b4486ba"),
                            CategoriaId = 2,
                            Descricao = "Coxinha deliciosa e crocante.",
                            FotoUrl = "/Imagens/Salgados/coxinha_de_frango.jpg",
                            IsFavorito = false,
                            Nome = "Coxinha de Frango",
                            Preco = 3.00m,
                            QuantidadeEmEstoque = 70
                        },
                        new
                        {
                            Id = new Guid("6f94c576-6287-483f-b7c2-e1ce7bc77420"),
                            CategoriaId = 3,
                            Descricao = "Bolo de cenoura macio coberto com ganache de chocolate.",
                            FotoUrl = "/Imagens/Doces/bolo_cenoura.jpg",
                            IsFavorito = false,
                            Nome = "Bolo de Cenoura com Chocolate",
                            Preco = 6.50m,
                            QuantidadeEmEstoque = 30
                        },
                        new
                        {
                            Id = new Guid("2b5b4810-4fe7-429d-8027-946b0ef5cdcf"),
                            CategoriaId = 3,
                            Descricao = "Torta cremosa de limão com uma base crocante.",
                            FotoUrl = "/Imagens/Doces/torta_limao.jpg",
                            IsFavorito = false,
                            Nome = "Torta de Limão",
                            Preco = 7.00m,
                            QuantidadeEmEstoque = 40
                        },
                        new
                        {
                            Id = new Guid("088c3526-9433-4575-af4a-7aa858c9b51d"),
                            CategoriaId = 4,
                            Descricao = "Sanduíche fresco com frango grelhado e cream cheese.",
                            FotoUrl = "/Imagens/Lanches/sanduiche_frango.jpg",
                            IsFavorito = false,
                            Nome = "Sanduíche de Frango com Cream Cheese",
                            Preco = 8.00m,
                            QuantidadeEmEstoque = 50
                        },
                        new
                        {
                            Id = new Guid("4f10f58e-c775-4fa9-97da-7c759df290c9"),
                            CategoriaId = 4,
                            Descricao = "Baguete recheada com presunto, queijo e vegetais frescos.",
                            FotoUrl = "/Imagens/Lanches/baguete.jpg",
                            IsFavorito = false,
                            Nome = "Baguete de Presunto e Queijo",
                            Preco = 7.50m,
                            QuantidadeEmEstoque = 40
                        });
                });

            modelBuilder.Entity("LojaSonhoDeCafe.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("CarrinhoId")
                        .HasColumnType("int");

                    b.Property<string>("NomeUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CarrinhoId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e9677fa9-5e4a-4370-9bb5-eceedeeced62"),
                            NomeUsuario = "Macoratti"
                        },
                        new
                        {
                            Id = new Guid("d79ded33-3472-4add-b610-9316dc6a3152"),
                            NomeUsuario = "Janice"
                        });
                });

            modelBuilder.Entity("LojaSonhoDeCafe.Entities.CarrinhoItem", b =>
                {
                    b.HasOne("LojaSonhoDeCafe.Entities.Carrinho", "Carrinho")
                        .WithMany("Itens")
                        .HasForeignKey("CarrinhoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LojaSonhoDeCafe.Entities.Produto", "Produto")
                        .WithMany("Itens")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carrinho");

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("LojaSonhoDeCafe.Entities.Produto", b =>
                {
                    b.HasOne("LojaSonhoDeCafe.Entities.Categoria", "Categoria")
                        .WithMany("Produtos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("LojaSonhoDeCafe.Entities.Usuario", b =>
                {
                    b.HasOne("LojaSonhoDeCafe.Entities.Carrinho", "Carrinho")
                        .WithMany()
                        .HasForeignKey("CarrinhoId");

                    b.Navigation("Carrinho");
                });

            modelBuilder.Entity("LojaSonhoDeCafe.Entities.Carrinho", b =>
                {
                    b.Navigation("Itens");
                });

            modelBuilder.Entity("LojaSonhoDeCafe.Entities.Categoria", b =>
                {
                    b.Navigation("Produtos");
                });

            modelBuilder.Entity("LojaSonhoDeCafe.Entities.Produto", b =>
                {
                    b.Navigation("Itens");
                });
#pragma warning restore 612, 618
        }
    }
}
