using Microsoft.EntityFrameworkCore.Migrations;

namespace Repository.Migrations
{
    public partial class endereco_removeMunicipio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "municipio",
                table: "Endereco");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "municipio",
                table: "Endereco",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
