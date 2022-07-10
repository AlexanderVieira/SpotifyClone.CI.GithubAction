namespace AVS.Banda.Application.DTOs
{
    //public record MusicaResponseDto(Guid Id, Guid AlbumId, string Nome, string DuracaoFormatada, IList<MusicaPlaylistResponseDto> Playlists);

    //[AutoMap(typeof(Musica))]
    public class MusicaResponseDto
    {
        public Guid Id { get; set; }
        public Guid AlbumId { get; set; }

        //[Ignore]
        //public AlbumResponseDto Album { get; set; }
        public string Nome { get; set; }

        //public int Duracao { get; set; }
        public string DuracaoFormatada { get; set; }
        public IList<MusicaPlaylistResponseDto> Playlists { get; set; }

        public MusicaResponseDto()
        {
        }

    }
}
