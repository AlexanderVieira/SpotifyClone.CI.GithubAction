using AVS.Banda.Domain.Entities;
using AVS.Core.Data;
using System.Linq.Expressions;

namespace AVS.Banda.Domain.Interfaces.Repositories
{
    public interface IAlbumRepository : IRepository<Album>
    {
        Task<Album> BuscarPorCriterio(Expression<Func<Album, bool>> expression);
    }
}
