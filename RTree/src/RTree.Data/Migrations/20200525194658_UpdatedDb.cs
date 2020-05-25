using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RTree.Data.Migrations
{
    public partial class UpdatedDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BinaryAttrSet",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "BinaryAttrSet",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "BinaryAttrSet",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "BinaryAttrSet",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "BinaryAttr",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "BinaryAttr",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "BinaryAttr",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "BinaryAttr",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BinaryAttrSet");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "BinaryAttrSet");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "BinaryAttrSet");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "BinaryAttrSet");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "BinaryAttr");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "BinaryAttr");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "BinaryAttr");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "BinaryAttr");
        }
    }
}
