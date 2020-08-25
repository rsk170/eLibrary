using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace eLibrary.Data.Migrations
{
    public partial class AddPDFFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PDFFile",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PDFFile",
                table: "Books");
        }
    }
}
