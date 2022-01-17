using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAirbnb.Migrations
{
    public partial class Funcionarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Imoveis",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FuncionarioNome",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Funcionario_EmpresaId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81b4db9a-6ea7-4126-82ce-ce85d245fc74", "AQAAAAEAACcQAAAAEMzY5Z44vzDveOPVGvem+0hIdxN1tx8H6yWRpBroB2kl6ev6Yt3NRRJJ4NfiBkBrdA==", "da6949ca-1fbc-4fdf-81e7-3ead82f1c8f6" });

            migrationBuilder.CreateIndex(
                name: "IX_Imoveis_FuncionarioId",
                table: "Imoveis",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Funcionario_EmpresaId",
                table: "AspNetUsers",
                column: "Funcionario_EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_Funcionario_EmpresaId",
                table: "AspNetUsers",
                column: "Funcionario_EmpresaId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Imoveis_AspNetUsers_FuncionarioId",
                table: "Imoveis",
                column: "FuncionarioId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_Funcionario_EmpresaId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Imoveis_AspNetUsers_FuncionarioId",
                table: "Imoveis");

            migrationBuilder.DropIndex(
                name: "IX_Imoveis_FuncionarioId",
                table: "Imoveis");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Funcionario_EmpresaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Imoveis");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FuncionarioNome",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Funcionario_EmpresaId",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "754fabfb-749b-4983-a6ed-40805b474ebe", "AQAAAAEAACcQAAAAEFZ1HhG46iBKwwGA6ifCsUguwjclHYzVeKrUF3i9zy9KcIbUn6eIBJu+laBSQjdTrw==", "abd3cc8a-e9ea-4bc8-8fa0-5cc58d390319" });
        }
    }
}
