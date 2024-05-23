using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_TeaTech.Migrations
{
    /// <inheritdoc />
    public partial class criacaotableprogram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "programs",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    activity_description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    stimuli_used = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    protocol_type = table.Column<int>(type: "integer", maxLength: 20, nullable: false),
                    program_type = table.Column<int>(type: "integer", maxLength: 20, nullable: false),
                    status_code = table.Column<int>(type: "integer", maxLength: 20, nullable: false),
                    fk_child_assisted_id = table.Column<Guid>(type: "uuid", nullable: true),
                    fk_employee_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_programs", x => x.id);
                    table.ForeignKey(
                        name: "FK_programs_child_assisteds_fk_child_assisted_id",
                        column: x => x.fk_child_assisted_id,
                        principalTable: "child_assisteds",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_programs_employees_fk_employee_id",
                        column: x => x.fk_employee_id,
                        principalTable: "employees",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_programs_fk_child_assisted_id",
                table: "programs",
                column: "fk_child_assisted_id");

            migrationBuilder.CreateIndex(
                name: "IX_programs_fk_employee_id",
                table: "programs",
                column: "fk_employee_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "programs");
        }
    }
}
