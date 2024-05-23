using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_TeaTech.Migrations
{
    /// <inheritdoc />
    public partial class criacaotablepreanalysiss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "pre_analysiss",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    proposed_activity = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    final_duration = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    identified_skill = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    protocol = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    status_code = table.Column<int>(type: "integer", maxLength: 20, nullable: false),
                    fk_employee_id = table.Column<Guid>(type: "uuid", nullable: true),
                    fk_child_assisted_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pre_analysiss", x => x.id);
                    table.ForeignKey(
                        name: "FK_pre_analysiss_child_assisteds_fk_child_assisted_id",
                        column: x => x.fk_child_assisted_id,
                        principalTable: "child_assisteds",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_pre_analysiss_employees_fk_employee_id",
                        column: x => x.fk_employee_id,
                        principalTable: "employees",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_pre_analysiss_fk_child_assisted_id",
                table: "pre_analysiss",
                column: "fk_child_assisted_id");

            migrationBuilder.CreateIndex(
                name: "IX_pre_analysiss_fk_employee_id",
                table: "pre_analysiss",
                column: "fk_employee_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "pre_analysiss");
        }
    }
}
