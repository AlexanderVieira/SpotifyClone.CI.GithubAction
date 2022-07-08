using AVS.Banda.Application.DTOs;
using AVS.Banda.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AVS.Documentacao.API.Controllers
{
    [Route("api")]    
    public class BandasController : PrincipalController
    {
        private readonly IBandaAppService _bandaAppService;

        public BandasController(IBandaAppService bandaAppService)
        {
            _bandaAppService = bandaAppService;
        }
        
        [HttpGet("bandas")]
        public async Task<IActionResult> ObterTodasBandas()
        {
            try
            {
                var response = await _bandaAppService.ObterTodos();
                return response == null || (!response.Any()) ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Não existem dados para exibição.") : RespostaPersonalizada(response.ToArray());
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpGet("bandas/{filtro}")]
        public async Task<IActionResult> ObterTodasBandas(string filtro)
        {
            try
            {
                //EF.Functions.Like(b.Nome, $"%{filtro}%")
                var response = await _bandaAppService.BuscarTodosPorCriterio(b => b.Nome.ToLower().Contains(filtro.ToLower()));
                return response == null || (!response.Any()) ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Não existem dados para exibição.") : RespostaPersonalizada(response.ToArray());
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpGet("banda/detalhe/{id}")]
        public async Task<IActionResult> ObterBandaComAlbum(Guid id)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                var response = await _bandaAppService.BuscarPorCriterio(b => b.Id == id);
                return response == null ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Banda não encontrada.") : RespostaPersonalizada(response);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpGet("banda/{id}")]
        public async Task<IActionResult> ObterBandaPorId(Guid id)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                var response = await _bandaAppService.ObterPorId(id);
                return response == null ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Banda não encontrada.") : RespostaPersonalizada(response);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }

        [HttpPost("banda/adicionar")]
        public async Task<IActionResult> AdicionarBanda([FromBody] BandaRequestDto request)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (request == null) return RespostaPersonalizada();
                //if (!ExecutarValidacao(new requestValidator(), request)) return RespostaPersonalizada(ValidationResult);
                await _bandaAppService.Salvar(request);
                AdicionaMensagemSucesso("Banda adicionada com sucesso.");
                return RespostaPersonalizada(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }
        }

        [HttpPut("banda/atualizar")]
        public async Task<IActionResult> AtualizarBanda([FromBody] BandaRequestDto request)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (request == null) return RespostaPersonalizada();
                //if (!ExecutarValidacao(new requestValidator(), request)) return RespostaPersonalizada(ValidationResult);
                await _bandaAppService.Atualizar(request);
                AdicionaMensagemSucesso("Banda atualizada com sucesso.");
                return RespostaPersonalizada(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                AdicionarErroProcessamento(ex.Message);
                return RespostaPersonalizada();
            }

        }        

        [HttpDelete("banda/excluir")]
        public async Task<IActionResult> ExcluirBanda([FromBody] BandaRequestDto request)
        {
            if (!ModelState.IsValid) return RespostaPersonalizada();
            try
            {
                if (request == null) return RespostaPersonalizada();
                //if (!ExecutarValidacao(new requestValidator(), request)) return RespostaPersonalizada(ValidationResult);
                await _bandaAppService.Exluir(request);
                AdicionaMensagemSucesso("Banda excluída com sucesso.");
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
