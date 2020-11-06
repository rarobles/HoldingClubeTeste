﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace HoldingClube.Migrations
{
    public partial class UpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PositionOffice",
                table: "Register",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PositionOffice",
                table: "Register");
        }
    }
}
