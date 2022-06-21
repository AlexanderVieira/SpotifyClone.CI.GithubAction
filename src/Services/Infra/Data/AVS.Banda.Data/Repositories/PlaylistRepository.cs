using AVS.Banda.Domain;
using AVS.Banda.Domain.Interfaces.Repositories;
using AVS.Infra.CrossCutting;
using AVS.Infra.Data;

namespace AVS.Banda.Data.Repositories
{
    public class PlaylistRepository : GenericRepository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(SpotifyCloneContext context) : base(context)
        {
        }
    }
}
