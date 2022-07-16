namespace AVS.Banda.Application.DTOs
{
    public record AlbumRequestDto(Guid Id, string Titulo, string Descricao, string? Foto, Guid BandaId);
}