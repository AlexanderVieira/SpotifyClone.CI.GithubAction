using AVS.Banda.Domain.ConsultasProjetadas;
using AVS.Banda.Domain.Entities;
using AVS.Core.Services;
using System.Linq.Expressions;

namespace AVS.Banda.Domain.Interfaces.Services
{
    public interface IMusicaService : IAppService<Musica>
    {
        Task<IEnumerable<MusicaQueryAnonima>> BuscarTodosPorCriterio(Expression<Func<Musica, bool>> expression);
        Task<MusicaQueryAnonima> BuscarPorCriterio(Expression<Func<Musica, bool>> expression);
    }
}
