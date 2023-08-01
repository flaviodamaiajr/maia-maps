using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Maia.Maps.Api.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePostCodePropsName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostCode_PostcodeTo",
                table: "SearchHistories",
                newName: "PostCode_To");

            migrationBuilder.RenameColumn(
                name: "PostCode_PostcodeFrom",
                table: "SearchHistories",
                newName: "PostCode_From");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PostCode_To",
                table: "SearchHistories",
                newName: "PostCode_PostcodeTo");

            migrationBuilder.RenameColumn(
                name: "PostCode_From",
                table: "SearchHistories",
                newName: "PostCode_PostcodeFrom");
        }
    }
}
