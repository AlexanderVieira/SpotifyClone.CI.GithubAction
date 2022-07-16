namespace AVS.Banda.Application.DTOs
{
    public record MusicaRequestDto(Guid Id, string Nome, int Duracao, Guid AlbumId);
}