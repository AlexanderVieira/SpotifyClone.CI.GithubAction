using AVS.Banda.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AVS.Infra.Data.Mappings
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
                .HasColumnName("Duracao")
                .HasColumnType("int");

                tf.Property(u => u.Formatado)
                .IsRequired()
                .HasColumnName("Duracao_Formatada");
            });                      

            builder.ToTable("MUSICAS");
        }
    }
}
