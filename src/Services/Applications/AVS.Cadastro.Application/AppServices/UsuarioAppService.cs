using AVS.Cadastro.Application.DTOs;
using AVS.Cadastro.Application.Interfaces;
using AVS.Cadastro.Domain.Interfaces.Services;
using AVS.Core.ObjDoinio;
using System.Linq.Expressions;

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
                var usuarioDTO = UsuarioDTO.ConverterParaUsuarioDTO(usuario);
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
                var usuarioDTO = UsuarioDTO.ConverterParaUsuarioDTO(item);
                usuarioDTOs = usuarioDTOs.Append(usuarioDTO);
            }
            return usuarioDTOs;
        }

        public async Task<UsuarioDTO> ObterPorId(object id)
        {
            var usuario = await _usuarioService.ObterPorId(id);
            Validacao.ValidarSeNulo(usuario, "Usuario não encontrado.");
            var usuarioDTO = UsuarioDTO.ConverterParaUsuarioDTO(usuario);
            return usuarioDTO;
        }

        public async Task Salvar(UsuarioDTO usuarioDTO)
        {                       
            var usuario = UsuarioDTO.ConverterParaUsuario(usuarioDTO);
            usuario.Validar();
            await _usuarioService.Salvar(usuario);
        }

        public async Task Atualizar(UsuarioDTO usuarioDTO)
        {            
            var usuario = UsuarioDTO.ConverterParaUsuario(usuarioDTO);
            usuario.Validar();
            await _usuarioService.Atualizar(usuario);
        }

        public async Task Ativar(UsuarioDTO usuarioDTO)
        {            
            var usuario = UsuarioDTO.ConverterParaUsuario(usuarioDTO);
            usuario.Validar();
            await _usuarioService.Ativar(usuario);
        }        

        public async Task Inativar(UsuarioDTO usuarioDTO)
        {            
            var usuario = UsuarioDTO.ConverterParaUsuario(usuarioDTO);
            usuario.Validar();
            await _usuarioService.Inativar(usuario);
        }
        
        public async Task Exluir(UsuarioDTO usuarioDTO)
        {            
            Validacao.ValidarSeNulo(usuarioDTO, "Opa! Ocorreu um erro.");
            var usuario = UsuarioDTO.ConverterParaUsuario(usuarioDTO);
            usuario.Validar();
            await _usuarioService.Exluir(usuario);
        }        

        public Task<IEnumerable<UsuarioDTO>> BuscarTodosPorCriterio(Expression<Func<UsuarioDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<UsuarioDTO> BuscarPorCriterio(Expression<Func<UsuarioDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
