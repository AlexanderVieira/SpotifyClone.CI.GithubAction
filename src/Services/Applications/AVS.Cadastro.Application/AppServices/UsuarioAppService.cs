using AVS.Cadastro.Application.DTOs;
using AVS.Cadastro.Application.Interfaces;
using AVS.Cadastro.Domain.Interfaces.Services;
using AVS.Core.ObjDoinio;

namespace AVS.Cadastro.Application.AppServices
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioAppService(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public async Task<IEnumerable<UsuarioDTO>> ObterTodos()
        {
            var usuarios = await _usuarioService.ObterTodos();
            Validacao.ValidarSeExiste(usuarios.Cast<object>().ToList(), "Não existem dados para exibição.");
            IEnumerable<UsuarioDTO> usuarioDTOs = new List<UsuarioDTO>();
            foreach (var usuario in usuarios)
            {
                var usuarioDTO = UsuarioDTO.ConverteParaUsuarioDTO(usuario);
                usuarioDTOs = usuarioDTOs.Append(usuarioDTO);
            }
            return usuarioDTOs;
        }

        public async Task<IEnumerable<UsuarioDTO>> ObterTodosAtivos()
        {
            var usuarios = await _usuarioService.ObterTodosAtivos();
            Validacao.ValidarSeExiste(usuarios.Cast<object>().ToList(), "Não existem dados para exibição.");
            IEnumerable<UsuarioDTO> usuarioDTOs = new List<UsuarioDTO>();
            foreach (var item in usuarios)
            {
                var usuarioDTO = UsuarioDTO.ConverteParaUsuarioDTO(item);
                usuarioDTOs = usuarioDTOs.Append(usuarioDTO);
            }
            return usuarioDTOs;
        }

        public async Task<UsuarioDTO> ObterPorId(Guid id)
        {
            var usuario = await _usuarioService.ObterPorId(id);
            Validacao.ValidarSeNulo(usuario, "Usuario não encontrado.");
            var usuarioDTO = UsuarioDTO.ConverteParaUsuarioDTO(usuario);
            return usuarioDTO;
        }

        public void Adicionar(UsuarioDTO usuarioDTO)
        {
            //if (!usuarioDTO.EhValido()) return;            
            var usuario = UsuarioDTO.ConverteParaUsuario(usuarioDTO);
            _usuarioService.Adicionar(usuario);
        }

        public void Atualizar(UsuarioDTO usuarioDTO)
        {
            //if (!usuarioDTO.EhValido()) return;
            var usuario = UsuarioDTO.ConverteParaUsuario(usuarioDTO);
            _usuarioService.Atualizar(usuario);
        }

        public void Ativar(UsuarioDTO usuarioDTO)
        {
            //if (!usuarioDTO.EhValido()) return ;
            var usuario = UsuarioDTO.ConverteParaUsuario(usuarioDTO);
            _usuarioService.Ativar(usuario);
        }        

        public void Inativar(UsuarioDTO usuarioDTO)
        {
            //if (!usuarioDTO.EhValido()) return;
            var usuario = UsuarioDTO.ConverteParaUsuario(usuarioDTO);
            _usuarioService.Inativar(usuario);
        }

        public void Remover(UsuarioDTO usuarioDTO)
        {
            //if (!usuarioDTO.EhValido()) return;
            Validacao.ValidarSeNulo(usuarioDTO, "Opa! Ocorreu um erro.");
            var usuario = UsuarioDTO.ConverteParaUsuario(usuarioDTO);
            _usuarioService.Remover(usuario);
        }
        
    }
}
