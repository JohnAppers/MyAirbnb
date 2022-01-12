using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAirbnb.Migrations
{
    public partial class EmpresaImovelRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Categorias_CategoriaId",
                table: "Imoveis");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Imoveis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Imoveis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Imoveis",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Imoveis",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_EmpresaId",
                table: "Imoveis",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Categorias_CategoriaId",
                table: "Imoveis",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Empresas_EmpresaId",
                table: "Imoveis",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Categorias_CategoriaId",
                table: "Imoveis");

            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_Empresas_EmpresaId",
                table: "Imoveis");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Imoveis_EmpresaId",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Imoveis");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Imoveis",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Imoveis",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "CategoriaId",
                table: "Imoveis",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_Categorias_CategoriaId",
                table: "Imoveis",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
