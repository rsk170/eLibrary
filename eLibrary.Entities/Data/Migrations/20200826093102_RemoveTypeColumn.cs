using Microsoft.EntityFrameworkCore.Migrations;

namespace eLibrary.Data.Migrations
{
    public partial class RemoveTypeColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Books",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
