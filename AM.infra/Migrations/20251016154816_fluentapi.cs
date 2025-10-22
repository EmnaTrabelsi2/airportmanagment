using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.infra.Migrations
{
    /// <inheritdoc />
    public partial class fluentapi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flghts_Planes_PlaneFK",
                table: "Flghts");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_Flghts_FlightsFlightid",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_Passengers_PassengersPassportNumber",
                table: "FlightPassenger");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Planes",
                table: "Planes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger");

            migrationBuilder.RenameTable(
                name: "Planes",
                newName: "MyPlanes");

            migrationBuilder.RenameTable(
                name: "FlightPassenger",
                newName: "MyReservation");

            migrationBuilder.RenameColumn(
                name: "Capacity",
                table: "MyPlanes",
                newName: "PlaneCapacity");

            migrationBuilder.RenameIndex(
                name: "IX_FlightPassenger_PassengersPassportNumber",
                table: "MyReservation",
                newName: "IX_MyReservation_PassengersPassportNumber");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyPlanes",
                table: "MyPlanes",
                column: "PLaneiD");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MyReservation",
                table: "MyReservation",
                columns: new[] { "FlightsFlightid", "PassengersPassportNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_Flghts_MyPlanes_PlaneFK",
                table: "Flghts",
                column: "PlaneFK",
                principalTable: "MyPlanes",
                principalColumn: "PLaneiD",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MyReservation_Flghts_FlightsFlightid",
                table: "MyReservation",
                column: "FlightsFlightid",
                principalTable: "Flghts",
                principalColumn: "Flightid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MyReservation_Passengers_PassengersPassportNumber",
                table: "MyReservation",
                column: "PassengersPassportNumber",
                principalTable: "Passengers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flghts_MyPlanes_PlaneFK",
                table: "Flghts");

            migrationBuilder.DropForeignKey(
                name: "FK_MyReservation_Flghts_FlightsFlightid",
                table: "MyReservation");

            migrationBuilder.DropForeignKey(
                name: "FK_MyReservation_Passengers_PassengersPassportNumber",
                table: "MyReservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyReservation",
                table: "MyReservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MyPlanes",
                table: "MyPlanes");

            migrationBuilder.RenameTable(
                name: "MyReservation",
                newName: "FlightPassenger");

            migrationBuilder.RenameTable(
                name: "MyPlanes",
                newName: "Planes");

            migrationBuilder.RenameIndex(
                name: "IX_MyReservation_PassengersPassportNumber",
                table: "FlightPassenger",
                newName: "IX_FlightPassenger_PassengersPassportNumber");

            migrationBuilder.RenameColumn(
                name: "PlaneCapacity",
                table: "Planes",
                newName: "Capacity");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger",
                columns: new[] { "FlightsFlightid", "PassengersPassportNumber" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Planes",
                table: "Planes",
                column: "PLaneiD");

            migrationBuilder.AddForeignKey(
                name: "FK_Flghts_Planes_PlaneFK",
                table: "Flghts",
                column: "PlaneFK",
                principalTable: "Planes",
                principalColumn: "PLaneiD",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_Flghts_FlightsFlightid",
                table: "FlightPassenger",
                column: "FlightsFlightid",
                principalTable: "Flghts",
                principalColumn: "Flightid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_Passengers_PassengersPassportNumber",
                table: "FlightPassenger",
                column: "PassengersPassportNumber",
                principalTable: "Passengers",
                principalColumn: "PassportNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
