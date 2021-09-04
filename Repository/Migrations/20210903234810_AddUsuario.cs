using Microsoft.EntityFrameworkCore.Migrations;

namespace SellFlow.Migrations
{
    public partial class AddUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cpnj",
                table: "Pessoa",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "usuarioid",
                table: "Pessoa",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_usuarioid",
                table: "Pessoa",
                column: "usuarioid");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoa_Usuario_usuarioid",
                table: "Pessoa",
                column: "usuarioid",
                principalTable: "Usuario",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoa_Usuario_usuarioid",
                table: "Pessoa");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Pessoa_usuarioid",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "cpnj",
                table: "Pessoa");

            migrationBuilder.DropColumn(
                name: "usuarioid",
                table: "Pessoa");
        }
    }
}
