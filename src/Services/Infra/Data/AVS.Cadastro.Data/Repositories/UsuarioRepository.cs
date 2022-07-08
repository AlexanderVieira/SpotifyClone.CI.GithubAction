using AVS.Cadastro.Domain.Entities;
using AVS.Cadastro.Domain.Interfaces.Repositories;
using AVS.Infra.CrossCutting;
using AVS.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace AVS.Cadastro.Data.Repositories
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SpotifyCloneContext context) : base(context)
        {            
        }               

        public async Task<IEnumerable<Usuario>> ObterTodosAtivos()
        {
            return await Query                            
                            .Include(u => u.Playlists)
                            //.ThenInclude(m => m.Musicas)
                            .Where(u => u.Ativo == true)
                            .ToListAsync();
        }
    }
}
