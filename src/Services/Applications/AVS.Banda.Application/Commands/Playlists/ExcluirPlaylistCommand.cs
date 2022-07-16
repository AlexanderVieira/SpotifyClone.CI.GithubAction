using AVS.Banda.Application.DTOs;
using AVS.Core.Mensagens;
using FluentValidation;

namespace AVS.Banda.Application.Commands.Playlists
{
    public class ExcluirPlaylistCommand : Comando
    {
        public PlaylistRequestDto PlaylistRequest { get; set; }

        public ExcluirPlaylistCommand(PlaylistRequestDto playlistRequest)
        {
            PlaylistRequest = playlistRequest;
        }

        public override bool EhValido()
        {
            ValidationResult = new ExcluirPlaylistValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class ExcluirPlaylistValidator : AbstractValidator<ExcluirPlaylistCommand>
    {
        public ExcluirPlaylistValidator()
        {
            RuleFor(x => x.PlaylistRequest.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id da playlist inválido.");

            RuleFor(x => x.PlaylistRequest.UsuarioId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do usuário inválido.");

            RuleFor(x => x.PlaylistRequest.Titulo)
                .NotEmpty()
                .WithMessage("Titulo é obrigatório.")
                .Length(2, 150)
                .WithMessage("O Titulo deve ter entre 2 a 150 caracteres.");

            RuleFor(x => x.PlaylistRequest.Descricao)
                .NotEmpty()
                .WithMessage("Descrição é obrigatório.")
                .Length(2, 250)
                .WithMessage("O Titulo deve ter entre 2 a 250 caracteres.");
            
        }

    }
}
