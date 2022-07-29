using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.App.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Banner",
                newName: "createdAt");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "createdAt",
                table: "Banner",
                newName: "DateTime");
        }
    }
}
