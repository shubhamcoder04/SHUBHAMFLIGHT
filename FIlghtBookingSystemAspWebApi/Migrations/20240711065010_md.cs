using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIlghtBookingSystemAspWebApi.Migrations
{
    /// <inheritdoc />
    public partial class md : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlightDetails",
                columns: table => new
                {
                    Flight_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Airline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departure_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Arrival_Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Total_Seats = table.Column<int>(type: "int", nullable: false),
                    Fare = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightDetails", x => x.Flight_ID);
                });

            migrationBuilder.CreateTable(
                name: "UserTables",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone_no = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTables", x => x.User_ID);
                });

            migrationBuilder.CreateTable(
                name: "BookingDetails",
                columns: table => new
                {
                    Booking_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Flight_ID = table.Column<int>(type: "int", nullable: false),
                    Total_Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    No_of_passengers = table.Column<int>(type: "int", nullable: false),
                    TransactionNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    User_ID1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetails", x => x.Booking_Id);
                    table.ForeignKey(
                        name: "FK_BookingDetails_UserTables_User_ID1",
                        column: x => x.User_ID1,
                        principalTable: "UserTables",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckInStatuses",
                columns: table => new
                {
                    Check_in_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Check_in_Status = table.Column<bool>(type: "bit", nullable: false),
                    Seat_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Booking_Id = table.Column<int>(type: "int", nullable: false),
                    Flight_ID = table.Column<int>(type: "int", nullable: false),
                    BookingDetailsBooking_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckInStatuses", x => x.Check_in_Id);
                    table.ForeignKey(
                        name: "FK_CheckInStatuses_BookingDetails_BookingDetailsBooking_Id",
                        column: x => x.BookingDetailsBooking_Id,
                        principalTable: "BookingDetails",
                        principalColumn: "Booking_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passengers",
                columns: table => new
                {
                    Passenger_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    BookingDetailsBooking_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passengers", x => x.Passenger_Id);
                    table.ForeignKey(
                        name: "FK_Passengers_BookingDetails_BookingDetailsBooking_Id",
                        column: x => x.BookingDetailsBooking_Id,
                        principalTable: "BookingDetails",
                        principalColumn: "Booking_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_User_ID1",
                table: "BookingDetails",
                column: "User_ID1");

            migrationBuilder.CreateIndex(
                name: "IX_CheckInStatuses_BookingDetailsBooking_Id",
                table: "CheckInStatuses",
                column: "BookingDetailsBooking_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_BookingDetailsBooking_Id",
                table: "Passengers",
                column: "BookingDetailsBooking_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckInStatuses");

            migrationBuilder.DropTable(
                name: "FlightDetails");

            migrationBuilder.DropTable(
                name: "Passengers");

            migrationBuilder.DropTable(
                name: "BookingDetails");

            migrationBuilder.DropTable(
                name: "UserTables");
        }
    }
}
