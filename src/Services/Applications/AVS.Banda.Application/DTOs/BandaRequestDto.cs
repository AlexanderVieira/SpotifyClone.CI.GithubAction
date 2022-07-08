namespace AVS.Banda.Application.DTOs
{
    public record BandaRequestDto(Guid Id, string Titulo, string Descricao, string? Foto);
}
