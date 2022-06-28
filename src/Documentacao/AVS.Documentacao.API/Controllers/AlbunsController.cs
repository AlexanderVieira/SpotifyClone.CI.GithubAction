using AVS.Banda.Domain.AppServices.DTOs;
using AVS.Banda.Domain.Interfaces.AppServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AVS.Documentacao.API.Controllers
{
    [Route("api")]    
    public class AlbunsController : PrincipalController
    {
        private readonly IAlbumAppService _albumAppService;

        public AlbunsController(IAlbumAppService albumAppService)
        {
            _albumAppService = albumAppService;
        }
        
        [HttpGet("albuns")]
        public async Task<IActionResult> ObterTodosAlbuns()
        {
            try
            {
                var albuns = await _albumAppService.ObterTodos();
                return albuns == null || (!albuns.Any()) ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Não existem dados para exibição.") : RespostaPersonalizada(albuns.ToArray());
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpGet("albuns/{filtro}")]
        public async Task<IActionResult> ObterTodosAlbuns(string filtro)
        {
            try
            {
                //EF.Functions.Like(b.Nome, $"%{filtro}%")
                var albuns = await _albumAppService.BuscarTodosPorCriterio(a => EF.Functions.Like(a.Titulo.ToLower(), $"%{filtro.ToLower()}%"));
                return albuns == null || (!albuns.Any()) ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Não existem dados para exibição.") : RespostaPersonalizada(albuns.ToArray());
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
                var album = await _albumAppService.BuscarPorCriterio(b => b.Id == id);
                return album == null ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Banda não encontrada.") : RespostaPersonalizada(album);
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
                var album = await _albumAppService.ObterPorId(id);
                return album == null ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Album não encontrado.") : RespostaPersonalizada(album);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpPost("album/adicionar")]
        public async Task<IActionResult> AdicionarAlbum(AlbumDTO albumDTO)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (albumDTO == null) return RespostaPersonalizada();
                if (!ExecutarValidacao(new AlbumDTOValidator(), albumDTO)) return RespostaPersonalizada(ValidationResult);
                await _albumAppService.Salvar(albumDTO);
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
        public async Task<IActionResult> AtualizarAlbum([FromBody] AlbumDTO albumDTO)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (albumDTO == null) return RespostaPersonalizada();
                if (!ExecutarValidacao(new AlbumDTOValidator(), albumDTO)) return RespostaPersonalizada(ValidationResult);
                await _albumAppService.Atualizar(albumDTO);
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
        public async Task<IActionResult> ExcluirAlbum([FromBody] AlbumDTO albumDTO)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (albumDTO == null) return RespostaPersonalizada();
                if (!ExecutarValidacao(new AlbumDTOValidator(), albumDTO)) return RespostaPersonalizada(ValidationResult);
                await _albumAppService.Exluir(albumDTO);
                AdicionaMensagemSucesso("Album excluído com sucesso.");
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
