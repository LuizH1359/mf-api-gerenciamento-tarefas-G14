using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mf_api_gerenciamento_tarefas_G14.Migrations
{
    /// <inheritdoc />
    public partial class CorrecoesDisciplina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "MediaAprovacao",
                table: "Disciplinas",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "NotaMaxima",
                table: "Disciplinas",
                type: "decimal(5,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MediaAprovacao",
                table: "Disciplinas");

            migrationBuilder.DropColumn(
                name: "NotaMaxima",
                table: "Disciplinas");
        }
    }
}
