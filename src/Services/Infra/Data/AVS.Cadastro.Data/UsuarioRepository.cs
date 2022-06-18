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
            return await _context.Usuarios.AsNoTracking().ToListAsync();
        }
        public async Task<Usuario> ObterPorId(Guid id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Usuario>> ObterTodosAtivos()
        {
            return await _context.Usuarios.Where(u => u.Ativo == true).ToListAsync();
        }

        public void Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
        }
        public void Atualizar(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
        }               

        public void Remover(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
        
    }
}
