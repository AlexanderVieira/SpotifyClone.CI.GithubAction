using AVS.Banda.Domain.ConsultasProjetadas;
using AVS.Banda.Domain.Entities;
using AVS.Banda.Domain.Interfaces.Repositories;
using AVS.Banda.Domain.Interfaces.Services;
using AVS.Core.Services;
using System.Linq.Expressions;

namespace AVS.Banda.Domain.Services
{
    public class PlaylistService : GenericService<Playlist>, IPlaylistService
    {
        private readonly IPlaylistRepository _playlistRepository;
        public PlaylistService(IPlaylistRepository playlistRepository) : base(playlistRepository)
        {  
            _playlistRepository = playlistRepository;
        }

        public async Task<PlaylistMusicasQueryAnomima> BuscarPlaylistComMusicas(Expression<Func<Playlist, bool>> expression)
        {
            return await _playlistRepository.BuscarPlaylistComMusicas(expression);
        }        

        public async Task<IEnumerable<PlaylistMusicasQueryAnomima>> BuscarPlaylistsPorCriterio(Expression<Func<Playlist, bool>> expression)
        {
            return await _playlistRepository.BuscarPlaylistsPorCriterio(expression);
        }
    }
}
