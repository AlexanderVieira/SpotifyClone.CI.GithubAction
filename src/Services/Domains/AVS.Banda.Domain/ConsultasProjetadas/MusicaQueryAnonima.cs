﻿namespace AVS.Banda.Domain.ConsultasProjetadas
{
    public class MusicaQueryAnonima
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string DuracaoFormatada { get; set; }
        public Guid AlbumId { get; set; }
        public string TituloAlbum { get; set; }

        public MusicaQueryAnonima()
        {
        }
    }
}
