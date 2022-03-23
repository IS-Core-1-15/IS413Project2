using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TempleSignUp.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentID", "Date", "Email", "GroupName", "GroupSize", "PhoneNumber", "Time" },
                values: new object[] { 1, new DateTime(2011, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "email@email.com", "Joe's Peeps", 15, "555-555-5555", 16 });

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "AppointmentID", "Date", "Email", "GroupName", "GroupSize", "PhoneNumber", "Time" },
                values: new object[] { 2, new DateTime(2022, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brady@email.com", "Marsha", 10, "921-345-6456", 10 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "AppointmentID",
                keyValue: 2);
        }
    }
}
