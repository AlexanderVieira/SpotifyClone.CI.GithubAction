using AVS.Banda.Application.DTOs;
using AVS.Core.Mensagens;
using MediatR;

namespace AVS.Banda.Application.Queries.Playlists
{
    public class ObterTodasPlaylistsQuery : Query, IRequest<ObterTodasPlaylistsQueryResponse>
    {
    }

    public class ObterTodasPlaylistsQueryResponse
    {
        public IEnumerable<PlaylistResponseDto> Playlists { get; set; }

        public ObterTodasPlaylistsQueryResponse(IEnumerable<PlaylistResponseDto> playlists)
        {
            Playlists = playlists;
        }
    }
}
