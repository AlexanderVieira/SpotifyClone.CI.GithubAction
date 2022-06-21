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

        //private readonly IUsuarioRepository _usuarioRepository;

        //public UsuarioService(IUsuarioRepository usuarioRepository)
        //{
        //    _usuarioRepository = usuarioRepository;
        //}

        //public async Task<IEnumerable<Usuario>> ObterTodos()
        //{
        //    return await _usuarioRepository.ObterTodos();
        //}

        //public async Task<IEnumerable<Usuario>> ObterTodosAtivos()
        //{
        //    return await _usuarioRepository.ObterTodosAtivos();
        //}

        //public async Task<Usuario> ObterPorId(Guid id)
        //{
        //    return await _usuarioRepository.ObterPorId(id);
        //}

        //public void Adicionar(Usuario usuario)
        //{
        //    //if (!usuario.EhValido()) return;
        //    usuario.Validar();
        //    _usuarioRepository.Salvar(usuario);            
        //}        

        //public void Atualizar(Usuario usuario)
        //{
        //    //if(!usuario.EhValido()) return;
        //    usuario.Validar();
        //    _usuarioRepository.Atualizar(usuario);
        //}

        //public void Ativar(Usuario usuario)
        //{
        //    //if (!usuario.EhValido()) return;
        //    usuario.Validar();
        //    usuario.Ativar();
        //    _usuarioRepository.Atualizar(usuario);
        //}

        //public void Inativar(Usuario usuario)
        //{
        //    //if (!usuario.EhValido()) return;
        //    usuario.Validar();
        //    usuario.Inativar();
        //    _usuarioRepository.Atualizar(usuario);
        //}

        //public void Remover(Usuario usuario)
        //{
        //    //if (!usuario.EhValido()) return;
        //    usuario.Validar();
        //    _usuarioRepository.Exluir(usuario);
        //}

        //public void AdicionarPlaylist(Usuario usuario)
        //{
        //    _usuarioRepository.Atualizar(usuario);
        //}
        
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
