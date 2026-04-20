using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repositorio.Migrations
{
    /// <inheritdoc />
    public partial class Movimentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Saldo",
                table: "ContasBancarias",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Movimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    contasBancariasId = table.Column<int>(type: "INTEGER", nullable: false),
                    Valor = table.Column<double>(type: "REAL", nullable: false),
                    TipoMovimento = table.Column<int>(type: "INTEGER", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movimentos_ContasBancarias_contasBancariasId",
                        column: x => x.contasBancariasId,
                        principalTable: "ContasBancarias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movimentos_contasBancariasId",
                table: "Movimentos",
                column: "contasBancariasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentos");

            migrationBuilder.DropColumn(
                name: "Saldo",
                table: "ContasBancarias");
        }
    }
}
