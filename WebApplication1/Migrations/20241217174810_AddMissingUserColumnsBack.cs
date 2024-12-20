using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

public partial class AddMissingUserColumnsBack : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<string>(
            name: "ConcurrencyStamp",
            table: "AspNetUsers",
            type: "nvarchar(max)",
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            name: "LockoutEnabled",
            table: "AspNetUsers",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<DateTimeOffset>(
            name: "LockoutEnd",
            table: "AspNetUsers",
            type: "datetimeoffset",
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            name: "TwoFactorEnabled",
            table: "AspNetUsers",
            type: "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<string>(
            name: "SecurityStamp",
            table: "AspNetUsers",
            type: "nvarchar(max)",
            nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropColumn(
            name: "ConcurrencyStamp",
            table: "AspNetUsers");

        migrationBuilder.DropColumn(
            name: "LockoutEnabled",
            table: "AspNetUsers");

        migrationBuilder.DropColumn(
            name: "LockoutEnd",
            table: "AspNetUsers");

        migrationBuilder.DropColumn(
            name: "TwoFactorEnabled",
            table: "AspNetUsers");

        migrationBuilder.DropColumn(
            name: "SecurityStamp",
            table: "AspNetUsers");
    }
}
