using AVS.Banda.Domain.Entities;
using AVS.Banda.Domain.Interfaces.Repositories;
using AVS.Banda.Domain.Interfaces.Services;
using AVS.Core.Services;
using System.Linq.Expressions;

namespace AVS.Banda.Domain.Services
{
    public class AlbumService : GenericService<Album>, IAlbumService
    {
        private readonly IAlbumRepository _albumRepository;
        public AlbumService(IAlbumRepository albumRepository) : base(albumRepository)
        {
            _albumRepository = albumRepository;
        }

        public async Task<Album> BuscarPorCriterio(Expression<Func<Album, bool>> expression)
        {
            return await _albumRepository.BuscarPorCriterio(expression);
        }
       
    }
}
