using AVS.Core.Services;
using System.Linq.Expressions;

namespace AVS.Banda.Domain.Interfaces.Services
{
    public interface IBandaService : IAppService<Entities.Banda>
    {
        Task<Entities.Banda> BuscarPorCriterio(Expression<Func<Entities.Banda, bool>> expression);
    }
}
