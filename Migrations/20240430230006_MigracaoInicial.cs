using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DS.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_LIVROS",
                table: "TB_LIVROS");

            migrationBuilder.RenameTable(
                name: "TB_LIVROS",
                newName: "TB_LIVROS");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TB_LIVROS",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Gênero",
                table: "TB_LIVROS",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Autor",
                table: "TB_LIVROS",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "TB_LIVROS",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_LIVROS",
                table: "TB_LIVROS",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TB_USUARIOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false, defaultValue: "Comprador"),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    listaLivro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIOS", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "TB_LIVROS",
                keyColumn: "Id",
                keyValue: 1,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_LIVROS",
                keyColumn: "Id",
                keyValue: 2,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_LIVROS",
                keyColumn: "Id",
                keyValue: 3,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_LIVROS",
                keyColumn: "Id",
                keyValue: 4,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "TB_LIVROS",
                keyColumn: "Id",
                keyValue: 5,
                column: "UsuarioId",
                value: 1);

            migrationBuilder.InsertData(
                table: "TB_USUARIOS",
                columns: new[] { "Id", "Email", "Nome", "PasswordHash", "PasswordSalt", "Username", "listaLivro" },
                values: new object[] { 1, "seuEmail@gmail.com", "Admin", new byte[] { 196, 163, 70, 110, 251, 51, 93, 223, 106, 94, 151, 45, 71, 131, 220, 241, 239, 192, 215, 239, 42, 65, 209, 187, 91, 184, 40, 65, 124, 169, 200, 222, 249, 48, 214, 79, 65, 247, 241, 14, 69, 45, 144, 243, 243, 107, 220, 251, 137, 153, 44, 147, 116, 117, 212, 53, 93, 154, 69, 10, 121, 241, 177, 47 }, new byte[] { 33, 18, 125, 46, 179, 79, 14, 105, 52, 163, 51, 114, 137, 240, 208, 162, 70, 251, 69, 204, 56, 43, 122, 126, 37, 239, 255, 70, 145, 118, 84, 42, 255, 90, 219, 29, 140, 214, 166, 169, 184, 67, 150, 19, 121, 144, 158, 68, 196, 170, 97, 241, 234, 230, 221, 36, 47, 203, 27, 197, 19, 255, 165, 156, 134, 115, 119, 66, 35, 113, 131, 255, 30, 26, 111, 119, 198, 37, 252, 137, 77, 104, 138, 220, 113, 92, 129, 159, 180, 150, 87, 73, 73, 207, 29, 104, 75, 22, 240, 203, 247, 50, 229, 178, 141, 189, 18, 103, 138, 92, 152, 220, 85, 15, 243, 228, 133, 212, 175, 33, 187, 30, 59, 99, 197, 159, 183, 76 }, "UsuarioAdmin", 0 });

            migrationBuilder.CreateIndex(
                name: "IX_TB_LIVROS_UsuarioId",
                table: "TB_LIVROS",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_TB_LIVROS_TB_USUARIOS_UsuarioId",
                table: "TB_LIVROS",
                column: "UsuarioId",
                principalTable: "TB_USUARIOS",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TB_LIVROS_TB_USUARIOS_UsuarioId",
                table: "TB_LIVROS");

            migrationBuilder.DropTable(
                name: "TB_USUARIOS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_LIVROS",
                table: "TB_LIVROS");

            migrationBuilder.DropIndex(
                name: "IX_TB_LIVROS_UsuarioId",
                table: "TB_LIVROS");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TB_LIVROS");

            migrationBuilder.RenameTable(
                name: "TB_LIVROS",
                newName: "TB_LIVRO");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "TB_LIVRO",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Gênero",
                table: "TB_LIVRO",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Autor",
                table: "TB_LIVRO",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_LIVRO",
                table: "TB_LIVRO",
                column: "Id");
        }
    }
}
