using AVS.Banda.Application.DTOs;

namespace AVS.Cadastro.Application.DTOs
{
    public record UsuarioResponseDto(Guid Id, string Nome, string Email, string Cpf, bool Ativo, string? Foto, IList<PlaylistResponseDto> Playlists);
}
