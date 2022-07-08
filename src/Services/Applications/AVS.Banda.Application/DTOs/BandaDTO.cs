using AVS.Banda.Domain.Entities;
using FluentValidation;

namespace AVS.Banda.Domain.AppServices.DTOs
{
    public class BandaDTO
    {
        public Guid Id {  get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string? Foto { get; set; }        
        public IList<AlbumDTO> Albuns { get; set; }

        public BandaDTO(Guid id, string nome, string descricao, string? foto)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Foto = foto;
            Albuns = new List<AlbumDTO>();
        }

        public bool EhValido()
        {
            var validationResult = new BandaDTOValidator().Validate(this);
            return validationResult.IsValid;
        }

        public static Entities.Banda ConverterParaBanda(BandaDTO bandaDTO)
        {
            var banda = new Entities.Banda(bandaDTO.Id, bandaDTO.Nome, bandaDTO.Descricao, bandaDTO.Foto);
            
            if (bandaDTO.Albuns != null && bandaDTO.Albuns.Count > 0)
            {
                foreach (var albumDTO in bandaDTO.Albuns)
                {
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
                        
                        banda.CriarAlbum(albumDTO.Id, albumDTO.BandaId, albumDTO.Titulo, albumDTO.Descricao, albumDTO.Foto, musicas);

                    }

                }
            }
            return banda;
        }

        public static BandaDTO ConverterParaBandaDTO(Entities.Banda banda)
        {
            var bandaDTO = new BandaDTO(banda.Id, banda.Nome, banda.Descricao, banda.Foto);            
            var musicasDTO = new List<MusicaDTO>();

            if (banda.Albuns != null && banda.Albuns.Count > 0)
            {
                foreach (var album in banda.Albuns)
                {                    
                    if (album.Musicas != null && album.Musicas.Count > 0)
                    {
                        
                        foreach (var musica in album.Musicas)
                        {
                            var musicaDTO = new MusicaDTO(musica.Id, musica.AlbumId, musica.Nome, musica.Duracao.Valor, musica.Duracao.Formatado);                        
                                                        
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
                    var albumDTO = new AlbumDTO(album.Id, album.BandaId, album.Titulo, album.Descricao, album.Foto);
                    albumDTO.Musicas = musicasDTO;
                    bandaDTO.Albuns.Add(albumDTO);

                }
            }           

            return bandaDTO;
        }
    }

    public class BandaDTOValidator : AbstractValidator<BandaDTO>
    {
        public BandaDTOValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id da banda inválido.");                        

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório.")
                .Length(2, 150)
                .WithMessage("O Nome deve ter entre 2 a 150 caracteres.");

            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("Descrição é obrigatório.")
                .Length(2, 250)
                .WithMessage("A Descrição deve ter entre 2 a 250 caracteres.");

            RuleFor(x => x.Foto)
                .NotEmpty()
                .WithMessage("Foto é obrigatória.");
        }

    }
}
