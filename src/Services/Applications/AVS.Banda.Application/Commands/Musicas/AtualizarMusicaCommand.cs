using AVS.Banda.Application.DTOs;
using AVS.Core.Mensagens;
using FluentValidation;

namespace AVS.Banda.Application.Commands.Musicas
{
    public class AtualizarMusicaCommand : Comando
    {
        public MusicaRequestDto MusicaRequest { get; set; }

        public AtualizarMusicaCommand(MusicaRequestDto musicaRequest)
        {
            MusicaRequest = musicaRequest;
        }

        public override bool EhValido()
        {
            ValidationResult = new AtualizarMusicaValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AtualizarMusicaValidator : AbstractValidator<AtualizarMusicaCommand>
    {
        public AtualizarMusicaValidator()
        {
            RuleFor(x => x.MusicaRequest.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id da música inválido.");

            RuleFor(x => x.MusicaRequest.AlbumId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do album inválido.");

            RuleFor(x => x.MusicaRequest.Nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório.")
                .Length(2, 150)
                .WithMessage("O Nome deve ter entre 2 a 150 caracteres.");

            RuleFor(x => x.MusicaRequest.Duracao)
                .NotEmpty()
                .WithMessage("Tempo de duração é obrigatório.");

        }

    }
}
