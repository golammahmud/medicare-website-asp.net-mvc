using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.App.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoverImageUrl",
                table: "About",
                newName: "AboutDataImage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AboutDataImage",
                table: "About",
                newName: "CoverImageUrl");
        }
    }
}
