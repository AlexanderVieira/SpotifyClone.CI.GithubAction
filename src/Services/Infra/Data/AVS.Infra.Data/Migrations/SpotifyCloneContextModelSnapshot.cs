﻿// <auto-generated />
using System;
using AVS.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AVS.Infra.Data.Migrations
{
    [DbContext(typeof(SpotifyCloneContext))]
    partial class SpotifyCloneContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AVS.Banda.Domain.Entities.Album", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BandaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Descricao");

                    b.Property<string>("Foto")
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Foto");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Titulo");

                    b.HasKey("Id");

                    b.HasIndex("BandaId");

                    b.ToTable("ALBUNS", (string)null);
                });

            modelBuilder.Entity("AVS.Banda.Domain.Entities.Banda", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Descricao");

                    b.Property<string>("Foto")
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Foto");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("BANDAS", (string)null);
                });

            modelBuilder.Entity("AVS.Banda.Domain.Entities.Musica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AlbumId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("MUSICAS", (string)null);
                });

            modelBuilder.Entity("AVS.Banda.Domain.Entities.MusicaPlaylist", b =>
                {
                    b.Property<Guid>("PlaylistId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MusicaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PlaylistId", "MusicaId");

                    b.HasIndex("MusicaId");

                    b.ToTable("MUSICA_PLAYLIST", (string)null);
                });

            modelBuilder.Entity("AVS.Banda.Domain.Entities.Playlist", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Descricao");

                    b.Property<string>("Foto")
                        .HasColumnType("varchar(250)")
                        .HasColumnName("Foto");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Titulo");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("PLAYLISTS", (string)null);
                });

            modelBuilder.Entity("AVS.Cadastro.Domain.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Foto")
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Foto");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("USUARIOS", (string)null);
                });

            modelBuilder.Entity("AVS.Banda.Domain.Entities.Album", b =>
                {
                    b.HasOne("AVS.Banda.Domain.Entities.Banda", "Banda")
                        .WithMany("Albuns")
                        .HasForeignKey("BandaId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Banda");
                });

            modelBuilder.Entity("AVS.Banda.Domain.Entities.Musica", b =>
                {
                    b.HasOne("AVS.Banda.Domain.Entities.Album", "Album")
                        .WithMany("Musicas")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.OwnsOne("AVS.Core.ObjValor.Duracao", "Duracao", b1 =>
                        {
                            b1.Property<Guid>("MusicaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Formatado")
                                .IsRequired()
                                .HasColumnType("varchar(100)")
                                .HasColumnName("Duracao_Formatada");

                            b1.Property<int>("Valor")
                                .HasColumnType("int")
                                .HasColumnName("Duracao");

                            b1.HasKey("MusicaId");

                            b1.ToTable("MUSICAS");

                            b1.WithOwner()
                                .HasForeignKey("MusicaId");
                        });

                    b.Navigation("Album");

                    b.Navigation("Duracao")
                        .IsRequired();
                });

            modelBuilder.Entity("AVS.Banda.Domain.Entities.MusicaPlaylist", b =>
                {
                    b.HasOne("AVS.Banda.Domain.Entities.Musica", "Musica")
                        .WithMany("Playlists")
                        .HasForeignKey("MusicaId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.HasOne("AVS.Banda.Domain.Entities.Playlist", "Playlist")
                        .WithMany("Musicas")
                        .HasForeignKey("PlaylistId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Musica");

                    b.Navigation("Playlist");
                });

            modelBuilder.Entity("AVS.Banda.Domain.Entities.Playlist", b =>
                {
                    b.HasOne("AVS.Cadastro.Domain.Entities.Usuario", null)
                        .WithMany("Playlists")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AVS.Cadastro.Domain.Entities.Usuario", b =>
                {
                    b.OwnsOne("AVS.Core.ObjValor.Cpf", "Cpf", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnType("varchar(11)")
                                .HasColumnName("Cpf");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("USUARIOS");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.OwnsOne("AVS.Core.ObjValor.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("varchar(254)")
                                .HasColumnName("Email");

                            b1.HasKey("UsuarioId");

                            b1.ToTable("USUARIOS");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.Navigation("Cpf")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();
                });

            modelBuilder.Entity("AVS.Banda.Domain.Entities.Album", b =>
                {
                    b.Navigation("Musicas");
                });

            modelBuilder.Entity("AVS.Banda.Domain.Entities.Banda", b =>
                {
                    b.Navigation("Albuns");
                });

            modelBuilder.Entity("AVS.Banda.Domain.Entities.Musica", b =>
                {
                    b.Navigation("Playlists");
                });

            modelBuilder.Entity("AVS.Banda.Domain.Entities.Playlist", b =>
                {
                    b.Navigation("Musicas");
                });

            modelBuilder.Entity("AVS.Cadastro.Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Playlists");
                });
#pragma warning restore 612, 618
        }
    }
}