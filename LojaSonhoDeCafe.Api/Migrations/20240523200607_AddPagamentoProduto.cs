using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LojaSonhoDeCafe.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddPagamentoProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("643466c7-4961-480c-8eb1-09f9c0c9a99e"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("a2081115-6bdc-4031-9ce5-42e1654b989c"));

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "PagamentosDiarios");

            migrationBuilder.CreateTable(
                name: "PagamentoProdutos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantidadeComprada = table.Column<int>(type: "int", nullable: false),
                    ProdutoNome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PrecoTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PagamentoDiarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagamentoProdutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagamentoProdutos_PagamentosDiarios_PagamentoDiarioId",
                        column: x => x.PagamentoDiarioId,
                        principalTable: "PagamentosDiarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PagamentoProdutos_PagamentoDiarioId",
                table: "PagamentoProdutos",
                column: "PagamentoDiarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PagamentoProdutos");

            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId",
                table: "PagamentosDiarios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CarrinhoId", "NomeUsuario" },
                values: new object[,]
                {
                    { new Guid("643466c7-4961-480c-8eb1-09f9c0c9a99e"), null, "Adm" },
                    { new Guid("a2081115-6bdc-4031-9ce5-42e1654b989c"), null, "David" }
                });
        }
    }
}
