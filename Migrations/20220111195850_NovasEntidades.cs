using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MyAirbnb.Migrations
{
    public partial class NovasEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "Empresas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Contacto",
                table: "Empresas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "Empresas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "Empresas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "Empresas",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "Empresas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "Empresas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estrelas = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    ImovelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_AspNetUsers_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Avaliacoes_Imoveis_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "Imoveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_ClienteId",
                table: "Avaliacoes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_ImovelId",
                table: "Avaliacoes",
                column: "ImovelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "Contacto",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Empresas");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneNumber",
                table: "Empresas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
