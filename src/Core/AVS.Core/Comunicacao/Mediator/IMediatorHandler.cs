using AVS.Core.Mensagens;
using FluentValidation.Results;

namespace AVS.Core.Comunicacao.Mediator
{
    public interface IMediatorHandler
    {
        Task<ValidationResult> EnviarComando<T>(T comando) where T : Comando;
        Task<Object> EnviarQuery<T>(T query) where T : Query;
    }
}
