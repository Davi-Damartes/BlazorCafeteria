using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LojaSonhoDeCafe.Migrations.BancoDeDadosMigrations
{
    /// <inheritdoc />
    public partial class AddRelatioVendasMensal : Migration
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

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("aed75225-83f2-4310-9958-ed8eef11a666"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("e601b521-7148-4f29-a4cb-bec62e55ed5c"));

            migrationBuilder.CreateTable(
                name: "RelatorioVendasMensalis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantidadeProdutosVendidos = table.Column<int>(type: "int", nullable: false),
                    PrecoTotalVendas = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantidadeUsuariosUnicos = table.Column<int>(type: "int", nullable: false),
                    Mes = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RelatorioVendasMensalis", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RelatorioVendasMensalis");

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
                table: "Usuarios",
                columns: new[] { "Id", "CarrinhoId", "NomeUsuario" },
                values: new object[,]
                {
                    { new Guid("aed75225-83f2-4310-9958-ed8eef11a666"), null, "Davi" },
                    { new Guid("e601b521-7148-4f29-a4cb-bec62e55ed5c"), null, "Janice" }
                });
        }
    }
}
