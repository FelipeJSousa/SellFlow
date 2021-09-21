using Microsoft.EntityFrameworkCore.Migrations;

namespace SellFlow.Migrations
{
    public partial class AddSituacaoAnuncio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "situacaoid",
                table: "Anuncio",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SituacaoAnuncio",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacaoAnuncio", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anuncio_situacaoid",
                table: "Anuncio",
                column: "situacaoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Anuncio_SituacaoAnuncio_situacaoid",
                table: "Anuncio",
                column: "situacaoid",
                principalTable: "SituacaoAnuncio",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anuncio_SituacaoAnuncio_situacaoid",
                table: "Anuncio");

            migrationBuilder.DropTable(
                name: "SituacaoAnuncio");

            migrationBuilder.DropIndex(
                name: "IX_Anuncio_situacaoid",
                table: "Anuncio");

            migrationBuilder.DropColumn(
                name: "situacaoid",
                table: "Anuncio");
        }
    }
}
