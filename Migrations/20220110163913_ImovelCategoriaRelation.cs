using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAirbnb.Migrations
{
    public partial class ImovelCategoriaRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Imoveis",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_CategoriaId",
                table: "Imoveis",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Categorias_CategoriaId",
                table: "Imoveis",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Categorias_CategoriaId",
                table: "Imoveis");

            migrationBuilder.DropIndex(
                name: "IX_Imoveis_CategoriaId",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Imoveis");
        }
    }
}
