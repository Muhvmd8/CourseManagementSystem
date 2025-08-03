using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangePictureUrlToImageName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PictureUrl",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "PictureUrl",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
