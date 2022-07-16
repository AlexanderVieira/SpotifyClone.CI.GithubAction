using AVS.Core.ObjDoinio;
using FluentValidation;

namespace AVS.Banda.Domain.Entities
{
    public class MusicaPlaylist
    {
        public Guid PlaylistId { get; set; }
        public Guid MusicaId { get; set; }
        public virtual Playlist Playlist { get; set; }
        public virtual Musica Musica { get; set; }

        public MusicaPlaylist()
        {
        }

        public bool EhValido()
        {
            var validationResult = new MusicaPlaylistValidator().Validate(this);
            return validationResult.IsValid;
        }
        public void Validar() =>
            new MusicaPlaylistValidator().ValidateAndThrow(this);

    }

    public class MusicaPlaylistValidator : AbstractValidator<MusicaPlaylist>
    {
        public MusicaPlaylistValidator()
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
