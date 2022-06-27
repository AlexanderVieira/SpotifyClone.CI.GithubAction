namespace AVS.Banda.Domain.AppServices.DTOs
{
    public class AlbumDTO
    {
        public Guid Id {  get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string? Foto { get; set; }
        public Guid BandaId { get; set; }
        public IList<MusicaDTO> Musicas { get; set; }

        public AlbumDTO(Guid id, Guid bandaId, string titulo, string descricao, string? foto)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Foto = foto;
            BandaId = bandaId;
            Musicas = new List<MusicaDTO>();
        }
    }
}
