using AVS.Banda.Application.DTOs;
using AVS.Core.Mensagens;
using MediatR;

namespace AVS.Banda.Application.Queries.Albuns
{
    public class ObterDetalheAlbumQuery : Query, IRequest<ObterDetalheAlbumQueryResponse>
    {
        public Guid Id { get; set; }
    }

    public class ObterDetalheAlbumQueryResponse
    {
        public AlbumResponseDto Album { get; set; }

        public ObterDetalheAlbumQueryResponse(AlbumResponseDto album)
        {
            Album = album;
        }
    }
}
