using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_TeaTech.Migrations
{
    /// <inheritdoc />
    public partial class adicao_colunas_contato : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "contact_one",
                table: "responsibles",
                type: "character varying(11)",
                maxLength: 11,
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "contact_two",
                table: "responsibles",
                type: "character varying(11)",
                maxLength: 11,
                nullable: true,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "contact_one",
                table: "responsibles");
            migrationBuilder.DropColumn(
                name: "contact_two",
                table: "responsibles");
        }
    }
}
