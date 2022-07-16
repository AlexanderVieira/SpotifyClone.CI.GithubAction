using AVS.Core.Data;
using System.Linq.Expressions;

namespace AVS.Banda.Domain.Interfaces.Repositories
{
    public interface IBandaRepository : IRepository<Entities.Banda>
    {
        Task<Entities.Banda> BuscarPorCriterio(Expression<Func<Entities.Banda, bool>> expression);
    }
}
