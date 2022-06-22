using AVS.Banda.Domain.Entities;
using AVS.Banda.Domain.Interfaces.Repositories;
using AVS.Banda.Domain.Interfaces.Services;
using AVS.Core.Services;

namespace AVS.Banda.Domain.Services
{
    public class PlaylistService : GenericService<Playlist>, IPlaylistService
    {
        public PlaylistService(IPlaylistRepository playlistRepository) : base(playlistRepository)
        {            
        }
       
    }
}
