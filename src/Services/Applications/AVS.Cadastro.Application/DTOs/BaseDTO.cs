using FluentValidation.Results;

namespace AVS.Cadastro.Application.DTOs
{
    public abstract class BaseDTO
    {
        public ValidationResult ValidationResult { get; set; }
        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
