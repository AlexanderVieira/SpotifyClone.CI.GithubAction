using AVS.Banda.Domain.AppServices.DTOs;
using AVS.Core.Services;
using System.Linq.Expressions;

namespace AVS.Banda.Domain.Interfaces.AppServices
{
    public interface IBandaAppService : IAppService<BandaDTO>
    {
        Task<IEnumerable<BandaDTO>> BuscarTodosPorCriterio(Expression<Func<Entities.Banda, bool>> expression);
        Task<BandaDTO> BuscarPorCriterio(Expression<Func<Entities.Banda, bool>> expression);
    }
}
