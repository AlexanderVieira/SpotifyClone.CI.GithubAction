namespace AVS.Banda.Application.DTOs
{
    //public record AlbumResponseDto(Guid Id, Guid BandaId, string Titulo, string Descricao, string? Foto, IList<MusicaResponseDto> Musicas);
    public class AlbumResponseDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string? Foto { get; set; }
        public Guid BandaId { get; set; }        
        public IList<MusicaResponseDto> Musicas { get; set; }

        public AlbumResponseDto()
        {            
        }       
    }
}
