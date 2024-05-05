using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LojaSonhoDeCafe.Migrations.BancoDeDadosMigrations
{
    /// <inheritdoc />
    public partial class AddClassePagamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("0472a8ce-a0d1-4e50-b5ab-2558e0ebc5b3"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("088c3526-9433-4575-af4a-7aa858c9b51d"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("2b5b4810-4fe7-429d-8027-946b0ef5cdcf"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("4f10f58e-c775-4fa9-97da-7c759df290c9"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("4fb4b936-0308-4352-a856-02afdacc9518"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("5fc4cff6-aa99-46b7-b17e-c88cf66e2ac0"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("6f94c576-6287-483f-b7c2-e1ce7bc77420"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("b9d8b895-059f-4bfc-b763-e24cd369ea22"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("c0409de3-30c9-41aa-96e3-3b2bed3abb82"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("ec630299-52ec-4b32-9739-0f0c1b4486ba"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("d79ded33-3472-4add-b610-9316dc6a3152"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("e9677fa9-5e4a-4370-9bb5-eceedeeced62"));

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IconeCss", "Nome" },
                values: new object[] { "fa-solid fa-wine-glass", "Bebidas" });

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "IconeCss",
                value: "fa-solid fa-bread-slice");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "IconeCss",
                value: "fa-solid fa-cake-candles");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4,
                column: "IconeCss",
                value: "fa-solid fa-burger");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Carrinhos",
                columns: new[] { "Id", "UsuarioId" },
                values: new object[,]
                {
                    { 1, "1" },
                    { 2, "2" }
                });

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "IconeCss", "Nome" },
                values: new object[] { "fa-coffee", "Cafés" });

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 2,
                column: "IconeCss",
                value: "fa-cookie");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 3,
                column: "IconeCss",
                value: "fa-birthday-cake");

            migrationBuilder.UpdateData(
                table: "Categorias",
                keyColumn: "Id",
                keyValue: 4,
                column: "IconeCss",
                value: "fa-hamburger");

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CategoriaId", "Descricao", "FotoUrl", "IsFavorito", "Nome", "Preco", "QuantidadeEmEstoque" },
                values: new object[,]
                {
                    { new Guid("0472a8ce-a0d1-4e50-b5ab-2558e0ebc5b3"), 1, "Café suave e cremoso, feito com leite vaporizado.", "/Imagens/Cafes/latte.jpg", false, "Café Latte", 4.00m, 80 },
                    { new Guid("088c3526-9433-4575-af4a-7aa858c9b51d"), 4, "Sanduíche fresco com frango grelhado e cream cheese.", "/Imagens/Lanches/sanduiche_frango.jpg", false, "Sanduíche de Frango com Cream Cheese", 8.00m, 50 },
                    { new Guid("2b5b4810-4fe7-429d-8027-946b0ef5cdcf"), 3, "Torta cremosa de limão com uma base crocante.", "/Imagens/Doces/torta_limao.jpg", false, "Torta de Limão", 7.00m, 40 },
                    { new Guid("4f10f58e-c775-4fa9-97da-7c759df290c9"), 4, "Baguete recheada com presunto, queijo e vegetais frescos.", "/Imagens/Lanches/baguete.jpg", false, "Baguete de Presunto e Queijo", 7.50m, 40 },
                    { new Guid("4fb4b936-0308-4352-a856-02afdacc9518"), 1, "Café cremoso com uma generosa camada de espuma de leite e canela por cima.", "/Imagens/Cafes/capuccino.jpg", false, "Café Capuccino", 4.50m, 70 },
                    { new Guid("5fc4cff6-aa99-46b7-b17e-c88cf66e2ac0"), 2, "Pão de queijo quentinho e delicioso.", "/Imagens/Salgados/pao_queijo.jpg", false, "Pão de Queijo", 3.00m, 70 },
                    { new Guid("6f94c576-6287-483f-b7c2-e1ce7bc77420"), 3, "Bolo de cenoura macio coberto com ganache de chocolate.", "/Imagens/Doces/bolo_cenoura.jpg", false, "Bolo de Cenoura com Chocolate", 6.50m, 30 },
                    { new Guid("b9d8b895-059f-4bfc-b763-e24cd369ea22"), 1, "Café forte e encorpado, ideal para quem gosta de um sabor intenso.", "/Imagens/Cafes/espresso.jpg", false, "Café Espresso", 3.50m, 100 },
                    { new Guid("c0409de3-30c9-41aa-96e3-3b2bed3abb82"), 2, "Croissant recheado com queijo derretido.", "/Imagens/Salgados/croissant_queijo.jpg", false, "Croissant de Queijo", 5.00m, 60 },
                    { new Guid("ec630299-52ec-4b32-9739-0f0c1b4486ba"), 2, "Coxinha deliciosa e crocante.", "/Imagens/Salgados/coxinha_de_frango.jpg", false, "Coxinha de Frango", 3.00m, 70 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CarrinhoId", "NomeUsuario" },
                values: new object[,]
                {
                    { new Guid("d79ded33-3472-4add-b610-9316dc6a3152"), null, "Janice" },
                    { new Guid("e9677fa9-5e4a-4370-9bb5-eceedeeced62"), null, "Macoratti" }
                });
        }
    }
}
