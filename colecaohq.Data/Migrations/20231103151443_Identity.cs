using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace colecaohq.Data.Migrations
{
    public partial class Identity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Editora",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NomeEditora = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editora", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipePerssonagem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NomeEquipePerssonagem = table.Column<string>(type: "varchar(200)", nullable: false),
                    DescricaoEquipePerssonagem = table.Column<string>(type: "varchar(MAX)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipePerssonagem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TituloHQ",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EditoraId = table.Column<Guid>(nullable: false),
                    Titulo = table.Column<string>(type: "varchar(200)", nullable: false),
                    TituloOriginal = table.Column<string>(type: "varchar(200)", nullable: true),
                    TipoPublicacao = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    TotalEdicoes = table.Column<string>(type: "varchar(200)", nullable: true),
                    EdicoesPossuidas = table.Column<string>(type: "varchar(200)", nullable: true),
                    Sinopse = table.Column<string>(type: "varchar(MAX)", nullable: true),
                    AnoLancamento = table.Column<string>(type: "varchar(4)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TituloHQ", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TituloHQ_Editora_EditoraId",
                        column: x => x.EditoraId,
                        principalTable: "Editora",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HqPerssonagem",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    TituloHqId = table.Column<Guid>(nullable: false),
                    EquipePerssonagemId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HqPerssonagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HqPerssonagem_EquipePerssonagem_EquipePerssonagemId",
                        column: x => x.EquipePerssonagemId,
                        principalTable: "EquipePerssonagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HqPerssonagem_TituloHQ_TituloHqId",
                        column: x => x.TituloHqId,
                        principalTable: "TituloHQ",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HqPerssonagem_EquipePerssonagemId",
                table: "HqPerssonagem",
                column: "EquipePerssonagemId");

            migrationBuilder.CreateIndex(
                name: "IX_HqPerssonagem_TituloHqId",
                table: "HqPerssonagem",
                column: "TituloHqId");

            migrationBuilder.CreateIndex(
                name: "IX_TituloHQ_EditoraId",
                table: "TituloHQ",
                column: "EditoraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HqPerssonagem");

            migrationBuilder.DropTable(
                name: "EquipePerssonagem");

            migrationBuilder.DropTable(
                name: "TituloHQ");

            migrationBuilder.DropTable(
                name: "Editora");
        }
    }
}
