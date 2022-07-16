namespace AVS.Banda.Application.DTOs
{
    public record BandaRequestDto(Guid Id, string Nome, string Descricao, string? Foto);
}
