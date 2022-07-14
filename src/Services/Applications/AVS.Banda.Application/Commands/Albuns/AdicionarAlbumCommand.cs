using AVS.Banda.Application.DTOs;
using AVS.Core.Mensagens;
using FluentValidation;

namespace AVS.Banda.Application.Commands.Albuns
{
    public class AdicionarAlbumCommand : Comando
    {
        public AlbumRequestDto AlbumRequest { get; set; }

        public AdicionarAlbumCommand(AlbumRequestDto albumRequest)
        {
            AlbumRequest = albumRequest;
        }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarAlbumValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AdicionarAlbumValidator : AbstractValidator<AdicionarAlbumCommand>
    {
        public AdicionarAlbumValidator()
        {
            RuleFor(x => x.AlbumRequest.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id da album inválido.");

            RuleFor(x => x.AlbumRequest.BandaId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id da banda inválido.");

            RuleFor(x => x.AlbumRequest.Titulo)
                .NotEmpty()
                .WithMessage("Título é obrigatório.")
                .Length(2, 150)
                .WithMessage("O Título deve ter entre 2 a 150 caracteres.");

            RuleFor(x => x.AlbumRequest.Descricao)
                .NotEmpty()
                .WithMessage("Descrição é obrigatório.")
                .Length(2, 250)
                .WithMessage("A Descrição deve ter entre 2 a 250 caracteres.");

        }

    }
}
