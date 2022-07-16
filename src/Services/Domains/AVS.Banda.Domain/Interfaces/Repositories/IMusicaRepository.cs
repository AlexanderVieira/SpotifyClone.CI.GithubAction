using AVS.Banda.Domain.ConsultasProjetadas;
using AVS.Banda.Domain.Entities;
using AVS.Core.Data;
using System.Linq.Expressions;

namespace AVS.Banda.Domain.Interfaces.Repositories
{
    public interface IMusicaRepository : IRepository<Musica>
    {
        Task<IEnumerable<MusicaQueryAnonima>> BuscarTodosPorCriterio(Expression<Func<Musica, bool>> expression);
        Task<MusicaQueryAnonima> BuscarPorCriterio(Expression<Func<Musica, bool>> expression);
    }
}
