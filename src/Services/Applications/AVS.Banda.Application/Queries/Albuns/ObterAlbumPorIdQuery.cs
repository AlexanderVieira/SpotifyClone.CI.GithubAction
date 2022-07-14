using AVS.Banda.Application.DTOs;
using AVS.Core.Mensagens;
using MediatR;

namespace AVS.Banda.Application.Queries.Albuns
{
    public class ObterAlbumPorIdQuery : Query, IRequest<ObterAlbumPorIdQueryResponse>
    {
        public Guid Id { get; set; }
    }

    public class ObterAlbumPorIdQueryResponse
    {
        public AlbumResponseDto Album { get; set; }

        public ObterAlbumPorIdQueryResponse(AlbumResponseDto album)
        {
            Album = album;
        }
    }
}
