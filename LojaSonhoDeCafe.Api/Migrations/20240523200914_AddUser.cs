using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LojaSonhoDeCafe.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "CarrinhoId", "NomeUsuario" },
                values: new object[,]
                {
                    { new Guid("9f79df78-a48e-4939-9b1b-d35b1c9358cb"), null, "Adm" },
                    { new Guid("febdc1b2-4dad-42ae-8602-ea04c30fe2f2"), null, "David" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("9f79df78-a48e-4939-9b1b-d35b1c9358cb"));

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: new Guid("febdc1b2-4dad-42ae-8602-ea04c30fe2f2"));
        }
    }
}
