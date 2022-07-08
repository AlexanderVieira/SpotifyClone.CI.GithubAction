namespace AVS.Banda.Application.DTOs
{
    public record MusicaPlaylistResponseDto(Guid PlaylistId, Guid MusicaId, PlaylistResponseDto Playlist, MusicaResponseDto Musica);
}
