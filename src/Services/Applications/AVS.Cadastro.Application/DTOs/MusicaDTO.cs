namespace AVS.Cadastro.Application.DTOs
{
    public class MusicaDTO
    {
        public Guid Id { get; set; }
        public Guid? PlaylistId { get; set; }
        public string Nome { get; set; }
        public int  Duracao { get; set; }
    }
}
