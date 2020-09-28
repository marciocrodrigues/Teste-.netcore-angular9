using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paschoalotto.Infra.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parametrizacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MaximoParcelas = table.Column<short>(type: "smallint", nullable: false),
                    TipoJuros = table.Column<string>(type: "char(1)", maxLength: 1, nullable: false),
                    PorcertagemJuros = table.Column<decimal>(type: "numeric(8,4)", nullable: false),
                    PorcentagemComissao = table.Column<decimal>(type: "numeric(8,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parametrizacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Codigo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Senha = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Documento = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    Telefone = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Divida",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ValorOriginal = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    DocumentoDevedor = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divida", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Divida_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Codigo", "Documento", "Nome", "Senha", "Telefone" },
                values: new object[] { new Guid("b679d5e5-6315-4450-bc5e-0fc3dcc042ac"), "6521e4cc7a", "12345678909", "administrador", "123456", "00000000000" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Codigo", "Documento", "Nome", "Senha", "Telefone" },
                values: new object[] { new Guid("e43ed5da-3880-4641-a5d3-196f4d9dc44b"), "70efa5d926", "12345678910", "administrador2", "123456", "00000000000" });

            migrationBuilder.CreateIndex(
                name: "IX_Divida_UsuarioId",
                table: "Divida",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Divida");

            migrationBuilder.DropTable(
                name: "Parametrizacao");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
