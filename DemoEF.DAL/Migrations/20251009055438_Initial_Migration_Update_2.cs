using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoEF.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration_Update_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Course_CourseId",
                table: "Student");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentHobby_Hobby_HobbyId",
                table: "StudentHobby");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentHobby_Student_StudentId",
                table: "StudentHobby");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentHobby",
                table: "StudentHobby");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Student",
                table: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hobby",
                table: "Hobby");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Course",
                table: "Course");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "StudentHobby",
                newName: "StudentHobbies");

            migrationBuilder.RenameTable(
                name: "Student",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "Hobby",
                newName: "Hobbies");

            migrationBuilder.RenameTable(
                name: "Course",
                newName: "Courses");

            migrationBuilder.RenameIndex(
                name: "IX_StudentHobby_HobbyId",
                table: "StudentHobbies",
                newName: "IX_StudentHobbies_HobbyId");

            migrationBuilder.RenameIndex(
                name: "IX_Student_CourseId",
                table: "Students",
                newName: "IX_Students_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentHobbies",
                table: "StudentHobbies",
                columns: new[] { "StudentId", "HobbyId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hobbies",
                table: "Hobbies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentHobbies_Hobbies_HobbyId",
                table: "StudentHobbies",
                column: "HobbyId",
                principalTable: "Hobbies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentHobbies_Students_StudentId",
                table: "StudentHobbies",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentHobbies_Hobbies_HobbyId",
                table: "StudentHobbies");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentHobbies_Students_StudentId",
                table: "StudentHobbies");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentHobbies",
                table: "StudentHobbies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Hobbies",
                table: "Hobbies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "Student");

            migrationBuilder.RenameTable(
                name: "StudentHobbies",
                newName: "StudentHobby");

            migrationBuilder.RenameTable(
                name: "Hobbies",
                newName: "Hobby");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "Course");

            migrationBuilder.RenameIndex(
                name: "IX_Students_CourseId",
                table: "Student",
                newName: "IX_Student_CourseId");

            migrationBuilder.RenameIndex(
                name: "IX_StudentHobbies_HobbyId",
                table: "StudentHobby",
                newName: "IX_StudentHobby_HobbyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Student",
                table: "Student",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentHobby",
                table: "StudentHobby",
                columns: new[] { "StudentId", "HobbyId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Hobby",
                table: "Hobby",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Course",
                table: "Course",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Student_Course_CourseId",
                table: "Student",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentHobby_Hobby_HobbyId",
                table: "StudentHobby",
                column: "HobbyId",
                principalTable: "Hobby",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentHobby_Student_StudentId",
                table: "StudentHobby",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
