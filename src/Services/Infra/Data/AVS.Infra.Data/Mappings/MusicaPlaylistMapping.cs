using AVS.Banda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AVS.Infra.Data.Mappings
{
    public class MusicaPlaylistMapping : IEntityTypeConfiguration<MusicaPlaylist>
    {
        public void Configure(EntityTypeBuilder<MusicaPlaylist> builder)
        {
            builder
                .HasKey(mp => new { mp.PlaylistId, mp.MusicaId });

            builder.HasOne(mp => mp.Playlist)
                .WithMany(x => x.Musicas)
                .HasForeignKey(x => x.PlaylistId);

            builder.HasOne(mp => mp.Musica)
                .WithMany(x => x.Playlists)
                .HasForeignKey(x => x.MusicaId);

            builder.ToTable("MUSICA_PLAYLIST");
        }
    }
}
