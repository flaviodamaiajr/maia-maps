using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maia.Maps.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SearchHistories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PostcodeFrom = table.Column<string>(type: "varchar(15)", maxLength: 15, precision: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostcodeTo = table.Column<string>(type: "varchar(15)", maxLength: 15, precision: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DistanceKilometers = table.Column<double>(name: "Distance_Kilometers", type: "double", precision: 10, scale: 2, nullable: false),
                    DistanceMiles = table.Column<double>(name: "Distance_Miles", type: "double", precision: 10, scale: 2, nullable: false),
                    CoordinatesFromLatitude = table.Column<double>(name: "CoordinatesFrom_Latitude", type: "double", nullable: false),
                    CoordinatesFromLongitude = table.Column<double>(name: "CoordinatesFrom_Longitude", type: "double", nullable: false),
                    CoordinatesToLatitude = table.Column<double>(name: "CoordinatesTo_Latitude", type: "double", nullable: false),
                    CoordinatesToLongitude = table.Column<double>(name: "CoordinatesTo_Longitude", type: "double", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchHistories", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchHistories");
        }
    }
}
