using AVS.Cadastro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AVS.Cadastro.Data.Mappings
{
    public class PlaylistMapping : IEntityTypeConfiguration<Playlist>
    {
        public void Configure(EntityTypeBuilder<Playlist> builder)
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

            builder.HasMany(p => p.Musicas)
                .WithOne()
                .HasForeignKey(m => m.PlaylistId)
                .HasConstraintName("FK_Playlist_Musica");
            
            builder.ToTable("Playlists");

        }
    }
}
