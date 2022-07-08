namespace AVS.Banda.Application.DTOs
{
    public record PlaylistResponseDto(Guid Id, string Titulo, string Descricao, string? Foto, IList<MusicaResponseDto> Musicas);
}
