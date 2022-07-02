using FluentValidation;

namespace AVS.Banda.Domain.AppServices.DTOs
{
    public class MusicaPlaylistDTO
    {        
        public Guid PlaylistId { get; set; }
        public Guid MusicaId { get; set; }
        public PlaylistDTO Playlist { get; set; }
        public MusicaDTO Musica { get; set; }

        public bool EhValido()
        {
            var validationResult = new MusicaPlaylistDTOValidator().Validate(this);
            return validationResult.IsValid;
        }

    }

    public class MusicaPlaylistDTOValidator : AbstractValidator<MusicaPlaylistDTO>
    {
        public MusicaPlaylistDTOValidator()
        {
            RuleFor(x => x.PlaylistId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id da playlist inválido.");

            RuleFor(x => x.MusicaId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id da música inválido.");

        }

    }
}
