using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class movimentos_atualizado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimentos_ContasBancarias_contasBancariasId",
                table: "Movimentos");

            migrationBuilder.RenameColumn(
                name: "contasBancariasId",
                table: "Movimentos",
                newName: "ContasBancariasId");

            migrationBuilder.RenameIndex(
                name: "IX_Movimentos_contasBancariasId",
                table: "Movimentos",
                newName: "IX_Movimentos_ContasBancariasId");

            migrationBuilder.AddColumn<int>(
                name: "ContaBancariaId",
                table: "Movimentos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentos_ContasBancarias_ContasBancariasId",
                table: "Movimentos",
                column: "ContasBancariasId",
                principalTable: "ContasBancarias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimentos_ContasBancarias_ContasBancariasId",
                table: "Movimentos");

            migrationBuilder.DropColumn(
                name: "ContaBancariaId",
                table: "Movimentos");

            migrationBuilder.RenameColumn(
                name: "ContasBancariasId",
                table: "Movimentos",
                newName: "contasBancariasId");

            migrationBuilder.RenameIndex(
                name: "IX_Movimentos_ContasBancariasId",
                table: "Movimentos",
                newName: "IX_Movimentos_contasBancariasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentos_ContasBancarias_contasBancariasId",
                table: "Movimentos",
                column: "contasBancariasId",
                principalTable: "ContasBancarias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
