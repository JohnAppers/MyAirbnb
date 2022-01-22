using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MyAirbnb.Migrations
{
    public partial class ReservasRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Reservas",
                newName: "DateStart");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEnd",
                table: "Reservas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8d7520d-34d4-47f1-92e8-876b7c7bfd93", "AQAAAAEAACcQAAAAEBViOUJRqS85HJtiHjPMfQ0TqpMSBQLBbXJQe0DaQg79jkc3t5M66djjLYr4LWBAQg==", "f1b54d64-2745-4dc3-a05f-f62170b748aa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateEnd",
                table: "Reservas");

            migrationBuilder.RenameColumn(
                name: "DateStart",
                table: "Reservas",
                newName: "Date");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f612892e-4525-4936-9d04-dbdc6ac6e6d9", "AQAAAAEAACcQAAAAEJb+Hrjp4XVv72VYh1A4NQ48LwFMVBSPcJGNUFTpS01VxE5MSeEVS+P8sNA59lPYnw==", "c522639a-fd09-4cb2-bf34-b47f5979a460" });
        }
    }
}
