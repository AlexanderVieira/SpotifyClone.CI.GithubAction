namespace AVS.Banda.Application.DTOs
{
    public record BandaResponseDto(Guid Id, string Nome, string Descricao, string? Foto, IList<AlbumResponseDto> Albuns);
}
