using AVS.Cadastro.Application.DTOs;
using AVS.Core.Mensagens;
using MediatR;

namespace AVS.Cadastro.Application.Queries
{
    public class ObterDetalheUsuarioQuery : Query, IRequest<ObterDetalheUsuarioQueryResponse>
    {
        public Guid Id { get; set; }
    }

    public class ObterDetalheUsuarioQueryResponse
    {
        public UsuarioResponseDto Usuario { get; set; }

        public ObterDetalheUsuarioQueryResponse(UsuarioResponseDto usuario)
        {
            Usuario = usuario;
        }
    }
}
