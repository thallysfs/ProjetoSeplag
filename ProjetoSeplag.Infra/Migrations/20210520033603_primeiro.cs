using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoSeplag.Infra.Migrations
{
    public partial class primeiro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UpdateEntity",
                columns: table => new
                {
                    ID = table.Column<string>(type: "text", nullable: false),
                    Alias = table.Column<string>(type: "text", nullable: true),
                    DocumentTitle = table.Column<string>(type: "text", nullable: true),
                    Severity = table.Column<string>(type: "text", nullable: true),
                    InitialReleaseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CurrentReleaseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CvrfUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpdateEntity", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UpdateEntity");
        }
    }
}
