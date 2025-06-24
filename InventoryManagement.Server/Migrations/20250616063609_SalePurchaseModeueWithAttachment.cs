using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryManagement.Server.Migrations
{
    /// <inheritdoc />
    public partial class SalePurchaseModeueWithAttachment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attachmments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bytes = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    publicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachmments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchaser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNIC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    publicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchaser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Saller",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNIC = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    publicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saller", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaserDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchaserId = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    AttachmmentId = table.Column<int>(type: "int", nullable: false),
                    SallerId = table.Column<int>(type: "int", nullable: true),
                    publicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaserDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaserDocuments_Attachmments_AttachmmentId",
                        column: x => x.AttachmmentId,
                        principalTable: "Attachmments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaserDocuments_Purchaser_PurchaserId",
                        column: x => x.PurchaserId,
                        principalTable: "Purchaser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaserDocuments_Saller_SallerId",
                        column: x => x.SallerId,
                        principalTable: "Saller",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SalePurchase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PropertyType = table.Column<int>(type: "int", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    SallerId = table.Column<int>(type: "int", nullable: false),
                    PurchaserId = table.Column<int>(type: "int", nullable: false),
                    publicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalePurchase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalePurchase_Purchaser_PurchaserId",
                        column: x => x.PurchaserId,
                        principalTable: "Purchaser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalePurchase_Saller_SallerId",
                        column: x => x.SallerId,
                        principalTable: "Saller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SallerDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SallerId = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    AttachmmentId = table.Column<int>(type: "int", nullable: false),
                    publicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SallerDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SallerDocuments_Attachmments_AttachmmentId",
                        column: x => x.AttachmmentId,
                        principalTable: "Attachmments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SallerDocuments_Saller_SallerId",
                        column: x => x.SallerId,
                        principalTable: "Saller",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalePurchaseAttachment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalePurchaseId = table.Column<int>(type: "int", nullable: false),
                    AttachmentId = table.Column<int>(type: "int", nullable: false),
                    AttachmmentId = table.Column<int>(type: "int", nullable: false),
                    publicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalePurchaseAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalePurchaseAttachment_Attachmments_AttachmmentId",
                        column: x => x.AttachmmentId,
                        principalTable: "Attachmments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalePurchaseAttachment_SalePurchase_SalePurchaseId",
                        column: x => x.SalePurchaseId,
                        principalTable: "SalePurchase",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaserDocuments_AttachmmentId",
                table: "PurchaserDocuments",
                column: "AttachmmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaserDocuments_PurchaserId",
                table: "PurchaserDocuments",
                column: "PurchaserId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaserDocuments_SallerId",
                table: "PurchaserDocuments",
                column: "SallerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalePurchase_PurchaserId",
                table: "SalePurchase",
                column: "PurchaserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalePurchase_SallerId",
                table: "SalePurchase",
                column: "SallerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalePurchaseAttachment_AttachmmentId",
                table: "SalePurchaseAttachment",
                column: "AttachmmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SalePurchaseAttachment_SalePurchaseId",
                table: "SalePurchaseAttachment",
                column: "SalePurchaseId");

            migrationBuilder.CreateIndex(
                name: "IX_SallerDocuments_AttachmmentId",
                table: "SallerDocuments",
                column: "AttachmmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SallerDocuments_SallerId",
                table: "SallerDocuments",
                column: "SallerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PurchaserDocuments");

            migrationBuilder.DropTable(
                name: "SalePurchaseAttachment");

            migrationBuilder.DropTable(
                name: "SallerDocuments");

            migrationBuilder.DropTable(
                name: "SalePurchase");

            migrationBuilder.DropTable(
                name: "Attachmments");

            migrationBuilder.DropTable(
                name: "Purchaser");

            migrationBuilder.DropTable(
                name: "Saller");
        }
    }
}
