using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_TeaTech.Migrations
{
    /// <inheritdoc />
    public partial class ediçãonomestabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_child_assisted_responsible_fk_responsible_id",
                table: "child_assisted");

            migrationBuilder.DropForeignKey(
                name: "FK_responsible_user_fk_user_id",
                table: "responsible");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_responsible",
                table: "responsible");

            migrationBuilder.DropPrimaryKey(
                name: "PK_child_assisted",
                table: "child_assisted");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "responsible",
                newName: "responsibles");

            migrationBuilder.RenameTable(
                name: "child_assisted",
                newName: "child_assisteds");

            migrationBuilder.RenameIndex(
                name: "IX_responsible_fk_user_id",
                table: "responsibles",
                newName: "IX_responsibles_fk_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_child_assisted_fk_responsible_id",
                table: "child_assisteds",
                newName: "IX_child_assisteds_fk_responsible_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_responsibles",
                table: "responsibles",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_child_assisteds",
                table: "child_assisteds",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_child_assisteds_responsibles_fk_responsible_id",
                table: "child_assisteds",
                column: "fk_responsible_id",
                principalTable: "responsibles",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_responsibles_users_fk_user_id",
                table: "responsibles",
                column: "fk_user_id",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_child_assisteds_responsibles_fk_responsible_id",
                table: "child_assisteds");

            migrationBuilder.DropForeignKey(
                name: "FK_responsibles_users_fk_user_id",
                table: "responsibles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_responsibles",
                table: "responsibles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_child_assisteds",
                table: "child_assisteds");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "responsibles",
                newName: "responsible");

            migrationBuilder.RenameTable(
                name: "child_assisteds",
                newName: "child_assisted");

            migrationBuilder.RenameIndex(
                name: "IX_responsibles_fk_user_id",
                table: "responsible",
                newName: "IX_responsible_fk_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_child_assisteds_fk_responsible_id",
                table: "child_assisted",
                newName: "IX_child_assisted_fk_responsible_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                table: "user",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_responsible",
                table: "responsible",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_child_assisted",
                table: "child_assisted",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_child_assisted_responsible_fk_responsible_id",
                table: "child_assisted",
                column: "fk_responsible_id",
                principalTable: "responsible",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_responsible_user_fk_user_id",
                table: "responsible",
                column: "fk_user_id",
                principalTable: "user",
                principalColumn: "id");
        }
    }
}
