using AVS.Banda.Domain.AppServices.DTOs;
using AVS.Banda.Domain.Interfaces.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace AVS.Documentacao.API.Controllers
{
    [Route("api")]    
    public class PlaylistsController : PrincipalController
    {
        private readonly IPlaylistAppService _playlistAppService;

        public PlaylistsController(IPlaylistAppService playlistAppService)
        {
            _playlistAppService = playlistAppService;
        }
        
        [HttpGet("playlists")]
        public async Task<IActionResult> ObterTodasPlaylists()
        {
            try
            {
                var playlists = await _playlistAppService.ObterTodos();
                return playlists == null ? NotFound() : RespostaPersonalizada(playlists.ToArray());
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpGet("playlist/detalhe/{id}")]
        public async Task<IActionResult> ObterPlaylistPorId(Guid id)
        {
            try
            {
                var playlist = await _playlistAppService.ObterPorId(id);
                return playlist == null ? NotFound() : RespostaPersonalizada(playlist);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpPost("playlist/adicionar")]
        public async Task<IActionResult> AdicionarPlaylist(PlaylistDTO playlistDTO)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (playlistDTO == null) return RespostaPersonalizada();
                if (!ExecutarValidacao(new PlaylistDTOValidator(), playlistDTO)) return RespostaPersonalizada(ValidationResult);
                await _playlistAppService.Salvar(playlistDTO);
                return RespostaPersonalizada();
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }
        }

        [HttpPut("playlist/atualizar")]
        public async Task<IActionResult> AtualizarPlaylist([FromBody] PlaylistDTO playlistDTO)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (playlistDTO == null) return RespostaPersonalizada();
                if (!ExecutarValidacao(new PlaylistDTOValidator(), playlistDTO)) return RespostaPersonalizada(ValidationResult);
                await _playlistAppService.Atualizar(playlistDTO);
                return RespostaPersonalizada();
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }        

        [HttpDelete("playlist/excluir")]
        public async Task<IActionResult> ExcluirPlaylist([FromBody] PlaylistDTO playlistDTO)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (playlistDTO == null) return RespostaPersonalizada();
                if (!ExecutarValidacao(new PlaylistDTOValidator(), playlistDTO)) return RespostaPersonalizada(ValidationResult);
                await _playlistAppService.Exluir(playlistDTO);
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
