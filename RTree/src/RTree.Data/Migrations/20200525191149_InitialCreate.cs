using Microsoft.EntityFrameworkCore.Migrations;

namespace RTree.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BinaryAttrSet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<bool>(nullable: false),
                    BinaryAttrSetId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BinaryAttr", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BinaryAttr_BinaryAttrSet_BinaryAttrSetId",
                        column: x => x.BinaryAttrSetId,
                        principalTable: "BinaryAttrSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
