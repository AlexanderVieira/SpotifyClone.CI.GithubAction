using AVS.Banda.Domain.AppServices.DTOs;
using AVS.Banda.Domain.Entities;
using AVS.Core.Services;
using System.Linq.Expressions;

namespace AVS.Banda.Domain.Interfaces.AppServices
{
    public interface IAlbumAppService : IAppService<AlbumDTO>
    {
        Task<IEnumerable<AlbumDTO>> BuscarTodosPorCriterio(Expression<Func<Album, bool>> expression);
        Task<AlbumDTO> BuscarPorCriterio(Expression<Func<Album, bool>> expression);
    }
}
