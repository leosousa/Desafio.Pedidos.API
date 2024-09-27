using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pedidos.Infraestrutura.Database.Migrations
{
    /// <inheritdoc />
    public partial class AjusteModeloPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente_IdCliente",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_IdCliente",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "IdCliente",
                table: "Pedido");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Pedido",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailCliente",
                table: "Pedido",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeCliente",
                table: "Pedido",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cliente_ClienteId",
                table: "Pedido",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente_ClienteId",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_ClienteId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "EmailCliente",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "NomeCliente",
                table: "Pedido");

            migrationBuilder.AddColumn<int>(
                name: "IdCliente",
                table: "Pedido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_IdCliente",
                table: "Pedido",
                column: "IdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cliente_IdCliente",
                table: "Pedido",
                column: "IdCliente",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
