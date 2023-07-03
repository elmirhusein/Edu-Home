using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduHome.DataAccess.Migrations
{
    public partial class CreateCourseCatagory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseCatagories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Catagory = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCatagories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CourseCatagoryId",
                table: "Courses",
                column: "CourseCatagoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseCatagories_CourseCatagoryId",
                table: "Courses",
                column: "CourseCatagoryId",
                principalTable: "CourseCatagories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseCatagories_CourseCatagoryId",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "CourseCatagories");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CourseCatagoryId",
                table: "Courses");
        }
    }
}
