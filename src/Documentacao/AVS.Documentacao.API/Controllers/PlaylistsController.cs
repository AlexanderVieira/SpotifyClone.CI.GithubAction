using AVS.Banda.Application.Commands.Playlists;
using AVS.Banda.Application.DTOs;
using AVS.Banda.Application.Queries.Playlists;
using AVS.Core.Comunicacao.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace AVS.Documentacao.API.Controllers
{
    [Route("api")]    
    public class PlaylistsController : PrincipalController
    {        
        private readonly IMediatorHandler _mediatorHandler;

        public PlaylistsController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("playlists")]
        public async Task<IActionResult> ObterTodasPlaylists()
        {
            try
            {                
                var response = (ObterTodasPlaylistsQueryResponse)await _mediatorHandler
                                                                        .EnviarQuery(new ObterTodasPlaylistsQuery());
                return response.Playlists == null || (!response.Playlists.Any()) ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Não existem dados para exibição.") : RespostaPersonalizada(response.Playlists.ToArray());
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpGet("playlists/usuario/{filtro}")]
        public async Task<IActionResult> ObterPlaylistsPorNome(string filtro)
        {
            try
            {
                var response = (ObterTodasPlaylistsPorNomeQueryResponse)await _mediatorHandler
                              .EnviarQuery(new ObterTodasPlaylistsPorNomeQuery { Filtro = filtro, UsuarioId = UsuarioId });
                return response.Playlists == null || (!response.Playlists.Any()) ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Não existem dados para exibição.") : RespostaPersonalizada(response.Playlists.ToArray());
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpGet("playlist/minhas-musicas")]
        public async Task<IActionResult> ObterPlaylistComMusicas()
        {
            try
            {                
                var response = (ObterPlaylistComMusicasQueryResponse)await _mediatorHandler
                                                                        .EnviarQuery(new ObterPlaylistComMusicasQuery { UsuarioId = UsuarioId });
                return response.Playlist == null ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Não existem dados para exibição.") : RespostaPersonalizada(response.Playlist);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpGet("playlist/detalhe/{id}")]
        public async Task<IActionResult> ObterDetalhePlaylist(Guid id)
        {
            try
            {                
                var response = (ObterDetalhePlaylistQueryResponse)await _mediatorHandler
                                                                        .EnviarQuery(new ObterDetalhePlaylistQuery { Id = id });
                return response.Playlist == null ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Playlist não encontrada.") : RespostaPersonalizada(response.Playlist);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }       

        [HttpPost("playlist/adicionar")]
        public async Task<IActionResult> AdicionarPlaylist()
        {            
            try
            {
                var comando = new AdicionarPlaylistCommand(
                    new PlaylistRequestDto 
                    { 
                        Id = Guid.NewGuid(), 
                        UsuarioId = UsuarioId, 
                        Titulo = "Preencha o título", 
                        Descricao = "Preencha sua descrição", 
                        Foto = null 
                    });
                ValidationResult = await _mediatorHandler.EnviarComando(comando);
                if (!ValidationResult.IsValid) return RespostaPersonalizada(ValidationResult);
                AdicionaMensagemSucesso("Playlist adicionada com sucesso.");
                return RespostaPersonalizada(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }
        }        

        [HttpPut("playlist/atualizar")]
        public async Task<IActionResult> AtualizarPlaylist([FromBody] PlaylistRequestDto request)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada(ModelState);
            try
            {
                if (request == null) return RespostaPersonalizada();
                var comando = new AtualizarPlaylistCommand(request);
                ValidationResult = await _mediatorHandler.EnviarComando(comando);                
                if (!ValidationResult.IsValid) return RespostaPersonalizada(ValidationResult);
                AdicionaMensagemSucesso("Playlist atualizada com sucesso.");
                return RespostaPersonalizada(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }        

        [HttpDelete("playlist/excluir")]
        public async Task<IActionResult> ExcluirPlaylist([FromBody] PlaylistRequestDto request)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada(ModelState);
            try
            {
                if (request == null) return RespostaPersonalizada();                
                var comando = new ExcluirPlaylistCommand(request);
                ValidationResult = await _mediatorHandler.EnviarComando(comando);
                if (!ValidationResult.IsValid) return RespostaPersonalizada(ValidationResult);
                AdicionaMensagemSucesso("Playlist excluída com sucesso.");
                return RespostaPersonalizada(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpPost("playlist/adicionar/musica/{playlistId}/{musicaId}")]
        public async Task<IActionResult> AdicionarMusicaPlaylist(Guid playlistId, Guid musicaId)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada(ModelState);
            try
            {
                var request = new MusicaPlaylistRequestDto(playlistId, musicaId);                
                var comando = new AdicionarMusicaPlaylistCommand(request);
                ValidationResult = await _mediatorHandler.EnviarComando(comando);
                if (!ValidationResult.IsValid) return RespostaPersonalizada(ValidationResult);
                AdicionaMensagemSucesso("Música adicionada a playlist com sucesso.");
                return RespostaPersonalizada(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }
            
        }

        [HttpPost("playlist/excluir/musica/{playlistId}/{musicaId}")]
        public async Task<IActionResult> ExcluirMusicaPlaylist(Guid playlistId, Guid musicaId)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada(ModelState);
            try
            {
                var request = new MusicaPlaylistRequestDto(playlistId, musicaId);                
                var comando = new ExcluirMusicaPlaylistCommand(request);
                ValidationResult = await _mediatorHandler.EnviarComando(comando);
                if (!ValidationResult.IsValid) return RespostaPersonalizada(ValidationResult);
                AdicionaMensagemSucesso("Música excluída da playlist com sucesso.");
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
