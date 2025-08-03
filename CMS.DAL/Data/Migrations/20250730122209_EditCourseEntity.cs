using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class EditCourseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialFilePath",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "Hours",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hours",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "MaterialFilePath",
                table: "Courses",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Courses",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");
        }
    }
}
