using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoEF.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_studentHobbies_Hobbies_HobbyId",
                table: "studentHobbies");

            migrationBuilder.DropForeignKey(
                name: "FK_studentHobbies_Students_StudentId",
                table: "studentHobbies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_studentHobbies",
                table: "studentHobbies");

            migrationBuilder.RenameTable(
                name: "studentHobbies",
                newName: "StudentHobbies");

            migrationBuilder.RenameIndex(
                name: "IX_studentHobbies_HobbyId",
                table: "StudentHobbies",
                newName: "IX_StudentHobbies_HobbyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudentHobbies",
                table: "StudentHobbies",
                columns: new[] { "StudentId", "HobbyId" });

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudentHobbies",
                table: "StudentHobbies");

            migrationBuilder.RenameTable(
                name: "StudentHobbies",
                newName: "studentHobbies");

            migrationBuilder.RenameIndex(
                name: "IX_StudentHobbies_HobbyId",
                table: "studentHobbies",
                newName: "IX_studentHobbies_HobbyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_studentHobbies",
                table: "studentHobbies",
                columns: new[] { "StudentId", "HobbyId" });

            migrationBuilder.AddForeignKey(
                name: "FK_studentHobbies_Hobbies_HobbyId",
                table: "studentHobbies",
                column: "HobbyId",
                principalTable: "Hobbies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_studentHobbies_Students_StudentId",
                table: "studentHobbies",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
