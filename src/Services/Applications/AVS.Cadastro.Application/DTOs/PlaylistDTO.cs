namespace AVS.Cadastro.Application.DTOs
{
    public class PlaylistDTO
    {
        public Guid Id {  get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string? Foto { get; set; }
        public Guid? UsuarioId { get; set; }
        public List<MusicaDTO> Musicas { get; set; }
    }
}
