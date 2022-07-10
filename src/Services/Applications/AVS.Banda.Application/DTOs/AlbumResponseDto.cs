namespace AVS.Banda.Application.DTOs
{
    public record AlbumResponseDto(Guid Id, Guid BandaId, string Titulo, string Descricao, string? Foto, IList<MusicaResponseDto> Musicas);
    //public class AlbumResponseDto
    //{
    //    public Guid Id { get; set; }
    //    public string Titulo { get; private set; }
    //    public string Descricao { get; private set; }
    //    public string? Foto { get; private set; }
    //    public Guid BandaId { get; private set; }
    //    public virtual BandaResponseDto Banda { get; set; }
    //    public virtual IList<MusicaResponseDto> Musicas { get; private set; }

    //    public AlbumResponseDto()
    //    {
    //    }

    //    public AlbumResponseDto(Guid id, Guid bandaId, string titulo, string descricao, string? foto)
    //    {
    //        Id = id;
    //        BandaId = bandaId;
    //        Titulo = titulo;
    //        Descricao = descricao;
    //        Foto = foto;
    //        Musicas = new List<MusicaResponseDto>();
    //    }
    //}
}
