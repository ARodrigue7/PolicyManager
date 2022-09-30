using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PolicyManager.Migrations
{
    public partial class secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "Policies",
                newName: "Premium");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Premium",
                table: "Policies",
                newName: "Cost");
        }
    }
}
