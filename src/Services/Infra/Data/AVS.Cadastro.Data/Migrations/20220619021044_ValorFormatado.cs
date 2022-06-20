using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AVS.Cadastro.Data.Migrations
{
    public partial class ValorFormatado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Duracao_Formatado",
                table: "Musica");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Duracao_Formatado",
                table: "Musica",
                type: "varchar(100)",
                nullable: false,
                defaultValue: "");
        }
    }
}
