using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPictureUrlToCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Courses");
        }
    }
}
