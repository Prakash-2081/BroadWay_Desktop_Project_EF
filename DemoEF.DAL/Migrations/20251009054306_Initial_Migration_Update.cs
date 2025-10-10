using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoEF.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Migration_Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Student_Agree_98400",
                table: "Student");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Student_Agree_98400",
                table: "Student",
                sql: "[Agree] = 1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Student_Agree_98400",
                table: "Student");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Student_Agree_98400",
                table: "Student",
                sql: "[Agree=(1)]");
        }
    }
}
