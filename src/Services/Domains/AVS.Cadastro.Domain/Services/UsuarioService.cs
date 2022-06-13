using AVS.Cadastro.Domain.Entities;
using AVS.Cadastro.Domain.Interfaces.Repositories;
using AVS.Cadastro.Domain.Interfaces.Services;

namespace AVS.Cadastro.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void Adicionar(Usuario usuario)
        {
            if (!usuario.EhValido()) return;
            _usuarioRepository.Adicionar(usuario);
        }
    }
}
