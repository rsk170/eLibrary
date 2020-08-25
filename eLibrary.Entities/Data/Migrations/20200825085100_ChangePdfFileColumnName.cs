using Microsoft.EntityFrameworkCore.Migrations;

namespace eLibrary.Data.Migrations
{
    public partial class ChangePdfFileColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PDFFile",
                table: "Books",
                newName: "PdfFile");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PdfFile",
                table: "Books",
                newName: "PDFFile");
        }
    }
}
