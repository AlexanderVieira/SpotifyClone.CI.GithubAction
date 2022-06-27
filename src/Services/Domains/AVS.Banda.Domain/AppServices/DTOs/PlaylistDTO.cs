using AVS.Banda.Domain.Entities;
using FluentValidation;

namespace AVS.Banda.Domain.AppServices.DTOs
{
    public class PlaylistDTO
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string? Foto { get; set; }
        public Guid UsuarioId { get; set; }
        public IList<MusicaPlaylistDTO> Musicas { get; set; }

        public PlaylistDTO(Guid id, Guid usuarioId, string titulo, string descricao, string? foto)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Foto = foto;
            UsuarioId = usuarioId;
            Musicas = new List<MusicaPlaylistDTO>();
        }

        public static PlaylistDTO ConverterParaPlaylistDTO(Playlist playlist)
        {
            var playlistDTO = new PlaylistDTO(playlist.Id, playlist.UsuarioId, playlist.Titulo, playlist.Descricao, playlist.Foto);
            
            if (playlist.Musicas != null && playlist.Musicas.Count > 0)
            {                
                var musicasDTO = playlistDTO.Musicas.Select(x => x.Musica).AsEnumerable();
                var musicas = playlist.Musicas.Select(x => x.Musica).AsEnumerable();
                foreach (var musica in musicas)
                {
                    musicasDTO = musicasDTO.Append(new MusicaDTO(musica.Id, musica.AlbumId, musica.Nome, musica.Duracao.Valor));
                    var mp = new MusicaPlaylistDTO { PlaylistId = playlistDTO.Id, MusicaId = musica.Id };
                    mp.Musica = new MusicaDTO(musica.Id, musica.AlbumId, musica.Nome, musica.Duracao.Valor);
                    playlistDTO.Musicas.Add(mp);
                }
            }
            return playlistDTO;
        }

        public static Playlist ConverterParaPlaylist(PlaylistDTO playlistDTO)
        {
            var playlist = new Playlist(playlistDTO.Id, playlistDTO.UsuarioId, playlistDTO.Titulo, playlistDTO.Descricao, playlistDTO.Foto);
            
            if (playlistDTO.Musicas != null && playlistDTO.Musicas.Count > 0)
            {
                var musicas = new List<Musica>();
                foreach (var musica in playlistDTO.Musicas)
                {
                    //musicas.Add(new Musica(musica.Id, musica.AlbumId, musica.Nome, musica.Duracao));
                    //playlist.AtualizarMusicas(musicas);
                }
            }

            return playlist;
        }
        public bool EhValido()
        {
            var validationResult = new PlaylistDTOValidator().Validate(this);
            return validationResult.IsValid;
        }
    }

    public class PlaylistDTOValidator : AbstractValidator<PlaylistDTO>
    {
        public PlaylistDTOValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id da playlist inválido.");

            RuleFor(x => x.UsuarioId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do usuário inválido.");

            RuleFor(x => x.Titulo)
                .NotEmpty()
                .WithMessage("Titulo é obrigatório.")
                .Length(2, 150)
                .WithMessage("O Titulo deve ter entre 2 a 150 caracteres.");

            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("Descrição é obrigatório.")
                .Length(2, 250)
                .WithMessage("O Titulo deve ter entre 2 a 250 caracteres.");

            RuleFor(x => x.Foto)
                .NotEmpty()
                .WithMessage("Foto é obrigatória.");
        }

    }
}
