using AVS.Core.Mensagens;
using FluentValidation.Results;
using MediatR;

namespace AVS.Core.Comunicacao.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ValidationResult> EnviarComando<T>(T comando) where T : Comando
        {            
            return await _mediator.Send(comando);
        }

        public async Task<Object> EnviarQuery<T>(T query) where T : Query
        {
            return await _mediator.Send(query);
        }
    }
}
