namespace AVS.Banda.Application.DTOs
{
    public record BandaResponseDto(Guid Id, string Nome, string Descricao, string? Foto, IList<AlbumResponseDto> Albuns);
    //public class BandaResponseDto
    //{
    //    public Guid Id { get; set; }
    //    public string Nome { get; set; }
    //    public string Descricao { get; set; }
    //    public string? Foto { get; set; }
    //    public IList<AlbumResponseDto> Albuns { get; set; }

    //    public BandaResponseDto()
    //    {
    //    }

    //    public BandaResponseDto(Guid id, string nome, string descricao, string? foto)
    //    {
    //        Id = id;
    //        Nome = nome;
    //        Descricao = descricao;
    //        Foto = foto;
    //        Albuns = new List<AlbumResponseDto>();
    //    }
    //}
}
