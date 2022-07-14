using AVS.Banda.Application.DTOs;
using AVS.Core.Mensagens;
using MediatR;

namespace AVS.Banda.Application.Queries.Albuns
{
    public class ObterTodosAlbunsQuery : Query, IRequest<ObterTodosAlbunsQueryResponse>
    {
    }

    public class ObterTodosAlbunsQueryResponse
    {
        public IEnumerable<AlbumResponseDto> Albuns { get; set; }

        public ObterTodosAlbunsQueryResponse(IEnumerable<AlbumResponseDto> albuns)
        {
            Albuns = albuns;
        }
    }
}
