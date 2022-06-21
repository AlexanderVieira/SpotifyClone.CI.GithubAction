﻿using AVS.Banda.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AVS.Infra.Data.Mappings
{
    public class AlbumMapping : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Titulo)
                .IsRequired()
                .HasColumnName("Titulo")
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnName("Descricao")
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Foto)                
                .HasColumnName("Foto")
                .HasColumnType("varchar(250)");

            builder.HasMany(a => a.Musicas)
                .WithOne(m => m.Album);

            builder.ToTable("ALBUNS");

        }
    }
}
