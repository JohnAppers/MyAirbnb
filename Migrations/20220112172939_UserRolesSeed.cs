using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyAirbnb.Migrations
{
    public partial class UserRolesSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_AspNetUsers_ClienteId",
                table: "Avaliacoes");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
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
                name: "PhoneNumber",
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

            migrationBuilder.RenameColumn(
                name: "AccessFailedCount",
                table: "Empresas",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Empresas",
                newName: "EmpresaId");

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "1", "Admin", "ADMIN" },
                    { 2, "2", "Gestor", "GESTOR" },
                    { 3, "3", "Funcionario", "FUNCIONARIO" },
                    { 4, "4", "Cliente", "CLIENTE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "7f611be1-5ae5-4674-8267-967d490d418b", "admin@gmail.com", true, true, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEF74HhdKqytgiVtOHwBBa64n9lhqc645cZHKM8kYaWkU1FcYgZT4yer/zAp+fkohUA==", null, false, "223c56a8-fba6-4c88-a51e-df88b38703c6", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_Clientes_ClienteId",
                table: "Avaliacoes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "ClienteId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Avaliacoes_Clientes_ClienteId",
                table: "Avaliacoes");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Empresas",
                newName: "AccessFailedCount");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "Empresas",
                newName: "Id");

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Avaliacoes_AspNetUsers_ClienteId",
                table: "Avaliacoes",
                column: "ClienteId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
