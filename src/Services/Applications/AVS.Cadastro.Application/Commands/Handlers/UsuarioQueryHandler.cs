using AVS.Cadastro.Application.Interfaces;
using AVS.Cadastro.Application.Queries;
using MediatR;

namespace AVS.Cadastro.Application.Commands.Handlers
{
    public class UsuarioQueryHandler : IRequestHandler<ObterTodosUsuariosQuery, ObterTodosUsuariosQueryResponse>
    {
        private readonly IUsuarioAppService _usuarioAppeService;

        public UsuarioQueryHandler(IUsuarioAppService usuarioAppeService)
        {
            _usuarioAppeService = usuarioAppeService;
        }

        public async Task<ObterTodosUsuariosQueryResponse> Handle(ObterTodosUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuariosResponse = await _usuarioAppeService.ObterTodos();
            return new ObterTodosUsuariosQueryResponse(usuariosResponse);
        }
    }
}
