using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightWebApi.Migrations
{
    /// <inheritdoc />
    public partial class update5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permission_FlightsDocument_FlightDocumentId",
                table: "Permission");

            migrationBuilder.DropTable(
                name: "Configuration");

            migrationBuilder.DropIndex(
                name: "IX_Permission_FlightDocumentId",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "FlightDocumentId",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "FlightsDocument");

            migrationBuilder.RenameColumn(
                name: "RoleName",
                table: "Permission",
                newName: "Note");

            migrationBuilder.AddColumn<int>(
                name: "GroupPermissionId",
                table: "Permission",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "NoPermission",
                table: "Permission",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReadAndModify",
                table: "Permission",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReadOnly",
                table: "Permission",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Permission",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "FlightsDocument",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DocumentType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupPermission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FlightDocumentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupPermission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GroupPermission_FlightsDocument_FlightDocumentId",
                        column: x => x.FlightDocumentId,
                        principalTable: "FlightsDocument",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permission_GroupPermissionId",
                table: "Permission",
                column: "GroupPermissionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permission_TypeId",
                table: "Permission",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_FlightsDocument_TypeId",
                table: "FlightsDocument",
                column: "TypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GroupPermission_FlightDocumentId",
                table: "GroupPermission",
                column: "FlightDocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_FlightsDocument_DocumentType_TypeId",
                table: "FlightsDocument",
                column: "TypeId",
                principalTable: "DocumentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_DocumentType_TypeId",
                table: "Permission",
                column: "TypeId",
                principalTable: "DocumentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Permission_GroupPermission_GroupPermissionId",
                table: "Permission",
                column: "GroupPermissionId",
                principalTable: "GroupPermission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightsDocument_DocumentType_TypeId",
                table: "FlightsDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_DocumentType_TypeId",
                table: "Permission");

            migrationBuilder.DropForeignKey(
                name: "FK_Permission_GroupPermission_GroupPermissionId",
                table: "Permission");

            migrationBuilder.DropTable(
                name: "DocumentType");

            migrationBuilder.DropTable(
                name: "GroupPermission");

            migrationBuilder.DropIndex(
                name: "IX_Permission_GroupPermissionId",
                table: "Permission");

            migrationBuilder.DropIndex(
                name: "IX_Permission_TypeId",
                table: "Permission");

            migrationBuilder.DropIndex(
                name: "IX_FlightsDocument_TypeId",
                table: "FlightsDocument");

            migrationBuilder.DropColumn(
                name: "GroupPermissionId",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "NoPermission",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "ReadAndModify",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "ReadOnly",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Permission");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "FlightsDocument");

            migrationBuilder.RenameColumn(
                name: "Note",
                table: "Permission",
                newName: "RoleName");

            migrationBuilder.AddColumn<int>(
                name: "FlightDocumentId",
                table: "Permission",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "FlightsDocument",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Configuration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DocumentId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
    }
}
