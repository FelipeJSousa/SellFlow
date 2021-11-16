using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class ColunasAdd_Anuncio_Endereco_Pessoa_Produto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Endereco_pessoa",
                table: "Endereco");

            migrationBuilder.AddColumn<double>(
                name: "valor",
                table: "Produto",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<long>(
                name: "pessoa",
                table: "Endereco",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cep",
                table: "Endereco",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "municipio",
                table: "Endereco",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "valor",
                table: "Anuncio",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_pessoa",
                table: "Endereco",
                column: "pessoa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Endereco_pessoa",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "valor",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "cep",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "municipio",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "valor",
                table: "Anuncio");

            migrationBuilder.AlterColumn<long>(
                name: "pessoa",
                table: "Endereco",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_pessoa",
                table: "Endereco",
                column: "pessoa",
                unique: true,
                filter: "[pessoa] IS NOT NULL");
        }
    }
}
