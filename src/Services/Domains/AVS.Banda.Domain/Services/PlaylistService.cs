using AVS.Banda.Domain.Interfaces.Repositories;
using AVS.Banda.Domain.Interfaces.Services;
using AVS.Core.Services;

namespace AVS.Banda.Domain.Services
{
    public class PlaylistService : GenericService<Playlist>, IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository;

        public PlaylistService(IPlaylistRepository playlistRepository) : base(playlistRepository)
        {
            _playlistRepository = playlistRepository;
        }
    }
}
