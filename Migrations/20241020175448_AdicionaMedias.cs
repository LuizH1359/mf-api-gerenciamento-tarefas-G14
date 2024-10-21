using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mf_api_gerenciamento_tarefas_G14.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaMedias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Notas",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)");

            migrationBuilder.AddColumn<decimal>(
                name: "NotaMaxima",
                table: "Notas",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Media",
                table: "Disciplinas",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PorcentagemNecessaria",
                table: "Disciplinas",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NotaMaxima",
                table: "Notas");

            migrationBuilder.DropColumn(
                name: "Media",
                table: "Disciplinas");

            migrationBuilder.DropColumn(
                name: "PorcentagemNecessaria",
                table: "Disciplinas");

            migrationBuilder.AlterColumn<decimal>(
                name: "Valor",
                table: "Notas",
                type: "decimal(5,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");
        }
    }
}
