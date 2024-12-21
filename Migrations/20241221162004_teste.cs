using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExercicioInventarioMercados.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fornecedors_FornecedorId",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fornecedors",
                table: "Fornecedors");

            migrationBuilder.RenameTable(
                name: "Fornecedors",
                newName: "Fornecedores");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fornecedores",
                table: "Fornecedores",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_CategoriaId",
                table: "Produtos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorId",
                table: "Produtos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_CategoriaId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fornecedores_FornecedorId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CategoriaId",
                table: "Produtos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fornecedores",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "Produtos");

            migrationBuilder.RenameTable(
                name: "Fornecedores",
                newName: "Fornecedors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fornecedors",
                table: "Fornecedors",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fornecedors_FornecedorId",
                table: "Produtos",
                column: "FornecedorId",
                principalTable: "Fornecedors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
