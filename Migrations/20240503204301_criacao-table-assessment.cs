using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_TeaTech.Migrations
{
    /// <inheritdoc />
    public partial class criacaotableassessment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "assessments",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    assessment = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    status_code = table.Column<int>(type: "integer", maxLength: 20, nullable: false),
                    fk_child_assisted_id = table.Column<Guid>(type: "uuid", nullable: true),
                    fk_employee_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_assessments", x => x.id);
                    table.ForeignKey(
                        name: "FK_assessments_child_assisteds_fk_child_assisted_id",
                        column: x => x.fk_child_assisted_id,
                        principalTable: "child_assisteds",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_assessments_employees_fk_employee_id",
                        column: x => x.fk_employee_id,
                        principalTable: "employees",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_assessments_fk_child_assisted_id",
                table: "assessments",
                column: "fk_child_assisted_id");

            migrationBuilder.CreateIndex(
                name: "IX_assessments_fk_employee_id",
                table: "assessments",
                column: "fk_employee_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "assessments");
        }
    }
}
