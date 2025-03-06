using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cv_handling.Migrations
{
    /// <inheritdoc />
    public partial class FixUserWorkRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Education_Users_UserId",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Education_EducationIdFk",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Users_UserId",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Work_WorkIdFk",
                table: "Experiences");

            migrationBuilder.DropTable(
                name: "UserWork");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_UserId",
                table: "Experiences");

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
                table: "Experiences");

            migrationBuilder.AddColumn<int>(
                name: "UserIdFk",
                table: "Work",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WorkIdFk",
                table: "Experiences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EducationIdFk",
                table: "Experiences",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Experiences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserIdFk",
                table: "Experiences",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Education",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserIdFk",
                table: "Education",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Work_UserIdFk",
                table: "Work",
                column: "UserIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Users_WorkId",
                table: "Users",
                column: "WorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_UserIdFk",
                table: "Experiences",
                column: "UserIdFk");

            migrationBuilder.AddForeignKey(
                name: "FK_Education_Users_UserId",
                table: "Education",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Education_EducationIdFk",
                table: "Experiences",
                column: "EducationIdFk",
                principalTable: "Education",
                principalColumn: "EducationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Users_UserIdFk",
                table: "Experiences",
                column: "UserIdFk",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Experiences_Work_WorkIdFk",
                table: "Experiences",
                column: "WorkIdFk",
                principalTable: "Work",
                principalColumn: "WorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Work_WorkId",
                table: "Users",
                column: "WorkId",
                principalTable: "Work",
                principalColumn: "WorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Work_Users_UserIdFk",
                table: "Work",
                column: "UserIdFk",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Education_Users_UserId",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Education_EducationIdFk",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Users_UserIdFk",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Experiences_Work_WorkIdFk",
                table: "Experiences");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Work_WorkId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Work_Users_UserIdFk",
                table: "Work");

            migrationBuilder.DropIndex(
                name: "IX_Work_UserIdFk",
                table: "Work");

            migrationBuilder.DropIndex(
                name: "IX_Users_WorkId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Experiences_UserIdFk",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "UserIdFk",
                table: "Work");

            migrationBuilder.DropColumn(
                name: "WorkId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "UserIdFk",
                table: "Experiences");

            migrationBuilder.DropColumn(
                name: "UserIdFk",
                table: "Education");

            migrationBuilder.AlterColumn<int>(
                name: "WorkIdFk",
                table: "Experiences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EducationIdFk",
                table: "Experiences",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Experiences",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Education",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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
                name: "IX_Experiences_UserId",
                table: "Experiences",
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
        }
    }
}
