using AVS.Banda.Domain.Entities;
using AVS.Core.Services;
using System.Linq.Expressions;

namespace AVS.Banda.Domain.Interfaces.Services
{
    public interface IAlbumService : IAppService<Album>
    {
        Task<IEnumerable<Album>> BuscarTodosPorCriterio(Expression<Func<Album, bool>> expression);
        Task<Album> BuscarPorCriterio(Expression<Func<Album, bool>> expression);
    }
}
