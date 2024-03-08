using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IverMiniApi.Migrations
{
    /// <inheritdoc />
    public partial class dateAddedToPlayerObject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "IverBirdPlayer",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "IverBirdPlayer");
        }
    }
}
