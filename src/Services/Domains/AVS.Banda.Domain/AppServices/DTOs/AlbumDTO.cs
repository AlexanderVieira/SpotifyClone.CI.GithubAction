using AVS.Banda.Domain.Entities;
using FluentValidation;

namespace AVS.Banda.Domain.AppServices.DTOs
{
    public class AlbumDTO
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string? Foto { get; set; }
        public Guid BandaId { get; set; }
        public IList<MusicaDTO> Musicas { get; set; }

        public AlbumDTO(Guid id, Guid bandaId, string titulo, string descricao, string? foto)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Foto = foto;
            BandaId = bandaId;
            Musicas = new List<MusicaDTO>();
        }

        public static Album ConverterParaAlbum(AlbumDTO albumDTO)
        {
            var album = new Album(albumDTO.Id, albumDTO.BandaId, albumDTO.Titulo, albumDTO.Descricao, albumDTO.Foto);

            if (albumDTO.Musicas != null && albumDTO.Musicas.Count > 0)
            {
                var musicas = new List<Musica>();
                foreach (var musicaDTO in albumDTO.Musicas)
                {
                    var musica = new Musica(musicaDTO.Id, musicaDTO.AlbumId, musicaDTO.Nome, musicaDTO.Duracao);

                    if (musicaDTO.Playlists != null && musicaDTO.Playlists.Count > 0)
                    {
                        //foreach (var playlistDTO in musicaDTO.Playlists)
                        //{
                        //    musica.Playlists.Add(new Playlist(playlistDTO.Id,
                        //        playlistDTO.UsuarioId, playlistDTO.Titulo, playlistDTO.Descricao, playlistDTO.Foto));
                        //}
                    }
                    musicas.Add(musica);
                }
                album.AtualizarMusicas(musicas);

            }
            return album;
        }

        public static AlbumDTO ConverterParaAlbumDTO(Album album)
        {
            var albumDTO = new AlbumDTO(album.Id, album.BandaId, album.Titulo, album.Descricao, album.Foto);
            var musicasDTO = new List<MusicaDTO>();

            if (album.Musicas != null && album.Musicas.Count > 0)
            {
                foreach (var musica in album.Musicas)
                {
                    var musicaDTO = new MusicaDTO(musica.Id, musica.AlbumId, musica.Nome, musica.Duracao.Valor);

                    if (musica.Playlists != null && musica.Playlists.Count > 0)
                    {
                        foreach (var playlist in musica.Playlists)
                        {
                            //musicaDTO.Playlists.Add(new PlaylistDTO(playlist.Id, 
                            //    playlist.UsuarioId, playlist.Titulo, playlist.Descricao, playlist.Foto));                                    
                        }
                    }
                    musicasDTO.Add(musicaDTO);
                }

            }
            albumDTO.Musicas = musicasDTO;
            return albumDTO;
        }

    }

    public class AlbumDTOValidator : AbstractValidator<AlbumDTO>
    {
        public AlbumDTOValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id da banda inválido.");

            RuleFor(x => x.Titulo)
                .NotEmpty()
                .WithMessage("Nome é obrigatório.")
                .Length(2, 150)
                .WithMessage("O Nome deve ter entre 2 a 150 caracteres.");

            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("Descrição é obrigatório.")
                .Length(2, 250)
                .WithMessage("A Descrição deve ter entre 2 a 250 caracteres.");

            //RuleFor(x => x.Foto)
            //    .NotEmpty()
            //    .WithMessage("Foto é obrigatória.");
        }

    }
}
