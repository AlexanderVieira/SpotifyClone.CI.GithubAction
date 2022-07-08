using AVS.Cadastro.Application.DTOs;
using AVS.Core.Mensagens;
using FluentValidation;

namespace AVS.Cadastro.Application.Commands
{
    public class AdicionarUsuarioCommand : Comando
    {
        public UsuarioRequestDto UsuarioRequest { get; set; }

        public AdicionarUsuarioCommand(UsuarioRequestDto usuarioRequest)
        {
            UsuarioRequest = usuarioRequest;
        }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarUsuarioValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AdicionarUsuarioValidator : AbstractValidator<AdicionarUsuarioCommand>
    {
        public AdicionarUsuarioValidator()
        {
            RuleFor(x => x.UsuarioRequest.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do usuário inválido.");

            RuleFor(x => x.UsuarioRequest.Nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório.")
                .Length(2, 150)
                .WithMessage("O Nome deve ter entre 2 a 150 caracteres.");

            RuleFor(x => x.UsuarioRequest.Cpf)
                .NotEmpty()
                .WithMessage("Documento é obrigatório.")
                .Must(Core.ObjValor.Cpf.ValidarCpf)
                .WithMessage("Documento Inválido.");

            RuleFor(x => x.UsuarioRequest.Email)
                .NotEmpty()
                .WithMessage("E-mail é obrigatório.")
                .Must(Core.ObjValor.Email.ValidarEmail)
                .WithMessage("E-mail inválido.");

        }

    }
}
