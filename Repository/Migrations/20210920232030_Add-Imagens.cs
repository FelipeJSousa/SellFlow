using Microsoft.EntityFrameworkCore.Migrations;

namespace SellFlow.Migrations
{
    public partial class AddImagens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Imagens",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    diretorio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    produtoid = table.Column<int>(type: "int", nullable: true),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagens", x => x.id);
                    table.ForeignKey(
                        name: "FK_Imagens_Produto_produtoid",
                        column: x => x.produtoid,
                        principalTable: "Produto",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imagens_produtoid",
                table: "Imagens",
                column: "produtoid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imagens");
        }
    }
}
