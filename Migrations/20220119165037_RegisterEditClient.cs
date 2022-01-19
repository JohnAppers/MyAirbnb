using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAirbnb.Migrations
{
    public partial class RegisterEditClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Empresa_Contacto",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86ce6b12-eea9-4d59-aa65-23b0596aec85", "AQAAAAEAACcQAAAAEHD8in9g2v83P1qr0tRvVrmWL6s/TyYl5OYsvNo6d2zjIsjiU8gF0PwxxZEUYSfLfw==", "3b4dff7b-302f-4536-b81e-aaa786f2467d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Empresa_Contacto",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85172b1f-7e0d-48e3-bb75-cc1235e504ea", "AQAAAAEAACcQAAAAED3OsgMfDRT0Cu2WdRH/sfHc+40JSxL8TAg7DOyzQ8f5c2EgXUqR/sSX741zBCHaZA==", "879b5c05-db45-4b3d-8865-a0829d88c857" });
        }
    }
}
