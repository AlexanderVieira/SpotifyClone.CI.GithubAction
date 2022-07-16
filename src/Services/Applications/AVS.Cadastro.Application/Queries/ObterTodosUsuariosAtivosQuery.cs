using AVS.Core.Mensagens;
using MediatR;

namespace AVS.Cadastro.Application.Queries
{
    public class ObterTodosUsuariosAtivosQuery : Query, IRequest<ObterTodosUsuariosQueryResponse>
    {
    }   
}
