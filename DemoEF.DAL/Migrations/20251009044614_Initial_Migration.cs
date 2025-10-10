using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DemoEF.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hobby",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobby", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Fee = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    Agree = table.Column<bool>(type: "bit", nullable: false),
                    Profile = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    DOB = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.CheckConstraint("CK_Student_Agree_98400", "[Agree] = 1");
                    table.ForeignKey(
                        name: "FK_Student_Course_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentHobby",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    HobbyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentHobby", x => new { x.StudentId, x.HobbyId });
                    table.ForeignKey(
                        name: "FK_StudentHobby_Hobby_HobbyId",
                        column: x => x.HobbyId,
                        principalTable: "Hobby",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentHobby_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "BCA" },
                    { 2, "BIM" },
                    { 3, "BBS" },
                    { 4, "BIT" },
                    { 5, "BSC CSIT" }
                });

            migrationBuilder.InsertData(
                table: "Hobby",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Entertainment" },
                    { 2, "Learning" },
                    { 3, "Content Creation" },
                    { 4, "Gaming" },
                    { 5, "Outdoor games" },
                    { 6, "Adventures" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Password", "UserName" },
                values: new object[] { 1, "Prakash@123", "Prakash" });

            migrationBuilder.CreateIndex(
                name: "IX_Student_CourseId",
                table: "Student",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentHobby_HobbyId",
                table: "StudentHobby",
                column: "HobbyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentHobby");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Hobby");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Course");
        }
    }
}
