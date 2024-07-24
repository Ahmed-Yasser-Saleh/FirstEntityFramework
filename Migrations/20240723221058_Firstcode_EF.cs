using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace task_8_EF.Migrations
{
    /// <inheritdoc />
    public partial class Firstcode_EF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Courses_Students_CourseId",
                table: "Courses_Students");

            migrationBuilder.DropIndex(
                name: "IX_course_Instructors_CourseId",
                table: "course_Instructors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses_Students",
                table: "Courses_Students",
                columns: new[] { "CourseId", "StudentId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_course_Instructors",
                table: "course_Instructors",
                columns: new[] { "CourseId", "InstructorId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses_Students",
                table: "Courses_Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_course_Instructors",
                table: "course_Instructors");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_Students_CourseId",
                table: "Courses_Students",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_course_Instructors_CourseId",
                table: "course_Instructors",
                column: "CourseId");
        }
    }
}
