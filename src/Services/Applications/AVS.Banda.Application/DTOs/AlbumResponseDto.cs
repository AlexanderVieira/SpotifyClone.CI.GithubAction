namespace AVS.Banda.Application.DTOs
{
    public record AlbumResponseDto(Guid Id, string Titulo, string Descricao, string? Foto, Guid BandaId, IList<MusicaResponseDto> Musicas);
}
