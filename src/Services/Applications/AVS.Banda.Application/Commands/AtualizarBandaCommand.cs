using AVS.Banda.Application.DTOs;
using AVS.Core.Mensagens;
using FluentValidation;

namespace AVS.Banda.Application.Commands
{
    public class AtualizarBandaCommand : Comando
    {
        public BandaRequestDto BandaRequest { get; set; }

        public AtualizarBandaCommand(BandaRequestDto bandaRequest)
        {
            BandaRequest = bandaRequest;
        }

        public override bool EhValido()
        {
            ValidationResult = new AtualizarBandaValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AtualizarBandaValidator : AbstractValidator<AtualizarBandaCommand>
    {
        public AtualizarBandaValidator()
        {
            RuleFor(x => x.BandaRequest.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id da banda inválido.");

            RuleFor(x => x.BandaRequest.Nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório.")
                .Length(2, 150)
                .WithMessage("O Nome deve ter entre 2 a 150 caracteres.");

            RuleFor(x => x.BandaRequest.Descricao)
                .NotEmpty()
                .WithMessage("Descrição é obrigatório.")
                .Length(2, 250)
                .WithMessage("A Descrição deve ter entre 2 a 250 caracteres.");

        }

    }
}
