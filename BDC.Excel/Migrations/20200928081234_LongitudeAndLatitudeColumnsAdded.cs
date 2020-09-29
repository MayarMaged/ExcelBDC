using Microsoft.EntityFrameworkCore.Migrations;

namespace BDC.Excel.Migrations
{
    public partial class LongitudeAndLatitudeColumnsAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Entries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Entries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Entries");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Entries");
        }
    }
}
