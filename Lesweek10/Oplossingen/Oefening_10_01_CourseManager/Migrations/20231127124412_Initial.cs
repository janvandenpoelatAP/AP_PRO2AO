using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Oefening_09_01_CourseManager.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CourseTeacher",
                columns: table => new
                {
                    CoursesId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TeachersId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTeacher", x => new { x.CoursesId, x.TeachersId });
                    table.ForeignKey(
                        name: "FK_CourseTeacher_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTeacher_Teachers_TeachersId",
                        column: x => x.TeachersId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0c4dc798-b38b-4a1c-905c-a9e76dbef17b"), "Testing & Security" },
                    { new Guid("c19099ed-94db-44ba-885b-0ad7205d5e40"), "API Ontwikkeling" },
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), "IT Organisatie" },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), "WPL Case" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("b512d7cf-b331-4b54-8dae-d1228d128e8d"), "Sven Charleer" },
                    { new Guid("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06"), "Dimitri Sturm" },
                    { new Guid("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa"), "Jan Van den Poel" }
                });

            migrationBuilder.InsertData(
                table: "CourseTeacher",
                columns: new[] { "CoursesId", "TeachersId" },
                values: new object[,]
                {
                    { new Guid("0c4dc798-b38b-4a1c-905c-a9e76dbef17b"), new Guid("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa") },
                    { new Guid("c19099ed-94db-44ba-885b-0ad7205d5e40"), new Guid("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06") },
                    { new Guid("c19099ed-94db-44ba-885b-0ad7205d5e40"), new Guid("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa") },
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new Guid("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06") },
                    { new Guid("d28888e9-2ba9-473a-a40f-e38cb54f9b35"), new Guid("fe462ec7-b30c-4987-8a8e-5f7dbd8e0cfa") },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), new Guid("b512d7cf-b331-4b54-8dae-d1228d128e8d") },
                    { new Guid("da2fd609-d754-4feb-8acd-c4f9ff13ba96"), new Guid("eacc5169-b2a7-41ad-92c3-dbb1a5e7af06") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseTeacher_TeachersId",
                table: "CourseTeacher",
                column: "TeachersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseTeacher");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
