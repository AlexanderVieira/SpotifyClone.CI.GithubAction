using AVS.Cadastro.Application.Commands;
using AVS.Cadastro.Application.DTOs;
using AVS.Cadastro.Application.Interfaces;
using AVS.Cadastro.Application.Queries;
using AVS.Core.Comunicacao.Mediator;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AVS.Documentacao.API.Controllers
{
    [Route("api")]    
    public class UsuariosController : PrincipalController
    {
        private readonly IUsuarioAppService _usuarioAppService;
        private readonly IMediatorHandler _mediatorHandler;

        public UsuariosController(IUsuarioAppService usuarioAppService, IMediatorHandler mediatorHandler)
        {
            _usuarioAppService = usuarioAppService;
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("usuarios")]
        public async Task<IActionResult> ObterTodosUsuarios()
        {
            try
            {                
                var response = (ObterTodosUsuariosQueryResponse) await _mediatorHandler.EnviarQuery(new ObterTodosUsuariosQuery());                
                return response.Usuarios == null || (!response.Usuarios.Any()) ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Não existem dados para exibição.") : RespostaPersonalizada(response.Usuarios.ToArray());
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
        public async Task<IActionResult> AdicionarUsuario([FromBody] UsuarioRequestDto request)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (request == null) return RespostaPersonalizada();                
                var comando = new AdicionarUsuarioCommand(request);
                ValidationResult = await _mediatorHandler.EnviarComando(comando);
                if (!ValidationResult.IsValid) return RespostaPersonalizada(ValidationResult);
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
        public async Task<IActionResult> AtualizarUsuario([FromBody] UsuarioRequestDto request)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (request == null) return RespostaPersonalizada();
                var comando = new AtualizarUsuarioCommand(request);
                ValidationResult = await _mediatorHandler.EnviarComando(comando);
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
        public async Task<IActionResult> ExcluirUsuario([FromBody] UsuarioRequestDto request)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (request == null) return RespostaPersonalizada();
                var comando = new ExcluirUsuarioCommand(request);
                ValidationResult = await _mediatorHandler.EnviarComando(comando);
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
        public async Task<IActionResult> AtivarUsuario([FromBody] UsuarioRequestDto request)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (request == null) return RespostaPersonalizada();
                var comando = new AtivarUsuarioCommand(request);
                ValidationResult = await _mediatorHandler.EnviarComando(comando);
                AdicionaMensagemSucesso("Usuario ativado com sucesso.");
                return RespostaPersonalizada(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpPut("usuario/inativar")]
        public async Task<IActionResult> InativarUsuario([FromBody] UsuarioRequestDto request)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (request == null) return RespostaPersonalizada();
                var comando = new InativarUsuarioCommand(request);
                ValidationResult = await _mediatorHandler.EnviarComando(comando);
                AdicionaMensagemSucesso("Usuario inativado com sucesso.");
                return RespostaPersonalizada(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }
    }
}
