namespace AVS.Banda.Application.DTOs
{
    public class PlaylistMusicasQueryAnonimaResponseDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public IList<MusicaQueryAnonimaResponseDto> Musicas { get; set; }

        public PlaylistMusicasQueryAnonimaResponseDto()
        {
        }
    }
}
