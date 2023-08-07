using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace nonoCore.Migrations
{
    public partial class ScoreUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Record",
                table: "Scores");

            migrationBuilder.AddColumn<int>(
                name: "Seconds",
                table: "Scores",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Seconds",
                table: "Scores");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Record",
                table: "Scores",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
