using AVS.Banda.Application.DTOs;
using AVS.Core.Mensagens;
using MediatR;

namespace AVS.Banda.Application.Queries.Playlists
{
    public class ObterDetalhePlaylistQuery : Query, IRequest<ObterDetalhePlaylistQueryResponse>
    {
        public Guid Id { get; set; }
    }

    public class ObterDetalhePlaylistQueryResponse
    {
        public PlaylistResponseDto Playlist { get; set; }

        public ObterDetalhePlaylistQueryResponse(PlaylistResponseDto playlist)
        {
            Playlist = playlist;
        }
    }
}
