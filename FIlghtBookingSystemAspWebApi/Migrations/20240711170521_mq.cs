using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FIlghtBookingSystemAspWebApi.Migrations
{
    /// <inheritdoc />
    public partial class mq : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetails_UserTables_User_ID1",
                table: "BookingDetails");

            migrationBuilder.DropIndex(
                name: "IX_BookingDetails_User_ID1",
                table: "BookingDetails");

            migrationBuilder.DropColumn(
                name: "User_ID1",
                table: "BookingDetails");

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_User_ID",
                table: "BookingDetails",
                column: "User_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDetails_UserTables_User_ID",
                table: "BookingDetails",
                column: "User_ID",
                principalTable: "UserTables",
                principalColumn: "User_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookingDetails_UserTables_User_ID",
                table: "BookingDetails");

            migrationBuilder.DropIndex(
                name: "IX_BookingDetails_User_ID",
                table: "BookingDetails");

            migrationBuilder.AddColumn<int>(
                name: "User_ID1",
                table: "BookingDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BookingDetails_User_ID1",
                table: "BookingDetails",
                column: "User_ID1");

            migrationBuilder.AddForeignKey(
                name: "FK_BookingDetails_UserTables_User_ID1",
                table: "BookingDetails",
                column: "User_ID1",
                principalTable: "UserTables",
                principalColumn: "User_ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
