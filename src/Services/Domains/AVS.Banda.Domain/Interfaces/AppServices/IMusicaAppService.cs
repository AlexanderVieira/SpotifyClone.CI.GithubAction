using AVS.Banda.Domain.AppServices.DTOs;
using AVS.Banda.Domain.ConsultasProjetadas;
using AVS.Banda.Domain.Entities;
using AVS.Core.Services;
using System.Linq.Expressions;

namespace AVS.Banda.Domain.Interfaces.AppServices
{
    public interface IMusicaAppService : IAppService<MusicaDTO>
    {
        Task<IEnumerable<MusicaAlbumQueryAnonima>> BuscarTodosPorCriterio(Expression<Func<Musica, bool>> expression);
    }    
}
