using AVS.Cadastro.Domain.Entities;
using AVS.Cadastro.Domain.Interfaces.Repositories;
using AVS.Cadastro.Domain.Interfaces.Services;
using AVS.Core.ObjDoinio;

namespace AVS.Cadastro.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> ObterTodos()
        {
            return await _usuarioRepository.ObterTodos();
        }

        public async Task<IEnumerable<Usuario>> ObterTodosAtivos()
        {
            return await _usuarioRepository.ObterTodosAtivos();
        }

        public async Task<Usuario> ObterPorId(Guid id)
        {
            return await _usuarioRepository.ObterPorId(id);
        }

        public void Adicionar(Usuario usuario)
        {
            //if (!usuario.EhValido()) return;
            _usuarioRepository.Adicionar(usuario);            
        }        

        public void Atualizar(Usuario usuario)
        {
            if(!usuario.EhValido()) return;
            _usuarioRepository.Atualizar(usuario);
        }

        public void Ativar(Usuario usuario)
        {
            if (!usuario.EhValido()) return;
            usuario.Ativar();
            _usuarioRepository.Atualizar(usuario);
        }

        public void Inativar(Usuario usuario)
        {
            if (!usuario.EhValido()) return;
            usuario.Inativar();
            _usuarioRepository.Atualizar(usuario);
        }

        public void Remover(Usuario usuario)
        {
            if (!usuario.EhValido()) return;            
            _usuarioRepository.Remover(usuario);
        }        
        
    }
}
