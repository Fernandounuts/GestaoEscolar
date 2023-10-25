using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestaoEscolar.Migrations
{
    /// <inheritdoc />
    public partial class relacaoDeptoInst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DepartamentoID",
                table: "Departamentos",
                newName: "DepartamentoId");

            migrationBuilder.AddColumn<long>(
                name: "fk_InstituicaoId",
                table: "Departamentos",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_fk_InstituicaoId",
                table: "Departamentos",
                column: "fk_InstituicaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamentos_Instituicoes_fk_InstituicaoId",
                table: "Departamentos",
                column: "fk_InstituicaoId",
                principalTable: "Instituicoes",
                principalColumn: "InstituicaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamentos_Instituicoes_fk_InstituicaoId",
                table: "Departamentos");

            migrationBuilder.DropIndex(
                name: "IX_Departamentos_fk_InstituicaoId",
                table: "Departamentos");

            migrationBuilder.DropColumn(
                name: "fk_InstituicaoId",
                table: "Departamentos");

            migrationBuilder.RenameColumn(
                name: "DepartamentoId",
                table: "Departamentos",
                newName: "DepartamentoID");
        }
    }
}
