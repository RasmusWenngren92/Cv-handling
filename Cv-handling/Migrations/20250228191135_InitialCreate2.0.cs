using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cv_handling.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobDescription",
                table: "Work",
                newName: "WorkTitle");

            migrationBuilder.RenameColumn(
                name: "CompanyTitle",
                table: "Work",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "AtCompany",
                table: "Work",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "WorkId_FK",
                table: "Experiences",
                newName: "WorkIdFk");

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Birthday",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "EducationIdFk",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WorkIdFk",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EducationIdFk",
                table: "Experiences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Experiences",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_EducationIdFk",
                table: "Users",
                column: "EducationIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Users_WorkIdFk",
                table: "Users",
                column: "WorkIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_EducationIdFk",
                table: "Experiences",
                column: "EducationIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_UserId",
                table: "Experiences",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_WorkIdFk",
                table: "Experiences",
                column: "WorkIdFk");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Education_EducationIdFk",
                table: "Experiences",
                column: "EducationIdFk",
                principalTable: "Education",
                principalColumn: "EducationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Users_UserId",
                table: "Experiences",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Work_WorkIdFk",
                table: "Experiences",
                column: "WorkIdFk",
                principalTable: "Work",
                principalColumn: "WorkId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Education_EducationIdFk",
                table: "Users",
                column: "EducationIdFk",
                principalTable: "Education",
                principalColumn: "EducationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Work_WorkIdFk",
                table: "Users",
                column: "WorkIdFk",
                principalTable: "Work",
                principalColumn: "WorkId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Education_EducationIdFk",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Users_UserId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Work_WorkIdFk",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Education_EducationIdFk",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Work_WorkIdFk",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_EducationIdFk",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_WorkIdFk",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_EducationIdFk",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_UserId",
                table: "Experiences");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_WorkIdFk",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Birthday",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EducationIdFk",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WorkIdFk",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EducationIdFk",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Experiences");

            migrationBuilder.RenameColumn(
                name: "WorkTitle",
                table: "Work",
                newName: "JobDescription");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Work",
                newName: "AtCompany");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Work",
                newName: "CompanyTitle");

            migrationBuilder.RenameColumn(
                name: "WorkIdFk",
                table: "Experiences",
                newName: "WorkId_FK");
        }
    }
}
