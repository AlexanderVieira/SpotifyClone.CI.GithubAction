namespace AVS.Banda.Application.DTOs
{
    public class MusicaQueryAnonimaResponseDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Duracao { get; set; }
        public Guid AlbumId { get; set; }
        public string TituloAlbum { get; set; }

        public MusicaQueryAnonimaResponseDto()
        {
        }
    }
}
