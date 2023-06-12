using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApiPTI.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nrCpf = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dtNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nmProfissao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dtPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nrTelefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nmEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nrCpf = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dtAula = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id_Professor = table.Column<int>(type: "int", nullable: false),
                    Id_Aluno = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aula_Aluno_Id_Aluno",
                        column: x => x.Id_Aluno,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Aula_Professores_Id_Professor",
                        column: x => x.Id_Professor,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contrato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dtPagamento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false),
                    Id_Aluno = table.Column<int>(type: "int", nullable: false),
                    Id_Professor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contrato_Aluno_Id_Aluno",
                        column: x => x.Id_Aluno,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contrato_Professores_Id_Professor",
                        column: x => x.Id_Professor,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aula_Id_Aluno",
                table: "Aula",
                column: "Id_Aluno");

            migrationBuilder.CreateIndex(
                name: "IX_Aula_Id_Professor",
                table: "Aula",
                column: "Id_Professor");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_Id_Aluno",
                table: "Contrato",
                column: "Id_Aluno");

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_Id_Professor",
                table: "Contrato",
                column: "Id_Professor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aula");

            migrationBuilder.DropTable(
                name: "Contrato");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
