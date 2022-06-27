using AVS.Banda.Domain.ConsultasProjetadas;
using AVS.Banda.Domain.Entities;
using AVS.Core.Services;
using System.Linq.Expressions;

namespace AVS.Banda.Domain.Interfaces.Services
{
    public interface IPlaylistService : IAppService<Playlist>
    {
        Task<PlaylistMusicasQueryAnomima> BuscarMusicasPlaylist(Expression<Func<Playlist, bool>> expression);        
    }
}
