using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoParaDecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimentos_ContasBancarias_ContasBancariasId",
                table: "Movimentos");

            migrationBuilder.DropIndex(
                name: "IX_Movimentos_ContasBancariasId",
                table: "Movimentos");

            migrationBuilder.DropColumn(
                name: "ContasBancariasId",
                table: "Movimentos");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Movimentos",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Saldo",
                table: "ContasBancarias",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentos_ContaBancariaId",
                table: "Movimentos",
                column: "ContaBancariaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentos_ContasBancarias_ContaBancariaId",
                table: "Movimentos",
                column: "ContaBancariaId",
                principalTable: "ContasBancarias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimentos_ContasBancarias_ContaBancariaId",
                table: "Movimentos");

            migrationBuilder.DropIndex(
                name: "IX_Movimentos_ContaBancariaId",
                table: "Movimentos");

            migrationBuilder.AlterColumn<double>(
                name: "Valor",
                table: "Movimentos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "ContasBancariasId",
                table: "Movimentos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "Saldo",
                table: "ContasBancarias",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentos_ContasBancariasId",
                table: "Movimentos",
                column: "ContasBancariasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimentos_ContasBancarias_ContasBancariasId",
                table: "Movimentos",
                column: "ContasBancariasId",
                principalTable: "ContasBancarias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
