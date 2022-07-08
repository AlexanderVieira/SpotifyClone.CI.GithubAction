namespace AVS.Banda.Application.DTOs
{
    public record PlaylistRequestDto(Guid UsuarioId, string Titulo, string Descricao, string? Foto);
}