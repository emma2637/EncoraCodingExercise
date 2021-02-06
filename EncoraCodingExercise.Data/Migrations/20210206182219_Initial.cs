using Microsoft.EntityFrameworkCore.Migrations;

namespace EncoraCodingExercise.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearBuilt = table.Column<long>(type: "bigint", nullable: false),
                    ListPrice = table.Column<long>(type: "bigint", nullable: false),
                    MontlyRent = table.Column<long>(type: "bigint", nullable: false),
                    GrossYield = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AccountNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
