using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LojaSonhoDeCafe.Migrations.BancoDeDadosMigrations
{
    /// <inheritdoc />
    public partial class AdicionandoPropriedadeBooleana : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("3323d5d3-c06a-4ed7-8e2e-992ee7ef8790"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("34fdf30d-1a0d-4597-b667-52625d6b70a4"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("406f24e0-4768-452a-83f9-e88910d06591"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("58e04c01-380d-475b-af2e-8edb34d4daec"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("78f24136-996f-4a3b-9623-cc68948e2915"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("792d7b55-f575-4cd6-a601-39f293472c03"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("7955c423-3c43-4467-aabc-82de749ea274"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("db2bda1e-492c-4ad9-a5c9-03a2d1eca78b"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("ddbf3619-8281-40f3-bb7c-d08f1ea25816"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("e1795112-d1c6-4957-8f51-e00fcc81bb60"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("619adf24-e943-4f2a-8f89-c942d8fc53dd"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("8278e20b-e3e6-4926-bc26-ca54112b4645"));

            migrationBuilder.AddColumn<bool>(
                name: "ProdutoFavorito",
                table: "Produtos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "CategoriaId", "Descricao", "FotoUrl", "Nome", "Preco", "ProdutoFavorito", "QuantidadeEmEstoque" },
                values: new object[,]
                {
                    { new Guid("0a6268f5-2f0b-4bbd-9f85-1f96697589a7"), 3, "Bolo de cenoura macio coberto com ganache de chocolate.", "/Imagens/Doces/bolo_cenoura.jpg", "Bolo de Cenoura com Chocolate", 6.50m, false, 30 },
                    { new Guid("2dad6254-733c-400e-8941-64f083f93e11"), 4, "Sanduíche fresco com frango grelhado e cream cheese.", "/Imagens/Lanches/sanduiche_frango.jpg", "Sanduíche de Frango com Cream Cheese", 8.00m, false, 50 },
                    { new Guid("4b9de137-c721-4673-b814-fd1c1e5745db"), 2, "Croissant recheado com queijo derretido.", "/Imagens/Salgados/croissant_queijo.jpg", "Croissant de Queijo", 5.00m, false, 60 },
                    { new Guid("7d17dec7-db7d-4117-b58d-677a49021127"), 4, "Baguete recheada com presunto, queijo e vegetais frescos.", "/Imagens/Lanches/baguete.jpg", "Baguete de Presunto e Queijo", 7.50m, false, 40 },
                    { new Guid("84a1c72e-38c7-429a-b93c-947c54b0a8ef"), 1, "Café forte e encorpado, ideal para quem gosta de um sabor intenso.", "/Imagens/Cafes/espresso.jpg", "Café Espresso", 3.50m, false, 100 },
                    { new Guid("874ff6fb-7218-4387-b4a1-93507383ea70"), 1, "Café suave e cremoso, feito com leite vaporizado.", "/Imagens/Cafes/latte.jpg", "Café Latte", 4.00m, false, 80 },
                    { new Guid("abad6502-8e02-4a3d-9269-317d4eafad83"), 2, "Pão de queijo quentinho e delicioso.", "/Imagens/Salgados/pao_queijo.jpg", "Pão de Queijo", 3.00m, false, 70 },
                    { new Guid("be516142-59ab-4b24-b69f-0066ddb6c250"), 3, "Torta cremosa de limão com uma base crocante.", "/Imagens/Doces/torta_limao.jpg", "Torta de Limão", 7.00m, false, 40 },
                    { new Guid("dc2f536f-c0e0-450f-812b-e4a3cb153ff9"), 2, "Coxinha deliciosa e crocante.", "/Imagens/Salgados/coxinha_de_frango.jpg", "Coxinha de Frango", 3.00m, false, 70 },
                    { new Guid("ea3e8728-4766-44ce-8856-7aec39a21619"), 1, "Café cremoso com uma generosa camada de espuma de leite e canela por cima.", "/Imagens/Cafes/capuccino.jpg", "Café Capuccino", 4.50m, false, 70 }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CarrinhoId", "NomeUsuario" },
                values: new object[,]
                {
                    { new Guid("5c823f4b-0c6e-4908-b24e-56264a753f50"), null, "Macoratti" },
                    { new Guid("88d41c7b-0e67-4bd2-b6e7-b1bb2a47abe0"), null, "Janice" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("0a6268f5-2f0b-4bbd-9f85-1f96697589a7"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("2dad6254-733c-400e-8941-64f083f93e11"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("4b9de137-c721-4673-b814-fd1c1e5745db"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("7d17dec7-db7d-4117-b58d-677a49021127"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("84a1c72e-38c7-429a-b93c-947c54b0a8ef"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("874ff6fb-7218-4387-b4a1-93507383ea70"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("abad6502-8e02-4a3d-9269-317d4eafad83"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("be516142-59ab-4b24-b69f-0066ddb6c250"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("dc2f536f-c0e0-450f-812b-e4a3cb153ff9"));

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: new Guid("ea3e8728-4766-44ce-8856-7aec39a21619"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("5c823f4b-0c6e-4908-b24e-56264a753f50"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("88d41c7b-0e67-4bd2-b6e7-b1bb2a47abe0"));

            migrationBuilder.DropColumn(
                name: "ProdutoFavorito",
                table: "Produtos");

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

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CarrinhoId", "NomeUsuario" },
                values: new object[,]
                {
                    { new Guid("619adf24-e943-4f2a-8f89-c942d8fc53dd"), null, "Macoratti" },
                    { new Guid("8278e20b-e3e6-4926-bc26-ca54112b4645"), null, "Janice" }
                });
        }
    }
}
