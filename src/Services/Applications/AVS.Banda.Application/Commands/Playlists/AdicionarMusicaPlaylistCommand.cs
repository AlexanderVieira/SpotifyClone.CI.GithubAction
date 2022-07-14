using AVS.Banda.Application.DTOs;
using AVS.Core.Mensagens;
using FluentValidation;

namespace AVS.Banda.Application.Commands.Playlists
{
    public class AdicionarMusicaPlaylistCommand : Comando
    {
        public MusicaPlaylistRequestDto MusicaPlaylistRequest { get; set; }

        public AdicionarMusicaPlaylistCommand(MusicaPlaylistRequestDto musicaPlaylistRequest)
        {
            MusicaPlaylistRequest = musicaPlaylistRequest;
        }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarMusicaPlaylistValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AdicionarMusicaPlaylistValidator : AbstractValidator<AdicionarMusicaPlaylistCommand>
    {
        public AdicionarMusicaPlaylistValidator()
        {
            RuleFor(x => x.MusicaPlaylistRequest.PlaylistId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id da playlist inválido.");

            RuleFor(x => x.MusicaPlaylistRequest.MusicaId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id da música inválido.");
        }

    }
}
