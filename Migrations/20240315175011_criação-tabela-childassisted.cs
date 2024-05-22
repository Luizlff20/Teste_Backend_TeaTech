using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_TeaTech.Migrations
{
    /// <inheritdoc />
    public partial class criaçãotabelachildassisted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "responsible",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NameResponsibleOne = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ResponsibleKinshipOne = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ResponsibleCpfOne = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    NameResponsibleTwo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ResponsibleKinshipTwo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    ResponsibleCpfTwo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    fk_user_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_responsible", x => x.Id);
                    table.ForeignKey(
                        name: "FK_responsible_user_fk_user_id",
                        column: x => x.fk_user_id,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "child_assisted",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FoodSelectivity = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Aversions = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Preferences = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    MedicalRecord = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    fk_responsible_id = table.Column<Guid>(type: "uuid", nullable: true),
                    Photo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_child_assisted", x => x.Id);
                    table.ForeignKey(
                        name: "FK_child_assisted_responsible_fk_responsible_id",
                        column: x => x.fk_responsible_id,
                        principalTable: "responsible",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_child_assisted_fk_responsible_id",
                table: "child_assisted",
                column: "fk_responsible_id");

            migrationBuilder.CreateIndex(
                name: "IX_responsible_fk_user_id",
                table: "responsible",
                column: "fk_user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "child_assisted");

            migrationBuilder.DropTable(
                name: "responsible");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
