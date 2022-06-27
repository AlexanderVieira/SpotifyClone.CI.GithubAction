using AVS.Banda.Domain.Entities;
using AVS.Banda.Domain.Interfaces.Repositories;
using AVS.Infra.CrossCutting;
using AVS.Infra.Data;

namespace AVS.Banda.Data.Repositories
{
    public class MusicaPlaylistRepository : GenericRepository<MusicaPlaylist>, IMusicaPlaylistRepository
    {
        private readonly SpotifyCloneContext _context;
        public MusicaPlaylistRepository(SpotifyCloneContext context) : base(context)
        {
            _context = context;
        }

    }
}
