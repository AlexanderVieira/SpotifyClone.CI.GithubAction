namespace AVS.Banda.Application.DTOs
{
    //public record PlaylistRequestDto(Guid Id, Guid UsuarioId, string Titulo, string Descricao, string? Foto);
    public class PlaylistRequestDto
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string? Foto { get; set; }
        public Guid UsuarioId { get; set; }

        public PlaylistRequestDto()
        {
        }
    }
}