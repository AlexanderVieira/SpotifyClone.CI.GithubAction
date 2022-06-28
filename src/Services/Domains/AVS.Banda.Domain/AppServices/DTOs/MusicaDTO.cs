﻿using AVS.Banda.Domain.Entities;

namespace AVS.Banda.Domain.AppServices.DTOs
{
    public class MusicaDTO
    {
        public Guid Id { get; set; }
        public Guid AlbumId { get; set; }
        public string Nome { get; set; }
        public int Duracao { get; set; }
        public string DuracaoFormatada { get; set; }
        public IList<PlaylistDTO> Playlists { get; set; }

        public MusicaDTO(Guid id, Guid albumId, string nome, int duracao)
        {
            Id = id;
            AlbumId = albumId;
            Nome = nome;
            Duracao = duracao;
            Playlists = new List<PlaylistDTO>();
        }

        public static MusicaDTO ConverterParaMusicaDTO(Musica musica)
        {
            var musicaDTO = new MusicaDTO(musica.Id, musica.AlbumId,musica.Nome, musica.Duracao.Valor);
            return musicaDTO;
        }
    }
}