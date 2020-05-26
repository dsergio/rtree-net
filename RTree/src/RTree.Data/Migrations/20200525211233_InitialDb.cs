using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RTree.Data.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BinaryAttrSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    Label = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinaryAttrSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BinaryAttr",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedBy = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<bool>(nullable: false),
                    BinaryAttrSetId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinaryAttr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BinaryAttr_BinaryAttrSet_BinaryAttrSetId",
                        column: x => x.BinaryAttrSetId,
                        principalTable: "BinaryAttrSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BinaryAttr_BinaryAttrSetId",
                table: "BinaryAttr",
                column: "BinaryAttrSetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BinaryAttr");

            migrationBuilder.DropTable(
                name: "BinaryAttrSet");
        }
    }
}
