namespace AVS.Banda.Domain.ConsultasProjetadas
{
    public class PlaylistMusicasQueryAnomima
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }
        public Guid UsuarioId { get; set; }
        public IList<MusicaQueryAnonima> Musicas { get; set; }

        //public PlaylistMusicasQueryAnomima(Guid id, Guid usuarioId, string titulo, string descricao, string foto)
        //{
        //    Id = id;
        //    Titulo = titulo;
        //    Descricao = descricao;
        //    Foto = foto;
        //    Musicas = new List<MusicaQueryAnonima>();
        //    UsuarioId = usuarioId;
        //}
    }
}
