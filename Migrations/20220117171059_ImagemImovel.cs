using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAirbnb.Migrations
{
    public partial class ImagemImovel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagemNome",
                table: "Imoveis",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "85172b1f-7e0d-48e3-bb75-cc1235e504ea", "AQAAAAEAACcQAAAAED3OsgMfDRT0Cu2WdRH/sfHc+40JSxL8TAg7DOyzQ8f5c2EgXUqR/sSX741zBCHaZA==", "879b5c05-db45-4b3d-8865-a0829d88c857" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagemNome",
                table: "Imoveis");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81b4db9a-6ea7-4126-82ce-ce85d245fc74", "AQAAAAEAACcQAAAAEMzY5Z44vzDveOPVGvem+0hIdxN1tx8H6yWRpBroB2kl6ev6Yt3NRRJJ4NfiBkBrdA==", "da6949ca-1fbc-4fdf-81e7-3ead82f1c8f6" });
        }
    }
}
