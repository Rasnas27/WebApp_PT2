using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webApiPTI.Migrations
{
    public partial class Thirgmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aluno_Professores_Id_Professor",
                table: "Aluno");

            migrationBuilder.DropIndex(
                name: "IX_Aluno_Id_Professor",
                table: "Aluno");

            migrationBuilder.DropColumn(
                name: "Id_Professor",
                table: "Aluno");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_Professor",
                table: "Aluno",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_Id_Professor",
                table: "Aluno",
                column: "Id_Professor");

            migrationBuilder.AddForeignKey(
                name: "FK_Aluno_Professores_Id_Professor",
                table: "Aluno",
                column: "Id_Professor",
                principalTable: "Professores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
