using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LojaSonhoDeCafe.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddProdIdNoPagamentoDiario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("9571f874-13fa-4d6f-ad8f-fb86c2126672"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("e5900293-bdfd-4fea-a5e6-23ced3a490f2"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CarrinhoId", "NomeUsuario" },
                values: new object[,]
                {
                    { new Guid("9571f874-13fa-4d6f-ad8f-fb86c2126672"), null, "David" },
                    { new Guid("e5900293-bdfd-4fea-a5e6-23ced3a490f2"), null, "Adm" }
                });
        }
    }
}
