namespace AVS.Banda.Application.DTOs
{
    //public record PlaylistResponseDto(Guid Id, string Titulo, string Descricao, string? Foto, IList<MusicaPlaylistResponseDto> Musicas);

    public class PlaylistResponseDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string? Foto { get; set; }
        public Guid UsuarioId { get; set; }
        public IList<MusicaPlaylistResponseDto> Musicas { get; set; }

        public PlaylistResponseDto()
        {
        }
    }
}
