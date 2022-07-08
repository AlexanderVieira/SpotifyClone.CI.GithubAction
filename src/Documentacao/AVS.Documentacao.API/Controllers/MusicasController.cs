using AVS.Banda.Application.DTOs;
using AVS.Banda.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AVS.Documentacao.API.Controllers
{
    [Route("api")]    
    public class MusicasController : PrincipalController
    {
        private readonly IMusicaAppService _musicaAppService;

        public MusicasController(IMusicaAppService musicaAppService)
        {
            _musicaAppService = musicaAppService;
        }
        
        [HttpGet("musicas")]
        public async Task<IActionResult> ObterTodasMusicas()
        {
            try
            {
                var musicas = await _musicaAppService.ObterTodos();
                return musicas == null || (!musicas.Any()) ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Não existem dados para exibição.") : RespostaPersonalizada(musicas.ToArray());
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
                var musicas = await _musicaAppService.BuscarTodosPorCriterio(b => b.Nome.ToLower().Contains(filtro.ToLower()));
                return musicas == null || (!musicas.Any()) ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Não existem dados para exibição.") : RespostaPersonalizada(musicas.ToArray());
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
                var musica = await _musicaAppService.BuscarPorCriterio(b => b.Id == id);
                return musica == null ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Música não encontrada.") : RespostaPersonalizada(musica);
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
                var musica = await _musicaAppService.ObterPorId(id);
                return musica == null ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Música não encontrada.") : RespostaPersonalizada(musica);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpPost("musica/adicionar")]
        public async Task<IActionResult> AdicionarMusica([FromBody] MusicaRequestDto musicaDTO)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (musicaDTO == null) return RespostaPersonalizada();
                //if (!ExecutarValidacao(new MusicaDTOValidator(), musicaDTO)) return RespostaPersonalizada(ValidationResult);
                await _musicaAppService.Salvar(musicaDTO);
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
        public async Task<IActionResult> AtualizarMusica([FromBody] MusicaRequestDto musicaDTO)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (musicaDTO == null) return RespostaPersonalizada();
                //if (!ExecutarValidacao(new MusicaDTOValidator(), musicaDTO)) return RespostaPersonalizada(ValidationResult);
                await _musicaAppService.Atualizar(musicaDTO);
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
        public async Task<IActionResult> ExcluirMusica([FromBody] MusicaRequestDto musicaDTO)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (musicaDTO == null) return RespostaPersonalizada();
                //if (!ExecutarValidacao(new MusicaDTOValidator(), musicaDTO)) return RespostaPersonalizada(ValidationResult);
                await _musicaAppService.Exluir(musicaDTO);
                AdicionaMensagemSucesso("Música excluída com sucesso.");
                return RespostaPersonalizada(StatusCodes.Status204NoContent);
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
