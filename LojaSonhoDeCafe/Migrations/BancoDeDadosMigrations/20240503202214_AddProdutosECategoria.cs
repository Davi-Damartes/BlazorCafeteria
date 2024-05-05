using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LojaSonhoDeCafe.Migrations.BancoDeDadosMigrations
{
    /// <inheritdoc />
    public partial class AddProdutosECategoria : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    { 1, "fa-solid fa-wine-glass", "Bebidas" },
                    { 2, "fa-solid fa-bread-slice", "Salgados" },
                    { 3, "fa-solid fa-cake-candles", "Doces" },
                    { 4, "fa-solid fa-burger", "Lanches" }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CategoriaId", "Descricao", "FotoUrl", "IsFavorito", "Nome", "Preco", "QuantidadeEmEstoque" },
                values: new object[,]
                {
                    { new Guid("08419a4f-b008-4a1b-bc7f-7de148837a46"), 3, "Torta cremosa de limão com uma base crocante.", "/Imagens/Doces/torta_limao.jpg", false, "Torta de Limão", 7.00m, 40 },
                    { new Guid("566d2f05-4349-4663-a4b4-7f5df8704a7d"), 4, "Baguete recheada com presunto, queijo e vegetais frescos.", "/Imagens/Lanches/baguete.jpg", false, "Baguete de Presunto e Queijo", 7.50m, 40 },
                    { new Guid("615c6791-ca7f-4281-82d7-1ec80d4e54d0"), 1, "Café suave e cremoso, feito com leite vaporizado.", "/Imagens/Cafes/latte.jpg", false, "Café Latte", 4.00m, 80 },
                    { new Guid("756ff978-757d-48ad-8b67-e952d937a636"), 4, "Sanduíche fresco com frango grelhado e cream cheese.", "/Imagens/Lanches/sanduiche_frango.jpg", false, "Sanduíche de Frango com Cream Cheese", 8.00m, 50 },
                    { new Guid("8ac70702-aedd-4ad7-9c85-c23eb54ebec7"), 1, "Café cremoso com uma generosa camada de espuma de leite e canela por cima.", "/Imagens/Cafes/capuccino.jpg", false, "Café Capuccino", 4.50m, 70 },
                    { new Guid("8aee3fde-3726-4e6a-a065-c16be0e32c1e"), 1, "Café forte e encorpado, ideal para quem gosta de um sabor intenso.", "/Imagens/Cafes/espresso.jpg", false, "Café Espresso", 3.50m, 100 },
                    { new Guid("9c337dd7-fa4d-46ea-85c6-be64f9124ddf"), 2, "Pão de queijo quentinho e delicioso.", "/Imagens/Salgados/pao_queijo.jpg", false, "Pão de Queijo", 3.00m, 70 },
                    { new Guid("c1418068-7018-4f74-814a-2cbd2b1f4427"), 3, "Bolo de cenoura macio coberto com ganache de chocolate.", "/Imagens/Doces/bolo_cenoura.jpg", false, "Bolo de Cenoura com Chocolate", 6.50m, 30 },
                    { new Guid("de913187-c5e4-4ff6-ad20-249dd7be9dae"), 2, "Croissant recheado com queijo derretido.", "/Imagens/Salgados/croissant_queijo.jpg", false, "Croissant de Queijo", 5.00m, 60 },
                    { new Guid("e8c1f225-beec-4763-abf6-7057b05b9956"), 2, "Coxinha deliciosa e crocante.", "/Imagens/Salgados/coxinha_de_frango.jpg", false, "Coxinha de Frango", 3.00m, 70 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Carrinhos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Carrinhos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("08419a4f-b008-4a1b-bc7f-7de148837a46"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("566d2f05-4349-4663-a4b4-7f5df8704a7d"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("615c6791-ca7f-4281-82d7-1ec80d4e54d0"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("756ff978-757d-48ad-8b67-e952d937a636"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("8ac70702-aedd-4ad7-9c85-c23eb54ebec7"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("8aee3fde-3726-4e6a-a065-c16be0e32c1e"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("9c337dd7-fa4d-46ea-85c6-be64f9124ddf"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("c1418068-7018-4f74-814a-2cbd2b1f4427"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("de913187-c5e4-4ff6-ad20-249dd7be9dae"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("e8c1f225-beec-4763-abf6-7057b05b9956"));

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
