using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_TeaTech.Migrations
{
    /// <inheritdoc />
    public partial class ediçãonomescolunas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_responsible_user_fk_user_id",
                table: "responsible");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "responsible",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ResponsibleKinshipTwo",
                table: "responsible",
                newName: "responsible_kinship_two");

            migrationBuilder.RenameColumn(
                name: "ResponsibleKinshipOne",
                table: "responsible",
                newName: "responsible_kinship_one");

            migrationBuilder.RenameColumn(
                name: "ResponsibleCpfTwo",
                table: "responsible",
                newName: "resposible_cpf_two");

            migrationBuilder.RenameColumn(
                name: "ResponsibleCpfOne",
                table: "responsible",
                newName: "responsible_cpf_one");

            migrationBuilder.RenameColumn(
                name: "NameResponsibleTwo",
                table: "responsible",
                newName: "name_responsible_two");

            migrationBuilder.RenameColumn(
                name: "NameResponsibleOne",
                table: "responsible",
                newName: "name_responsible_one");

            migrationBuilder.RenameColumn(
                name: "Preferences",
                table: "child_assisted",
                newName: "preferences");

            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "child_assisted",
                newName: "photo");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "child_assisted",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Aversions",
                table: "child_assisted",
                newName: "aversions");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "child_assisted",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "MedicalRecord",
                table: "child_assisted",
                newName: "medical_record");

            migrationBuilder.RenameColumn(
                name: "FoodSelectivity",
                table: "child_assisted",
                newName: "food_selectiity");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "child_assisted",
                newName: "birth_date");

            migrationBuilder.AlterColumn<Guid>(
                name: "fk_user_id",
                table: "responsible",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "photo",
                table: "child_assisted",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "FK_responsible_user_fk_user_id",
                table: "responsible",
                column: "fk_user_id",
                principalTable: "user",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_responsible_user_fk_user_id",
                table: "responsible");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "user",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "responsible",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "resposible_cpf_two",
                table: "responsible",
                newName: "ResponsibleCpfTwo");

            migrationBuilder.RenameColumn(
                name: "responsible_kinship_two",
                table: "responsible",
                newName: "ResponsibleKinshipTwo");

            migrationBuilder.RenameColumn(
                name: "responsible_kinship_one",
                table: "responsible",
                newName: "ResponsibleKinshipOne");

            migrationBuilder.RenameColumn(
                name: "responsible_cpf_one",
                table: "responsible",
                newName: "ResponsibleCpfOne");

            migrationBuilder.RenameColumn(
                name: "name_responsible_two",
                table: "responsible",
                newName: "NameResponsibleTwo");

            migrationBuilder.RenameColumn(
                name: "name_responsible_one",
                table: "responsible",
                newName: "NameResponsibleOne");

            migrationBuilder.RenameColumn(
                name: "preferences",
                table: "child_assisted",
                newName: "Preferences");

            migrationBuilder.RenameColumn(
                name: "photo",
                table: "child_assisted",
                newName: "Photo");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "child_assisted",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "aversions",
                table: "child_assisted",
                newName: "Aversions");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "child_assisted",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "medical_record",
                table: "child_assisted",
                newName: "MedicalRecord");

            migrationBuilder.RenameColumn(
                name: "food_selectiity",
                table: "child_assisted",
                newName: "FoodSelectivity");

            migrationBuilder.RenameColumn(
                name: "birth_date",
                table: "child_assisted",
                newName: "BirthDate");

            migrationBuilder.AlterColumn<Guid>(
                name: "fk_user_id",
                table: "responsible",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "child_assisted",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_responsible_user_fk_user_id",
                table: "responsible",
                column: "fk_user_id",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
