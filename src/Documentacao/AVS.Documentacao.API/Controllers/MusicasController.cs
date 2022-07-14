using AVS.Banda.Application.Commands.Musicas;
using AVS.Banda.Application.DTOs;
using AVS.Banda.Application.Interfaces;
using AVS.Banda.Application.Queries.Musicas;
using AVS.Core.Comunicacao.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace AVS.Documentacao.API.Controllers
{
    [Route("api")]    
    public class MusicasController : PrincipalController
    {        
        private readonly IMediatorHandler _mediatorHandler;

        public MusicasController(IMediatorHandler mediatorHandler)
        {            
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("musicas")]
        public async Task<IActionResult> ObterTodasMusicas()
        {
            try
            {
                var response = (ObterTodasMusicasQueryResponse)await _mediatorHandler
                                                                        .EnviarQuery(new ObterTodasMusicasQuery());
                return response.Musicas == null || (!response.Musicas.Any()) ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Não existem dados para exibição.") : RespostaPersonalizada(response.Musicas.ToArray());
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpGet("musicas/{filtro}")]
        public async Task<IActionResult> ObterMusicasPorNome(string filtro)
        {
            try
            {   
                var response = (ObterTodasMusicasPorNomeQueryResponse)await _mediatorHandler
                                                                        .EnviarQuery(new ObterTodasMusicasPorNomeQuery { Filtro = filtro });
                return response.Musicas == null || (!response.Musicas.Any()) ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Não existem dados para exibição.") : RespostaPersonalizada(response.Musicas.ToArray());
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpGet("musica/detalhe/{id}")]
        public async Task<IActionResult> ObterMusicaComAlbum(Guid id)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {                
                var response = (ObterDetalheMusicaQueryResponse)await _mediatorHandler
                                                                        .EnviarQuery(new ObterDetalheMusicaQuery { Id = id });
                return response.Musica == null ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Música não encontrada.") : RespostaPersonalizada(response.Musica);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpGet("musica/{id}")]
        public async Task<IActionResult> ObterMusicaPorId(Guid id)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {                
                var response = (ObterMusicaPorIdQueryResponse)await _mediatorHandler
                                                                        .EnviarQuery(new ObterMusicaPorIdQuery { Id = id });
                return response.Musica == null ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Música não encontrada.") : RespostaPersonalizada(response.Musica);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpPost("musica/adicionar")]
        public async Task<IActionResult> AdicionarMusica([FromBody] MusicaRequestDto request)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (request == null) return RespostaPersonalizada();
                var comando = new AdicionarMusicaCommand(request);
                ValidationResult = await _mediatorHandler.EnviarComando(comando);
                if (!ValidationResult.IsValid) return RespostaPersonalizada(ValidationResult);
                AdicionaMensagemSucesso("Música adicionada com sucesso.");
                return RespostaPersonalizada(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }
        }

        [HttpPut("musica/atualizar")]
        public async Task<IActionResult> AtualizarMusica([FromBody] MusicaRequestDto request)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (request == null) return RespostaPersonalizada();
                var comando = new AtualizarMusicaCommand(request);
                ValidationResult = await _mediatorHandler.EnviarComando(comando);
                if (!ValidationResult.IsValid) return RespostaPersonalizada(ValidationResult);
                AdicionaMensagemSucesso("Música atualizada com sucesso.");
                return RespostaPersonalizada(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }        

        [HttpDelete("musica/excluir")]
        public async Task<IActionResult> ExcluirMusica([FromBody] MusicaRequestDto request)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (request == null) return RespostaPersonalizada();
                var comando = new ExcluirMusicaCommand(request);
                ValidationResult = await _mediatorHandler.EnviarComando(comando);
                if (!ValidationResult.IsValid) return RespostaPersonalizada(ValidationResult);
                AdicionaMensagemSucesso("Música excluída com sucesso.");
                return RespostaPersonalizada(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }        
    }
}
