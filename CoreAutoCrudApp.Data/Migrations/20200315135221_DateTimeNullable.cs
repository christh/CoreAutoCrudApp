using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreAutoCrudApp.Data.Migrations
{
    public partial class DateTimeNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    AssetId = table.Column<Guid>(nullable: false, defaultValue: new Guid()),
                    MimeType = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime?>(nullable: true, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
