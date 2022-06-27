using AVS.Cadastro.Application.DTOs;
using AVS.Cadastro.Application.Interfaces;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AVS.Documentacao.API.Controllers
{
    [Route("api")]    
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
                return usuarios == null || (!usuarios.Any()) ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Não existem dados para exibição.") : RespostaPersonalizada(usuarios.ToArray());
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
                return usuarios == null || (!usuarios.Any()) ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Não existem dados para exibição.") : RespostaPersonalizada(usuarios.ToArray());
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }
            
        }

        [HttpGet("usuario/detalhe/{id}")]
        public async Task<IActionResult> ObterUsuarioPorId(Guid id)
        {
            try
            {
                var usuario = await _usuarioAppService.ObterPorId(id);
                return usuario == null ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Usuario não encontrado.") : RespostaPersonalizada(usuario);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }
            
        }

        [HttpPost("usuario/adicionar")]
        public async Task<IActionResult> AdicionarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (usuarioDTO == null) return RespostaPersonalizada();                
                if (!ExecutarValidacao(new UsuarioDTOValidator(), usuarioDTO)) return RespostaPersonalizada(ValidationResult);
                await _usuarioAppService.Salvar(usuarioDTO);
                AdicionaMensagemSucesso("Usuario adicionado com sucesso.");
                return RespostaPersonalizada(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }
            
        }

        [HttpPut("usuario/atualizar")]
        public async Task<IActionResult> AtualizarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (usuarioDTO == null) return RespostaPersonalizada();
                if (!ExecutarValidacao(new UsuarioDTOValidator(), usuarioDTO)) return RespostaPersonalizada(ValidationResult);
                await _usuarioAppService.Atualizar(usuarioDTO);
                AdicionaMensagemSucesso("Usuario atualizado com sucesso.");
                return RespostaPersonalizada(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpDelete("usuario/excluir")]
        public async Task<IActionResult> ExcluirUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (usuarioDTO == null) return RespostaPersonalizada();
                if (!ExecutarValidacao(new UsuarioDTOValidator(), usuarioDTO)) return RespostaPersonalizada(ValidationResult);
                await _usuarioAppService.Exluir(usuarioDTO);
                AdicionaMensagemSucesso("Usuario excluído com sucesso.");
                return RespostaPersonalizada(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpPut("usuario/ativar")]
        public async Task<IActionResult> AtivarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (usuarioDTO == null) return RespostaPersonalizada();
                if (!ExecutarValidacao(new UsuarioDTOValidator(), usuarioDTO)) return RespostaPersonalizada(ValidationResult);                
                await _usuarioAppService.Ativar(usuarioDTO);
                return RespostaPersonalizada();
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpPut("usuario/inativar")]
        public async Task<IActionResult> InativarUsuario([FromBody] UsuarioDTO usuarioDTO)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (usuarioDTO == null) return RespostaPersonalizada();
                if (!ExecutarValidacao(new UsuarioDTOValidator(), usuarioDTO)) return RespostaPersonalizada(ValidationResult);                
                await _usuarioAppService.Inativar(usuarioDTO);
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
