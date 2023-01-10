using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProcurementDepartament.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adres",
                table: "Vendors",
                newName: "Adress");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "Vendors",
                newName: "Adres");
        }
    }
}
