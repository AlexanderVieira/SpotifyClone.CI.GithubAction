using AVS.Banda.Domain.ConsultasProjetadas;
using AVS.Banda.Domain.Entities;
using AVS.Core.Data;
using System.Linq.Expressions;

namespace AVS.Banda.Domain.Interfaces.Repositories
{
    public interface IPlaylistRepository : IRepository<Playlist>
    {
        Task<PlaylistMusicasQueryAnomima> BuscarPlaylistComMusicas(Expression<Func<Playlist, bool>> expression);
        Task<IEnumerable<PlaylistMusicasQueryAnomima>> BuscarPlaylistsPorCriterio(Expression<Func<Playlist, bool>> expression);
    }
}
