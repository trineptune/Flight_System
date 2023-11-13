using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Dbupdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Permission_GroupPermissionId",
                table: "Permission");

            migrationBuilder.DropIndex(
                name: "IX_FlightsDocument_TypeId",
                table: "FlightsDocument");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_GroupPermissionId",
                table: "Permission",
                column: "GroupPermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightsDocument_TypeId",
                table: "FlightsDocument",
                column: "TypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Permission_GroupPermissionId",
                table: "Permission");

            migrationBuilder.DropIndex(
                name: "IX_FlightsDocument_TypeId",
                table: "FlightsDocument");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_GroupPermissionId",
                table: "Permission",
                column: "GroupPermissionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FlightsDocument_TypeId",
                table: "FlightsDocument",
                column: "TypeId",
                unique: true);
        }
    }
}
