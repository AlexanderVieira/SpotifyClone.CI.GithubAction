using AVS.Banda.Domain.ConsultasProjetadas;
using AVS.Banda.Domain.Entities;
using AVS.Core.Services;
using System.Linq.Expressions;

namespace AVS.Banda.Domain.Interfaces.Services
{
    public interface IPlaylistService : IAppService<Playlist>
    {
        Task<PlaylistMusicasQueryAnomima> BuscarPlaylistComMusicas(Expression<Func<Playlist, bool>> expression);
        Task<IEnumerable<PlaylistMusicasQueryAnomima>> BuscarPlaylistsPorCriterio(Expression<Func<Playlist, bool>> expression);
    }
}
