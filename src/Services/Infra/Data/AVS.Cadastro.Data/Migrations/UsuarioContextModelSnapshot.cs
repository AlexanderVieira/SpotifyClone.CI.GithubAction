﻿// <auto-generated />
using System;
using AVS.Cadastro.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AVS.Cadastro.Data.Migrations
{
    [DbContext(typeof(UsuarioContext))]
    partial class UsuarioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AVS.Banda.Domain.Musica", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid>("PlaylistId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PlaylistId");

                    b.ToTable("Musica", (string)null);
                });

            modelBuilder.Entity("AVS.Cadastro.Domain.Entities.Playlist", b =>
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

                    b.ToTable("Playlist", (string)null);
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

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("AVS.Banda.Domain.Musica", b =>
                {
                    b.HasOne("AVS.Cadastro.Domain.Entities.Playlist", null)
                        .WithMany("Musicas")
                        .HasForeignKey("PlaylistId")
                        .IsRequired()
                        .HasConstraintName("FK_Playlist_Musica");

                    b.OwnsOne("AVS.Core.ObjValor.Duracao", "Duracao", b1 =>
                        {
                            b1.Property<Guid>("MusicaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Valor")
                                .HasColumnType("int")
                                .HasColumnName("Duracao");

                            b1.HasKey("MusicaId");

                            b1.ToTable("Musica");

                            b1.WithOwner()
                                .HasForeignKey("MusicaId");
                        });

                    b.Navigation("Duracao")
                        .IsRequired();
                });

            modelBuilder.Entity("AVS.Cadastro.Domain.Entities.Playlist", b =>
                {
                    b.HasOne("AVS.Cadastro.Domain.Entities.Usuario", null)
                        .WithMany("Playlists")
                        .HasForeignKey("UsuarioId")
                        .IsRequired()
                        .HasConstraintName("FK_Usuario_Playlist");
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

                            b1.ToTable("Usuario");

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

                            b1.ToTable("Usuario");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioId");
                        });

                    b.Navigation("Cpf")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();
                });

            modelBuilder.Entity("AVS.Cadastro.Domain.Entities.Playlist", b =>
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
