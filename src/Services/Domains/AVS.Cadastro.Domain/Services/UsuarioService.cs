using AVS.Cadastro.Domain.Entities;
using AVS.Cadastro.Domain.Interfaces.Repositories;
using AVS.Cadastro.Domain.Interfaces.Services;
using AVS.Core.Services;

namespace AVS.Cadastro.Domain.Services
{
    public class UsuarioService : GenericService<Usuario>, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        
        public async Task Ativar(Usuario usuario)
        {
            usuario.Validar();
            await _repo.Atualizar(usuario);
        }

        public async Task Inativar(Usuario usuario)
        {
            usuario.Validar();
            await _repo.Atualizar(usuario);
        }

        public async Task<IEnumerable<Usuario>> ObterTodosAtivos()
        {
            return await _usuarioRepository.ObterTodosAtivos();
        }
    }
}
