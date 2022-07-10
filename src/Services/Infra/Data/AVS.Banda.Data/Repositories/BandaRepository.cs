using AVS.Banda.Domain.Interfaces.Repositories;
using AVS.Infra.CrossCutting;
using AVS.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AVS.Banda.Data.Repositories
{
    public class BandaRepository : GenericRepository<Domain.Entities.Banda>, IBandaRepository
    {
        private readonly SpotifyCloneContext _context;
        public BandaRepository(SpotifyCloneContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Banda> BuscarPorCriterio(Expression<Func<Domain.Entities.Banda, bool>> expression)
        {
            return await _context.Bandas
                .Include(b => b.Albuns.OrderBy(x => x.Titulo))
                .ThenInclude(a => a.Musicas.OrderBy(m => m.Nome))
                .ThenInclude(m => m.Playlists)
                .FirstOrDefaultAsync(expression);            
        }

    }
}
