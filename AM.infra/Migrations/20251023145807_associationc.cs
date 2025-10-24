using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.infra.Migrations
{
    /// <inheritdoc />
    public partial class associationc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    flight_fk = table.Column<int>(type: "int", nullable: false),
                    passenger_fk = table.Column<string>(type: "nvarchar(7)", nullable: false),
                    siege = table.Column<int>(type: "int", nullable: false),
                    prix = table.Column<float>(type: "real", nullable: false),
                    VIP = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => new { x.passenger_fk, x.flight_fk });
                    table.ForeignKey(
                        name: "FK_Ticket_Flghts_flight_fk",
                        column: x => x.flight_fk,
                        principalTable: "Flghts",
                        principalColumn: "Flightid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Passengers_passenger_fk",
                        column: x => x.passenger_fk,
                        principalTable: "Passengers",
                        principalColumn: "PassportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_flight_fk",
                table: "Ticket",
                column: "flight_fk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");
        }
    }
}
