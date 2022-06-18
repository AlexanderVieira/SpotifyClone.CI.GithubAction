using AVS.Cadastro.Application.DTOs;
using AVS.Cadastro.Application.Interfaces;
using AVS.Cadastro.Domain.Interfaces.Services;

namespace AVS.Cadastro.Application.AppServices
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public void Adicionar(UsuarioDTO usuarioDTO)
        {
            if (!usuarioDTO.EhValido()) return;
            
            var usuario = UsuarioDTO.ConverteParaUsuario(usuarioDTO);
            _usuarioService.Adicionar(usuario);
        }

        public void Ativar(UsuarioDTO usuarioDTO)
        {
            if (!usuarioDTO.EhValido()) return ;

            var usuario = UsuarioDTO.ConverteParaUsuario(usuarioDTO);
            _usuarioService.Ativar(usuario);
        }

        public void Atualizar(UsuarioDTO usuarioDTO)
        {
            if (!usuarioDTO.EhValido()) return;

            var usuario = UsuarioDTO.ConverteParaUsuario(usuarioDTO);
            _usuarioService.Atualizar(usuario);
        }

        public void Inativar(UsuarioDTO usuarioDTO)
        {
            if (!usuarioDTO.EhValido()) return;

            var usuario = UsuarioDTO.ConverteParaUsuario(usuarioDTO);
            _usuarioService.Inativar(usuario);
        }

        public async Task<UsuarioDTO> ObterPorId(Guid id)
        {
            //Validacao.ValidarSeNuloVazio(id.ToString(), "Usuario não encontrado.");
            var usuario = await _usuarioService.ObterPorId(id);
            if(usuario == null) return null;
            var usuarioDTO = UsuarioDTO.ConverteParaUsuarioDTO(usuario);
            return usuarioDTO;
        }

        public async Task<IEnumerable<UsuarioDTO>> ObterTodos()
        {
            var usuarios = await _usuarioService.ObterTodos();
            //Validacao.ValidarSeExiste(usuarios.Cast<object>().ToList(), "Não existem dados para exibição.");
            IEnumerable<UsuarioDTO> usuarioDTOs = new List<UsuarioDTO>();
            foreach (var item in usuarios)
            {
                var usuarioDTO = UsuarioDTO.ConverteParaUsuarioDTO(item);
                _ = usuarioDTOs.Append(usuarioDTO);
            }
            return usuarioDTOs;
        }

        public async Task<IEnumerable<UsuarioDTO>> ObterTodosAtivos()
        {
            var usuarios = await _usuarioService.ObterTodosAtivos();
            //Validacao.ValidarSeExiste(usuarios.Cast<object>().ToList(), "Não existem dados para exibição.");
            IEnumerable<UsuarioDTO> usuarioDTOs = new List<UsuarioDTO>();
            foreach (var item in usuarios)
            {
                var usuarioDTO = UsuarioDTO.ConverteParaUsuarioDTO(item);
                _ = usuarioDTOs.Append(usuarioDTO);
            }
            return usuarioDTOs;
        }

        public void Remover(UsuarioDTO usuarioDTO)
        {
            if (!usuarioDTO.EhValido()) return;

            var usuario = UsuarioDTO.ConverteParaUsuario(usuarioDTO);
            _usuarioService.Remover(usuario);
        }
        
    }
}
