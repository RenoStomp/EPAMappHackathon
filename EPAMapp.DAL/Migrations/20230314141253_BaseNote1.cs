using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EPAMapp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class BaseNote1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Report",
                table: "Notes",
                newName: "PastReport");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Notes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CurrentReport",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NextReport",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "CurrentReport",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "NextReport",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "PastReport",
                table: "Notes",
                newName: "Report");
        }
    }
}
