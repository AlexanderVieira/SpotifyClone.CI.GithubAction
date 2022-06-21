using AVS.Banda.Domain.AppServices.DTOs;

namespace AVS.Banda.Domain.AppServices.DTO 
{ 
    public class BandaDTO
    {
        public Guid Id {  get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string? Foto { get; set; }
        public Guid BandaId { get; set; }
        public IList<AlbumDTO> Albuns { get; set; }
    }
}
