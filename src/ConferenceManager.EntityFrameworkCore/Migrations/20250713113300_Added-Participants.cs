using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConferenceManager.Migrations
{
    /// <inheritdoc />
    public partial class AddedParticipants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppParticipants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppParticipants", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppParticipants_Email",
                table: "AppParticipants",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppParticipants");
        }
    }
}
