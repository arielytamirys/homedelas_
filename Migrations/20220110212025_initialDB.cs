using Microsoft.EntityFrameworkCore.Migrations;

namespace homedelas.Migrations
{
    public partial class initialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contatos",
                columns: table => new
                {
                    Id_Contato = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhatsApp = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.Id_Contato);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id_Login = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Confirmar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id_Login);
                });

            migrationBuilder.CreateTable(
                name: "Cadastro_Vagas",
                columns: table => new
                {
                    Id_Cadastro_Vaga = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Empresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Responsavel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Setor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vaga = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginId_Login = table.Column<int>(type: "int", nullable: true),
                    ContatoId_Contato = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastro_Vagas", x => x.Id_Cadastro_Vaga);
                    table.ForeignKey(
                        name: "FK_Cadastro_Vagas_Contatos_ContatoId_Contato",
                        column: x => x.ContatoId_Contato,
                        principalTable: "Contatos",
                        principalColumn: "Id_Contato",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cadastro_Vagas_Logins_LoginId_Login",
                        column: x => x.LoginId_Login,
                        principalTable: "Logins",
                        principalColumn: "Id_Login",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vagas",
                columns: table => new
                {
                    Id_Vagas = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cadastro_VagaId_Cadastro_Vaga = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vagas", x => x.Id_Vagas);
                    table.ForeignKey(
                        name: "FK_Vagas_Cadastro_Vagas_Cadastro_VagaId_Cadastro_Vaga",
                        column: x => x.Cadastro_VagaId_Cadastro_Vaga,
                        principalTable: "Cadastro_Vagas",
                        principalColumn: "Id_Cadastro_Vaga",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inicials",
                columns: table => new
                {
                    Id_Inicial = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Buscar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VagasId_Vagas = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inicials", x => x.Id_Inicial);
                    table.ForeignKey(
                        name: "FK_Inicials_Vagas_VagasId_Vagas",
                        column: x => x.VagasId_Vagas,
                        principalTable: "Vagas",
                        principalColumn: "Id_Vagas",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cadastro_Vagas_ContatoId_Contato",
                table: "Cadastro_Vagas",
                column: "ContatoId_Contato");

            migrationBuilder.CreateIndex(
                name: "IX_Cadastro_Vagas_LoginId_Login",
                table: "Cadastro_Vagas",
                column: "LoginId_Login");

            migrationBuilder.CreateIndex(
                name: "IX_Inicials_VagasId_Vagas",
                table: "Inicials",
                column: "VagasId_Vagas");

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_Cadastro_VagaId_Cadastro_Vaga",
                table: "Vagas",
                column: "Cadastro_VagaId_Cadastro_Vaga");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inicials");

            migrationBuilder.DropTable(
                name: "Vagas");

            migrationBuilder.DropTable(
                name: "Cadastro_Vagas");

            migrationBuilder.DropTable(
                name: "Contatos");

            migrationBuilder.DropTable(
                name: "Logins");
        }
    }
}
