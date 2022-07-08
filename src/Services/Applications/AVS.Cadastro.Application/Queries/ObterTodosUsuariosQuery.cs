using AVS.Cadastro.Application.DTOs;
using AVS.Core.Mensagens;
using MediatR;

namespace AVS.Cadastro.Application.Queries
{
    public class ObterTodosUsuariosQuery : Query, IRequest<ObterTodosUsuariosQueryResponse>
    {
    }

    public class ObterTodosUsuariosQueryResponse
    {
        public IEnumerable<UsuarioResponseDto> Usuarios { get; set; }

        public ObterTodosUsuariosQueryResponse(IEnumerable<UsuarioResponseDto> usuarios)
        {
            Usuarios = usuarios;
        }
    }
}
