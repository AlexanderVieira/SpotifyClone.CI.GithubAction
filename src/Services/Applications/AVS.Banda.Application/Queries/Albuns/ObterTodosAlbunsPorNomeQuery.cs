using AVS.Core.Mensagens;
using MediatR;

namespace AVS.Banda.Application.Queries.Albuns
{
    public class ObterTodosAlbunsPorNomeQuery : Query, IRequest<ObterTodosAlbunsQueryResponse>
    {
        public string Filtro { get; set; }
    }
}
