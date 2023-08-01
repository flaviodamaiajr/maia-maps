using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maia.Maps.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePostCodeStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostcodeTo",
                table: "SearchHistories",
                newName: "PostCode_PostcodeTo");

            migrationBuilder.RenameColumn(
                name: "PostcodeFrom",
                table: "SearchHistories",
                newName: "PostCode_PostcodeFrom");

            migrationBuilder.AlterColumn<double>(
                name: "Distance_Miles",
                table: "SearchHistories",
                type: "double",
                precision: 10,
                scale: 2,
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldPrecision: 10,
                oldScale: 2);

            migrationBuilder.AlterColumn<double>(
                name: "Distance_Kilometers",
                table: "SearchHistories",
                type: "double",
                precision: 10,
                scale: 2,
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double",
                oldPrecision: 10,
                oldScale: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostCode_PostcodeTo",
                table: "SearchHistories",
                newName: "PostcodeTo");

            migrationBuilder.RenameColumn(
                name: "PostCode_PostcodeFrom",
                table: "SearchHistories",
                newName: "PostcodeFrom");

            migrationBuilder.AlterColumn<double>(
                name: "Distance_Miles",
                table: "SearchHistories",
                type: "double",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double",
                oldPrecision: 10,
                oldScale: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Distance_Kilometers",
                table: "SearchHistories",
                type: "double",
                precision: 10,
                scale: 2,
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double",
                oldPrecision: 10,
                oldScale: 2,
                oldNullable: true);
        }
    }
}
