using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AVS.Infra.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BANDAS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(100)", nullable: false),
                    Foto = table.Column<string>(type: "varchar(250)", nullable: true),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BANDAS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USUARIOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Email = table.Column<string>(type: "varchar(254)", nullable: false),
                    Cpf = table.Column<string>(type: "varchar(11)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Foto = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ALBUNS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    Foto = table.Column<string>(type: "varchar(250)", nullable: true),
                    BandaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ALBUNS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ALBUNS_BANDAS_BandaId",
                        column: x => x.BandaId,
                        principalTable: "BANDAS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PLAYLISTS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "varchar(100)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    Foto = table.Column<string>(type: "varchar(250)", nullable: true),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PLAYLISTS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PLAYLISTS_USUARIOS_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "USUARIOS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MUSICAS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Duracao = table.Column<int>(type: "int", nullable: false),
                    Duracao_Formatada = table.Column<string>(type: "varchar(100)", nullable: false),
                    AlbumId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MUSICAS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MUSICAS_ALBUNS_AlbumId",
                        column: x => x.AlbumId,
                        principalTable: "ALBUNS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MusicaPlaylist",
                columns: table => new
                {
                    MusicasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlaylistsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicaPlaylist", x => new { x.MusicasId, x.PlaylistsId });
                    table.ForeignKey(
                        name: "FK_MusicaPlaylist_MUSICAS_MusicasId",
                        column: x => x.MusicasId,
                        principalTable: "MUSICAS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MusicaPlaylist_PLAYLISTS_PlaylistsId",
                        column: x => x.PlaylistsId,
                        principalTable: "PLAYLISTS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALBUNS_BandaId",
                table: "ALBUNS",
                column: "BandaId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicaPlaylist_PlaylistsId",
                table: "MusicaPlaylist",
                column: "PlaylistsId");

            migrationBuilder.CreateIndex(
                name: "IX_MUSICAS_AlbumId",
                table: "MUSICAS",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_PLAYLISTS_UsuarioId",
                table: "PLAYLISTS",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MusicaPlaylist");

            migrationBuilder.DropTable(
                name: "MUSICAS");

            migrationBuilder.DropTable(
                name: "PLAYLISTS");

            migrationBuilder.DropTable(
                name: "ALBUNS");

            migrationBuilder.DropTable(
                name: "USUARIOS");

            migrationBuilder.DropTable(
                name: "BANDAS");
        }
    }
}
