using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiMVC_UsingLoggerFactoryAndDB.Migrations
{
    public partial class loging : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Logger");

            migrationBuilder.CreateTable(
                name: "log_event",
                schema: "Logger",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EventId = table.Column<int>(nullable: true),
                    LogLevel = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    CreatedTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_log_event", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "log_event",
                schema: "Logger");
        }
    }
}
