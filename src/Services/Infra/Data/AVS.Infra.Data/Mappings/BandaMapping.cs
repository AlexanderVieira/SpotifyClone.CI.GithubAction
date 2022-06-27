using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AVS.Infra.Data.Mappings
{
    public class BandaMapping : IEntityTypeConfiguration<Banda.Domain.Entities.Banda>
    {
        public void Configure(EntityTypeBuilder<Banda.Domain.Entities.Banda> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnName("Descricao")
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Foto)                
                .HasColumnName("Foto")
                .HasColumnType("varchar(250)");

            builder.HasMany(b => b.Albuns)
                .WithOne(a => a.Banda)
                .HasForeignKey(a => a.BandaId);
            
            builder.ToTable("BANDAS");

        }
    }
}
