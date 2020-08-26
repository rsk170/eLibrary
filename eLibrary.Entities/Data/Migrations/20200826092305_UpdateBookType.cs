using Microsoft.EntityFrameworkCore.Migrations;

namespace eLibrary.Data.Migrations
{
    public partial class UpdateBookType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Books SET BookType = (CASE Type WHEN 'hard copy' THEN 0 ELSE 1 END)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
