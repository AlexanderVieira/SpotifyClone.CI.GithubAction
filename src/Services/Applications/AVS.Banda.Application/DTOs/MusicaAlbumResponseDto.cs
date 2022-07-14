namespace AVS.Banda.Application.DTOs
{    
    public class MusicaAlbumResponseDto
    {
        public Guid Id { get; set; }
        public Guid AlbumId { get; set; }        
        public string Nome { get; set; }

        //public int Duracao { get; set; }
        public string DuracaoFormatada { get; set; }
        public string TituloAlbum { get; set; }

        public MusicaAlbumResponseDto()
        {
        }

    }
}
