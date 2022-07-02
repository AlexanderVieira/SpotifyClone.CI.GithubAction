using AVS.Banda.Domain.AppServices.DTOs;
using AVS.Banda.Domain.ConsultasProjetadas;
using AVS.Banda.Domain.Entities;
using AVS.Core.Data;
using System.Linq.Expressions;

namespace AVS.Banda.Domain.Interfaces.Repositories
{
    public interface IMusicaRepository : IRepository<Musica>
    {
        Task<IEnumerable<MusicaAlbumQueryAnonima>> BuscarTodosPorCriterio(Expression<Func<Musica, bool>> expression);
    }
}
