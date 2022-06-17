using AVS.Cadastro.Application.DTOs;
using AVS.Cadastro.Application.Interfaces;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AVS.Documentacao.API.Controllers
{
    //[Route("api/[controller]")]    
    public class UsuariosController : PrincipalController
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuariosController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpGet("usuarios")]
        public async Task<IActionResult> ObterTodosUsuarios()
        {
            var usuarios = await _usuarioAppService.ObterTodos();
            return usuarios == null ? NotFound() : RespostaPersonalizada(usuarios.ToArray());
        }

        [HttpGet("usuarios/ativos")]
        public async Task<IActionResult> ObterTodosUsuariosAtivos()
        {
            var usuarios = await _usuarioAppService.ObterTodosAtivos();
            return usuarios == null ? NotFound() : RespostaPersonalizada(usuarios.ToArray());
        }

        [HttpGet("usuario/{id}")]
        public async Task<IActionResult> ObterUsuarioPorId(Guid id)
        {
            var usuario = await _usuarioAppService.ObterPorId(id);
            return usuario == null ? NotFound() : RespostaPersonalizada(usuario);
        }

        [HttpPost("usuario")]
        public IActionResult AdicionarUsuario(UsuarioDTO usuarioDTO)
        {
            if (usuarioDTO == null) return RespostaPersonalizada();            
            var validationResult = ValidarUsuario(usuarioDTO);
            if (!validationResult.IsValid) return RespostaPersonalizada(validationResult);
            _usuarioAppService.Adicionar(usuarioDTO);
            return RespostaPersonalizada();
        }
        private ValidationResult ValidarUsuario(UsuarioDTO usuarioDTO)
        {
            if (!usuarioDTO.EhValido()) return usuarioDTO.ValidationResult;            
            return usuarioDTO.ValidationResult;
        }

    }
}
