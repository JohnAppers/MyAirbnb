using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAirbnb.Migrations
{
    public partial class UserImovelRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Imoveis",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_UserId",
                table: "Imoveis",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_AspNetUsers_UserId",
                table: "Imoveis",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_AspNetUsers_UserId",
                table: "Imoveis");

            migrationBuilder.DropIndex(
                name: "IX_Imoveis_UserId",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Imoveis");
        }
    }
}
