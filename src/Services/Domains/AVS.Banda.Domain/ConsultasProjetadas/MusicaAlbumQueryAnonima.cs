namespace AVS.Banda.Domain.ConsultasProjetadas
{
    public class MusicaAlbumQueryAnonima
    {
        public Guid Id { get; set; }
        public Guid AlbumId { get; set; }
        public string Nome { get; set; }
        public int Duracao { get; set; }
        public string DuracaoFormatada { get; set; }
        public string AlbumTitulo { get; set; }
    }
}
