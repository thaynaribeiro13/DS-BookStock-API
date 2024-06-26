using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DS.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_LIVROS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gênero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegistroLivro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_LIVROS", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TB_LIVROS",
                columns: new[] { "Id", "Autor", "Gênero", "Nome", "RegistroLivro" },
                values: new object[,]
                {
                    { 1, "Emily Trunko", "Drama", "Últimas Mensagens Recebidas", 0 },
                    { 2, "Taylor Jenkins Reid", "Romance", "Os Sete Maridos de Evelyn Hugo", 0 },
                    { 3, "C. C. Hunter", "Romance", "Eu e Esse Meu Coração", 0 },
                    { 4, "Suzanne Collins", "Distopia Adolescente", "Jogos Vorazes", 0 },
                    { 5, "V. E. Schwab", "Fantasia", "A Sociedade Invisível de Addie LaRue", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_LIVROS");
        }
    }
}
