using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LojaSonhoDeCafe.Migrations.BancoDeDadosMigrations
{
    /// <inheritdoc />
    public partial class AdicionandoDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carrinhos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinhos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IconeCss = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeUsuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CarrinhoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Carrinhos_CarrinhoId",
                        column: x => x.CarrinhoId,
                        principalTable: "Carrinhos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    FotoUrl = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Preco = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    QuantidadeEmEstoque = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarrinhoItens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarrinhoId = table.Column<int>(type: "int", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhoItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarrinhoItens_Carrinhos_CarrinhoId",
                        column: x => x.CarrinhoId,
                        principalTable: "Carrinhos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarrinhoItens_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Carrinhos",
                columns: new[] { "Id", "UsuarioId" },
                values: new object[,]
                {
                    { 1, "1" },
                    { 2, "2" }
                });

            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "Id", "IconeCss", "Nome" },
                values: new object[,]
                {
                    { 1, "fa-coffee", "Cafés" },
                    { 2, "fa-cookie", "Salgados" },
                    { 3, "fa-birthday-cake", "Doces" },
                    { 4, "fa-hamburger", "Lanches" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CarrinhoId", "NomeUsuario" },
                values: new object[,]
                {
                    { new Guid("619adf24-e943-4f2a-8f89-c942d8fc53dd"), null, "Macoratti" },
                    { new Guid("8278e20b-e3e6-4926-bc26-ca54112b4645"), null, "Janice" }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CategoriaId", "Descricao", "FotoUrl", "Nome", "Preco", "QuantidadeEmEstoque" },
                values: new object[,]
                {
                    { new Guid("3323d5d3-c06a-4ed7-8e2e-992ee7ef8790"), 1, "Café cremoso com uma generosa camada de espuma de leite e canela por cima.", "/Imagens/Cafes/capuccino.jpg", "Café Capuccino", 4.50m, 70 },
                    { new Guid("34fdf30d-1a0d-4597-b667-52625d6b70a4"), 1, "Café forte e encorpado, ideal para quem gosta de um sabor intenso.", "/Imagens/Cafes/espresso.jpg", "Café Espresso", 3.50m, 100 },
                    { new Guid("406f24e0-4768-452a-83f9-e88910d06591"), 3, "Torta cremosa de limão com uma base crocante.", "/Imagens/Doces/torta_limao.jpg", "Torta de Limão", 7.00m, 40 },
                    { new Guid("58e04c01-380d-475b-af2e-8edb34d4daec"), 2, "Coxinha deliciosa e crocante.", "/Imagens/Salgados/coxinha_de_frango.jpg", "Coxinha de Frango", 3.00m, 70 },
                    { new Guid("78f24136-996f-4a3b-9623-cc68948e2915"), 4, "Sanduíche fresco com frango grelhado e cream cheese.", "/Imagens/Lanches/sanduiche_frango.jpg", "Sanduíche de Frango com Cream Cheese", 8.00m, 50 },
                    { new Guid("792d7b55-f575-4cd6-a601-39f293472c03"), 2, "Croissant recheado com queijo derretido.", "/Imagens/Salgados/croissant_queijo.jpg", "Croissant de Queijo", 5.00m, 60 },
                    { new Guid("7955c423-3c43-4467-aabc-82de749ea274"), 2, "Pão de queijo quentinho e delicioso.", "/Imagens/Salgados/pao_queijo.jpg", "Pão de Queijo", 3.00m, 70 },
                    { new Guid("db2bda1e-492c-4ad9-a5c9-03a2d1eca78b"), 1, "Café suave e cremoso, feito com leite vaporizado.", "/Imagens/Cafes/latte.jpg", "Café Latte", 4.00m, 80 },
                    { new Guid("ddbf3619-8281-40f3-bb7c-d08f1ea25816"), 4, "Baguete recheada com presunto, queijo e vegetais frescos.", "/Imagens/Lanches/baguete.jpg", "Baguete de Presunto e Queijo", 7.50m, 40 },
                    { new Guid("e1795112-d1c6-4957-8f51-e00fcc81bb60"), 3, "Bolo de cenoura macio coberto com ganache de chocolate.", "/Imagens/Doces/bolo_cenoura.jpg", "Bolo de Cenoura com Chocolate", 6.50m, 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoItens_CarrinhoId",
                table: "CarrinhoItens",
                column: "CarrinhoId");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhoItens_ProdutoId",
                table: "CarrinhoItens",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CarrinhoId",
                table: "Usuarios",
                column: "CarrinhoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarrinhoItens");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Carrinhos");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
