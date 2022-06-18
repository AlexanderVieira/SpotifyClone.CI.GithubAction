﻿using AVS.Banda.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AVS.Cadastro.Data.Mappings
{
    public class MusicaMapping : IEntityTypeConfiguration<Musica>
    {
        public void Configure(EntityTypeBuilder<Musica> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.OwnsOne(u => u.Duracao, tf =>
            {
                tf.Property(u => u.Valor)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("Duracao");

                tf.Property(u => u.Formatado)
                .IsRequired()                
                .HasColumnName("DuracaoFormatada");                
            });            
        }
    }
}
