using FluentValidation.Results;

namespace AVS.Core.Mensagens
{
    public class MensagemResposta : Mensagem
    {
        public ValidationResult ValidationResult { get; set; }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }

        public MensagemResposta()
        {
            ValidationResult = new ValidationResult();
        }
    }
}
