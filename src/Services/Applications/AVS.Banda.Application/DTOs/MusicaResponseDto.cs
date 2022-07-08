namespace AVS.Banda.Application.DTOs
{
    public record MusicaResponseDto(Guid Id, Guid AlbumId, AlbumResponseDto Album, string Nome, string DuracaoFormatada, IList<PlaylistResponseDto> Playlists);
}
