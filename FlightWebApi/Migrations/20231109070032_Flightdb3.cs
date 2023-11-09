using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightWebApi.Migrations
{
    /// <inheritdoc />
    public partial class Flightdb3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permisson_FlightsDocument_DocId",
                table: "Permisson");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permisson",
                table: "Permisson");

            migrationBuilder.DropIndex(
                name: "IX_Permisson_DocId",
                table: "Permisson");

            migrationBuilder.DropColumn(
                name: "DocId",
                table: "Permisson");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Permisson");

            migrationBuilder.RenameTable(
                name: "Permisson",
                newName: "Permission");

            migrationBuilder.AddColumn<int>(
                name: "FlightDocumentId",
                table: "Permission",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permission",
                table: "Permission",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Configuration_FlightsDocument_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "FlightsDocument",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permission_FlightDocumentId",
                table: "Permission",
                column: "FlightDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_DocumentId",
                table: "Configuration",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_FlightsDocument_FlightDocumentId",
                table: "Permission",
                column: "FlightDocumentId",
                principalTable: "FlightsDocument",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permission_FlightsDocument_FlightDocumentId",
                table: "Permission");

            migrationBuilder.DropTable(
                name: "Configuration");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Permission",
                table: "Permission");

            migrationBuilder.DropIndex(
                name: "IX_Permission_FlightDocumentId",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "FlightDocumentId",
                table: "Permission");

            migrationBuilder.RenameTable(
                name: "Permission",
                newName: "Permisson");

            migrationBuilder.AddColumn<int>(
                name: "DocId",
                table: "Permisson",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Permisson",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Permisson",
                table: "Permisson",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Permisson_DocId",
                table: "Permisson",
                column: "DocId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permisson_FlightsDocument_DocId",
                table: "Permisson",
                column: "DocId",
                principalTable: "FlightsDocument",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
