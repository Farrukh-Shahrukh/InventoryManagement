using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Server.Migrations
{
    /// <inheritdoc />
    public partial class changeColName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expences_ExpenceTypes_ExpenceTypesId",
                table: "Expences");

            migrationBuilder.RenameColumn(
                name: "ExpenceTypesId",
                table: "Expences",
                newName: "ExpenceTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Expences_ExpenceTypesId",
                table: "Expences",
                newName: "IX_Expences_ExpenceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expences_ExpenceTypes_ExpenceTypeId",
                table: "Expences",
                column: "ExpenceTypeId",
                principalTable: "ExpenceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expences_ExpenceTypes_ExpenceTypeId",
                table: "Expences");

            migrationBuilder.RenameColumn(
                name: "ExpenceTypeId",
                table: "Expences",
                newName: "ExpenceTypesId");

            migrationBuilder.RenameIndex(
                name: "IX_Expences_ExpenceTypeId",
                table: "Expences",
                newName: "IX_Expences_ExpenceTypesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expences_ExpenceTypes_ExpenceTypesId",
                table: "Expences",
                column: "ExpenceTypesId",
                principalTable: "ExpenceTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
