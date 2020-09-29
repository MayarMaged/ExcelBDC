using Microsoft.EntityFrameworkCore.Migrations;

namespace BDC.Excel.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Location = table.Column<string>(nullable: true),
                    ATMName = table.Column<string>(nullable: true),
                    Branch = table.Column<string>(nullable: true),
                    SerialNumber = table.Column<string>(nullable: true),
                    Governorate = table.Column<string>(nullable: true),
                    OffSiteOrBranch = table.Column<string>(nullable: true),
                    ATMType = table.Column<string>(nullable: true),
                    CDBNA = table.Column<string>(nullable: true),
                    ATMClass = table.Column<string>(nullable: true),
                    CIT = table.Column<string>(nullable: true),
                    Port = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    GPSLocation = table.Column<string>(nullable: true),
                    StartDate = table.Column<string>(nullable: true),
                    NeedPermission = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    AvailabilityForCustomer = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entries");
        }
    }
}
