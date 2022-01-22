using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MyAirbnb.Migrations
{
    public partial class Reservas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Avaliacoes");

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImovelId = table.Column<int>(type: "int", nullable: false),
                    RatingImovel = table.Column<int>(type: "int", nullable: true),
                    CommentImovel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FuncionarioId = table.Column<int>(type: "int", nullable: true),
                    RatingFuncionario = table.Column<int>(type: "int", nullable: true),
                    CommentFuncionario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmpresaId = table.Column<int>(type: "int", nullable: true),
                    RatingGestor = table.Column<int>(type: "int", nullable: true),
                    CommentGestor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    RatingCliente = table.Column<int>(type: "int", nullable: true),
                    CommentCliente = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_AspNetUsers_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_AspNetUsers_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_AspNetUsers_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_Imoveis_ImovelId",
                        column: x => x.ImovelId,
                        principalTable: "Imoveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f612892e-4525-4936-9d04-dbdc6ac6e6d9", "AQAAAAEAACcQAAAAEJb+Hrjp4XVv72VYh1A4NQ48LwFMVBSPcJGNUFTpS01VxE5MSeEVS+P8sNA59lPYnw==", "c522639a-fd09-4cb2-bf34-b47f5979a460" });

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ClienteId",
                table: "Reservas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_EmpresaId",
                table: "Reservas",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_FuncionarioId",
                table: "Reservas",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ImovelId",
                table: "Reservas",
                column: "ImovelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.CreateTable(
                name: "Avaliacoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    Estrelas = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "86ce6b12-eea9-4d59-aa65-23b0596aec85", "AQAAAAEAACcQAAAAEHD8in9g2v83P1qr0tRvVrmWL6s/TyYl5OYsvNo6d2zjIsjiU8gF0PwxxZEUYSfLfw==", "3b4dff7b-302f-4536-b81e-aaa786f2467d" });

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_ClienteId",
                table: "Avaliacoes",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Avaliacoes_ImovelId",
                table: "Avaliacoes",
                column: "ImovelId");
        }
    }
}
