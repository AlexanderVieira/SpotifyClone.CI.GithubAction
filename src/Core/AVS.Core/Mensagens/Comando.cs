using FluentValidation.Results;
using MediatR;

namespace AVS.Core.Mensagens
{
    public abstract class Comando : Mensagem, IRequest<ValidationResult>
    {
        public DateTime Timestamp { get; set; }
        public ValidationResult ValidationResult { get; set; }

        protected Comando()
        {
            Timestamp = DateTime.UtcNow;
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
