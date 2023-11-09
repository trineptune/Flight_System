using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Flightdb2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FilePath",
                table: "FlightsDocument",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FilePath",
                table: "FlightsDocument");
        }
    }
}
