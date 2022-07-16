using AVS.Banda.Application.DTOs;
using AVS.Core.Mensagens;
using MediatR;

namespace AVS.Banda.Application.Queries.Playlists
{
    public class ObterPlaylistComMusicasQuery : Query, IRequest<ObterPlaylistComMusicasQueryResponse>
    {
        public Guid UsuarioId { get; set; }
    }

    public class ObterPlaylistComMusicasQueryResponse
    {
        public PlaylistMusicasQueryAnonimaResponseDto Playlist { get; set; }

        public ObterPlaylistComMusicasQueryResponse(PlaylistMusicasQueryAnonimaResponseDto playlist)
        {
            Playlist = playlist;
        }
    }
}
