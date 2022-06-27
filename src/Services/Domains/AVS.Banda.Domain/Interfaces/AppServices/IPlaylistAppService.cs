using AVS.Banda.Domain.AppServices.DTOs;
using AVS.Banda.Domain.ConsultasProjetadas;
using AVS.Banda.Domain.Entities;
using AVS.Core.Services;
using System.Linq.Expressions;

namespace AVS.Banda.Domain.Interfaces.AppServices
{
    public interface IPlaylistAppService : IAppService<PlaylistDTO>
    {
        Task<IEnumerable<PlaylistDTO>> BuscarTodosPorCriterio(Expression<Func<Playlist, bool>> expression); 
        Task<PlaylistMusicasQueryAnomima> BuscarMusicasPlaylist(Expression<Func<Playlist, bool>> expression);       
        
    }
}
