using AVS.Cadastro.Domain.Entities;
using AVS.Cadastro.Domain.Interfaces.Repositories;
using AVS.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace AVS.Cadastro.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public UsuarioRepository(UsuarioContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Usuario>> ObterTodos()
        {
            return await _context.Usuarios
                                 .Include(u => u.Playlists)
                                 .ThenInclude(m => m.Musicas)
                                 .ToListAsync();
        }
        
        public async Task<IEnumerable<Usuario>> ObterTodosAtivos()
        {
            return await _context.Usuarios
                .Where(u => u.Ativo == true)
                .Include(u => u.Playlists)
                .ThenInclude(m => m.Musicas)
                .ToListAsync();
        }

        public async Task<Usuario> ObterPorId(Guid id)
        {
            return await _context.Usuarios
                                 .Include(u => u.Playlists)
                                 .ThenInclude(m => m.Musicas)
                                 .FirstOrDefaultAsync(u => u.Id == id);
        }

        public void Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }
        public void Atualizar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }               

        public void Remover(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
        
    }
}
