using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cv_handling.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    EducationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Degree = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StartYear = table.Column<int>(type: "int", nullable: false),
                    GraduationYear = table.Column<int>(type: "int", nullable: true),
                    UseridFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.EducationId);
                    table.ForeignKey(
                        name: "FK_Educations_Users_UseridFk",
                        column: x => x.UseridFk,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    WorkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    StartYear = table.Column<int>(type: "int", nullable: false),
                    EndYear = table.Column<int>(type: "int", nullable: true),
                    UseridFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.WorkId);
                    table.ForeignKey(
                        name: "FK_Works_Users_UseridFk",
                        column: x => x.UseridFk,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "EmailAddress", "FirstName", "LastName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "olof.johansson@stormaktstiden.se", "Olof", "Johansson", "+46701234567" },
                    { 2, "astrid.bergstrom@scifiworld.com", "Astrid", "Bergström", "+46701234568" },
                    { 3, "erik.lindqvist@bakeryking.com", "Erik", "Lindqvist", "+46701234569" },
                    { 4, "karl.norrstrom@swedishempirehistory.com", "Karl", "Norrström", "+46701234570" },
                    { 5, "lena.sjoberg@techbaker.com", "Lena", "Sjöberg", "+46701234571" }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "EducationId", "Degree", "GraduationYear", "SchoolName", "StartYear", "UseridFk" },
                values: new object[,]
                {
                    { 1, "Bachelor in History of the Swedish Empire", 2008, "Stockholm University", 2005, 1 },
                    { 2, "Master of Science in Astrophysics", 2015, "Lund University", 2010, 2 },
                    { 3, "Diploma in Culinary Arts", 2004, "Royal Swedish Academy of Arts", 2002, 3 },
                    { 4, "PhD in Early Modern Swedish History", 2013, "Uppsala University", 2008, 4 },
                    { 5, "Master's in Food Technology and Innovation", 2020, "KTH Royal Institute of Technology", 2016, 5 }
                });

            migrationBuilder.InsertData(
                table: "Works",
                columns: new[] { "WorkId", "Company", "Description", "EndYear", "StartYear", "Title", "UseridFk" },
                values: new object[,]
                {
                    { 1, "Swedish Empire Archives", "Researching the Swedish Empire’s military strategies and key battles.", 2018, 2010, "Historical Consultant", 1 },
                    { 2, "Galactic Horizons", "Working on deep space exploration projects in the field of star formation.", null, 2016, "Astrophysicist", 2 },
                    { 3, "Royal Swedish Bakery", "Leading a team of bakers in creating Swedish pastries and traditional breads.", 2012, 2005, "Head Baker", 3 },
                    { 4, "Historical Sweden", "Curating exhibits and writing books about Sweden's Age of Greatness.", null, 2013, "Swedish Empire Historian", 4 },
                    { 5, "TechBakery Innovations", "Developing new techniques for creating healthier and innovative bakery products.", null, 2020, "Food Scientist", 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Educations_UseridFk",
                table: "Educations",
                column: "UseridFk");

            migrationBuilder.CreateIndex(
                name: "IX_Works_UseridFk",
                table: "Works",
                column: "UseridFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
