namespace AVS.Cadastro.Application.DTOs
{
    public record UsuarioRequestDto(Guid Id, string Nome, string Email, string Cpf, bool Ativo, string? Foto);
}