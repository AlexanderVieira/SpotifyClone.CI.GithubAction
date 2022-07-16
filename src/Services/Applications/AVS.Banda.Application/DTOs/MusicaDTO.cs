using AVS.Banda.Domain.Entities;
using FluentValidation;

namespace AVS.Banda.Domain.AppServices.DTOs
{
    public class MusicaDTO
    {
        public Guid Id { get; set; }
        public Guid AlbumId { get; set; }        
        public AlbumDTO Album { get; set; }
        public string Nome { get; set; }
        public int Duracao { get; set; }
        public string DuracaoFormatada { get; set; }
        public IList<PlaylistDTO> Playlists { get; set; }

        public MusicaDTO(Guid id, Guid albumId, string nome, int duracao, string duracaoFormatada)
        {
            Id = id;
            AlbumId = albumId;
            Nome = nome;
            Duracao = duracao;
            DuracaoFormatada = duracaoFormatada;
            Playlists = new List<PlaylistDTO>();
        }

        public static MusicaDTO ConverterParaMusicaDTO(Musica musica)
        {
            var musicaDTO = new MusicaDTO(musica.Id, 
                                          musica.AlbumId,
                                          musica.Nome, 
                                          musica.Duracao.Valor,
                                          musica.Duracao.Formatado);
                        
            if (musica.Album != null)
            {
                musicaDTO.Album = new AlbumDTO(musica.Album.Id,
                                           musica.Album.BandaId,
                                           musica.Album.Titulo,
                                           musica.Album.Descricao,
                                           musica.Album.Foto);
            }                         
            
            return musicaDTO;
        }

        public static Musica ConverterParaMusica(MusicaDTO musicaDTO)
        {
            var musica = new Musica(musicaDTO.Id, musicaDTO.AlbumId, musicaDTO.Nome, musicaDTO.Duracao);
            if (musicaDTO.Album != null)
            {
                musica.Album = new Album(musicaDTO.AlbumId,
                                          musicaDTO.Album.BandaId,
                                          musicaDTO.Album.Titulo,
                                          musicaDTO.Album.Descricao,
                                          musicaDTO.Album.Foto);
            }
            
            return musica;
        }
    }

    public class MusicaDTOValidator : AbstractValidator<MusicaDTO>
    {
        public MusicaDTOValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id da música inválido.");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório.")
                .Length(2, 150)
                .WithMessage("O Nome deve ter entre 2 a 150 caracteres.");

            RuleFor(x => x.Duracao)
                .NotEmpty()
                .WithMessage("Tempo de duração é obrigatório.");
        }

    }
}
