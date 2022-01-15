using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAirbnb.Migrations
{
    public partial class EmpresaRegister : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeCliente",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "754fabfb-749b-4983-a6ed-40805b474ebe", "AQAAAAEAACcQAAAAEFZ1HhG46iBKwwGA6ifCsUguwjclHYzVeKrUF3i9zy9KcIbUn6eIBJu+laBSQjdTrw==", "abd3cc8a-e9ea-4bc8-8fa0-5cc58d390319" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeCliente",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "809c12d0-05ea-4dbf-b2b7-c8296a25de16", "AQAAAAEAACcQAAAAEOdzNcnIzLfux5qVFHQEZEFctATTF1JShXZobM5UUdUkygEMNjkk41A4JakSG8xIng==", "a8885c31-8dba-42e9-a37f-1d52ff500405" });
        }
    }
}
