using AVS.Cadastro.Application.Interfaces;
using AVS.Cadastro.Application.Queries;
using MediatR;

namespace AVS.Cadastro.Application.Commands.Handlers
{
    public class UsuarioQueryHandler : IRequestHandler<ObterTodosUsuariosQuery, ObterTodosUsuariosQueryResponse>,
                                       IRequestHandler<ObterTodosUsuariosAtivosQuery, ObterTodosUsuariosQueryResponse>,
                                       IRequestHandler<ObterDetalheUsuarioQuery, ObterDetalheUsuarioQueryResponse>
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

        public async Task<ObterTodosUsuariosQueryResponse> Handle(ObterTodosUsuariosAtivosQuery request, CancellationToken cancellationToken)
        {
            var usuariosResponse = await _usuarioAppeService.ObterTodosAtivos();
            return new ObterTodosUsuariosQueryResponse(usuariosResponse);
        }

        public async Task<ObterDetalheUsuarioQueryResponse> Handle(ObterDetalheUsuarioQuery request, CancellationToken cancellationToken)
        {
            var usuarioResponse = await _usuarioAppeService.ObterPorId(request.Id);
            return new ObterDetalheUsuarioQueryResponse(usuarioResponse);
        }
    }
}
