using AVS.Banda.Domain.Entities;
using AVS.Banda.Domain.Interfaces.Repositories;
using AVS.Infra.CrossCutting;
using AVS.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AVS.Banda.Data.Repositories
{
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {
        private readonly SpotifyCloneContext _context;
        public AlbumRepository(SpotifyCloneContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Album> BuscarPorCriterio(Expression<Func<Album, bool>> expression)
        {
            return await _context.Albuns.Where(expression).Include(b => b.Musicas).FirstOrDefaultAsync();            
        }

    }
}
