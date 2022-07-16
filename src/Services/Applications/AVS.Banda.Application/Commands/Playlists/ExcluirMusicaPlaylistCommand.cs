using AVS.Banda.Application.DTOs;
using AVS.Core.Mensagens;
using FluentValidation;

namespace AVS.Banda.Application.Commands.Playlists
{
    public class ExcluirMusicaPlaylistCommand : Comando
    {
        public MusicaPlaylistRequestDto MusicaPlaylistRequest { get; set; }

        public ExcluirMusicaPlaylistCommand(MusicaPlaylistRequestDto musicaPlaylistRequest)
        {
            MusicaPlaylistRequest = musicaPlaylistRequest;
        }

        public override bool EhValido()
        {
            ValidationResult = new ExcluirMusicaPlaylistValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class ExcluirMusicaPlaylistValidator : AbstractValidator<ExcluirMusicaPlaylistCommand>
    {
        public ExcluirMusicaPlaylistValidator()
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
