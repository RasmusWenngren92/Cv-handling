using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cv_handling.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EducationIdFk",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "WorkIdFk",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Work",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Education",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserWork",
                columns: table => new
                {
                    UsersUserId = table.Column<int>(type: "int", nullable: false),
                    WorksWorkId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWork", x => new { x.UsersUserId, x.WorksWorkId });
                    table.ForeignKey(
                        name: "FK_UserWork_Users_UsersUserId",
                        column: x => x.UsersUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWork_Work_WorksWorkId",
                        column: x => x.WorksWorkId,
                        principalTable: "Work",
                        principalColumn: "WorkId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Education",
                columns: new[] { "EducationId", "GraduationDate", "IsAlumni", "SchoolName", "SchoolTitle", "StartDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2014, 6, 1), true, "University of Awesome", "Bachelor's Degree", new DateOnly(2010, 9, 1), null },
                    { 2, new DateOnly(2017, 6, 1), true, "Institute of Greatness", "Master's Degree", new DateOnly(2015, 9, 1), null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Birthday", "Email", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "johndoe@example.com", "John", "Doe", "+1234567890" },
                    { 2, new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "janesmith@example.com", "Jane", "Smith", "+1987654321" }
                });

            migrationBuilder.InsertData(
                table: "Work",
                columns: new[] { "WorkId", "CompanyName", "Description", "Duration", "WorkTitle" },
                values: new object[,]
                {
                    { 1, "Tech Corp", "Worked as a software engineer on various web projects.", new DateOnly(2015, 5, 1), "Software Engineer" },
                    { 2, "Creative Solutions", "Managed multiple projects and led teams to success.", new DateOnly(2017, 8, 15), "Project Manager" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Education_UserId",
                table: "Education",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWork_WorksWorkId",
                table: "UserWork",
                column: "WorksWorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Education_Users_UserId",
                table: "Education",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Education_Users_UserId",
                table: "Education");

            migrationBuilder.DropTable(
                name: "UserWork");

            migrationBuilder.DropIndex(
                name: "IX_Education_UserId",
                table: "Education");

            migrationBuilder.DeleteData(
                table: "Education",
                keyColumn: "EducationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Education",
                keyColumn: "EducationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Work",
                keyColumn: "WorkId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Work",
                keyColumn: "WorkId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Education");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Work",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Birthday",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EducationIdFk",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkIdFk",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_EducationIdFk",
                table: "Users",
                column: "EducationIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Users_WorkIdFk",
                table: "Users",
                column: "WorkIdFk");

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
    }
}
