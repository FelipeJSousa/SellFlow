using Microsoft.EntityFrameworkCore.Migrations;

namespace SellFlow.Migrations
{
    public partial class AddProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imagemDestaque = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    vendedorid = table.Column<int>(type: "int", nullable: true),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.id);
                    table.ForeignKey(
                        name: "FK_Produto_Usuario_vendedorid",
                        column: x => x.vendedorid,
                        principalTable: "Usuario",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_vendedorid",
                table: "Produto",
                column: "vendedorid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
