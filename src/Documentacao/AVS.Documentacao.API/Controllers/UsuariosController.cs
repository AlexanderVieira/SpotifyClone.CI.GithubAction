using AVS.Cadastro.Application.DTOs;
using AVS.Cadastro.Application.Interfaces;
using AVS.Core.ObjDoinio;
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
            try
            {
                var usuarios = await _usuarioAppService.ObterTodos();
                return usuarios == null ? NotFound() : RespostaPersonalizada(usuarios.ToArray());
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }
            
        }

        [HttpGet("usuarios/ativos")]
        public async Task<IActionResult> ObterTodosUsuariosAtivos()
        {
            try
            {
                var usuarios = await _usuarioAppService.ObterTodosAtivos();
                return usuarios == null ? NotFound() : RespostaPersonalizada(usuarios.ToArray());
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }
            
        }

        [HttpGet("usuario/{id}")]
        public async Task<IActionResult> ObterUsuarioPorId(Guid id)
        {
            try
            {
                var usuario = await _usuarioAppService.ObterPorId(id);
                return usuario == null ? NotFound() : RespostaPersonalizada(usuario);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }
            
        }

        [HttpPost("usuario/adicionar")]
        public IActionResult AdicionarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (usuarioDTO == null) return RespostaPersonalizada();                
                if (!ExecutarValidacao(new UsuarioDTOValidator(), usuarioDTO)) return RespostaPersonalizada(ValidationResult);
                _usuarioAppService.Adicionar(usuarioDTO);
                return RespostaPersonalizada();
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }
            
        }

        [HttpPut("usuario/atualizar")]
        public IActionResult AtualizarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (usuarioDTO == null) return RespostaPersonalizada();
                if (!ExecutarValidacao(new UsuarioDTOValidator(), usuarioDTO)) return RespostaPersonalizada(ValidationResult);
                _usuarioAppService.Atualizar(usuarioDTO);
                return RespostaPersonalizada();
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpDelete("usuario/remover")]
        public IActionResult RemoverUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (usuarioDTO == null) return RespostaPersonalizada();
                if (!ExecutarValidacao(new UsuarioDTOValidator(), usuarioDTO)) return RespostaPersonalizada(ValidationResult);
                _usuarioAppService.Remover(usuarioDTO);
                return RespostaPersonalizada();
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpPut("usuario/ativar")]
        public IActionResult AtivarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (usuarioDTO == null) return RespostaPersonalizada();
                if (!ExecutarValidacao(new UsuarioDTOValidator(), usuarioDTO)) return RespostaPersonalizada(ValidationResult);                
                _usuarioAppService.Ativar(usuarioDTO);
                return RespostaPersonalizada();
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpPut("usuario/inativar")]
        public IActionResult InativarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (usuarioDTO == null) return RespostaPersonalizada();
                if (!ExecutarValidacao(new UsuarioDTOValidator(), usuarioDTO)) return RespostaPersonalizada(ValidationResult);                
                _usuarioAppService.Inativar(usuarioDTO);
                return RespostaPersonalizada();
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        protected override bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade)
        {
            ValidationResult = validacao.Validate(entidade);
            if (ValidationResult.IsValid) return true;

            return false;
        }        

    }
}
