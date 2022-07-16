using AVS.Banda.Application.Commands.Albuns;
using AVS.Banda.Application.DTOs;
using AVS.Banda.Application.Queries.Albuns;
using AVS.Core.Comunicacao.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace AVS.Documentacao.API.Controllers
{
    [Route("api")]    
    public class AlbunsController : PrincipalController
    {        
        private readonly IMediatorHandler _mediatorHandler;

        public AlbunsController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("albuns")]
        public async Task<IActionResult> ObterTodosAlbuns()
        {
            try
            {
                var response = (ObterTodosAlbunsQueryResponse)await _mediatorHandler
                                                                        .EnviarQuery(new ObterTodosAlbunsQuery());
                return response.Albuns == null || (!response.Albuns.Any()) ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Não existem dados para exibição.") : RespostaPersonalizada(response.Albuns.ToArray());
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpGet("albuns/{filtro}")]
        public async Task<IActionResult> ObterTodosAlbunsPorNome(string filtro)
        {
            try
            {                
                var response = (ObterTodosAlbunsQueryResponse)await _mediatorHandler
                                                                        .EnviarQuery(new ObterTodosAlbunsPorNomeQuery { Filtro = filtro});
                return response.Albuns == null || (!response.Albuns.Any()) ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Não existem dados para exibição.") : RespostaPersonalizada(response.Albuns.ToArray());
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpGet("album/detalhe/{id}")]
        public async Task<IActionResult> ObterAlbumComMusicas(Guid id)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {                
                var response = (ObterDetalheAlbumQueryResponse)await _mediatorHandler
                                                                        .EnviarQuery(new ObterDetalheAlbumQuery { Id = id});
                return response.Album == null ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Album não encontrado.") : RespostaPersonalizada(response.Album);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpGet("album/{id}")]
        public async Task<IActionResult> ObterAlbumPorId(Guid id)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {                
                var response = (ObterAlbumPorIdQueryResponse)await _mediatorHandler
                                                                        .EnviarQuery(new ObterAlbumPorIdQuery { Id = id });
                return response.Album == null ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Album não encontrado.") : RespostaPersonalizada(response.Album);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpPost("album/adicionar")]
        public async Task<IActionResult> AdicionarAlbum([FromBody] AlbumRequestDto request)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (request == null) return RespostaPersonalizada();
                var comando = new AdicionarAlbumCommand(request);
                ValidationResult = await _mediatorHandler.EnviarComando(comando);
                if (!ValidationResult.IsValid) return RespostaPersonalizada(ValidationResult);
                AdicionaMensagemSucesso("Album adicionado com sucesso.");
                return RespostaPersonalizada(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }
        }

        [HttpPut("album/atualizar")]
        public async Task<IActionResult> AtualizarAlbum([FromBody] AlbumRequestDto request)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (request == null) return RespostaPersonalizada();
                var comando = new AtualizarAlbumCommand(request);
                ValidationResult = await _mediatorHandler.EnviarComando(comando);
                if (!ValidationResult.IsValid) return RespostaPersonalizada(ValidationResult);
                AdicionaMensagemSucesso("Album atualizado com sucesso.");
                return RespostaPersonalizada(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }        

        [HttpDelete("album/excluir")]
        public async Task<IActionResult> ExcluirAlbum([FromBody] AlbumRequestDto request)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (request == null) return RespostaPersonalizada();
                var comando = new ExcluirAlbumCommand(request);
                ValidationResult = await _mediatorHandler.EnviarComando(comando);
                if (!ValidationResult.IsValid) return RespostaPersonalizada(ValidationResult);
                AdicionaMensagemSucesso("Album excluído com sucesso.");
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
