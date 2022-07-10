using AVS.Banda.Application.Commands;
using AVS.Banda.Application.DTOs;
using AVS.Banda.Application.Queries;
using AVS.Core.Comunicacao.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace AVS.Documentacao.API.Controllers
{
    [Route("api")]    
    public class BandasController : PrincipalController
    {        
        private readonly IMediatorHandler _mediatorHandler;

        public BandasController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("bandas")]
        public async Task<IActionResult> ObterTodasBandas()
        {
            try
            {               
                var response = (ObterTodasBandasQueryResponse) await _mediatorHandler
                                                                        .EnviarQuery(new ObterTodasBandasQuery());
                return response.Bandas.ToList() == null || (!response.Bandas.ToList().Any()) ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Não existem dados para exibição.") : RespostaPersonalizada(response.Bandas.ToArray());
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
                var response = (ObterTodasBandasQueryResponse)await _mediatorHandler
                                                                        .EnviarQuery(new ObterTodasBandasPorNomeQuery { Filtro = filtro });
                return response.Bandas == null || (!response.Bandas.Any()) ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Não existem dados para exibição.") : RespostaPersonalizada(response.Bandas.ToArray());
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
                var response = (ObterDetalheBandaQueryResponse)await _mediatorHandler
                                                                        .EnviarQuery(new ObterDetalheBandaQuery { Id = id });
                return response.Banda == null ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Banda não encontrada.") : RespostaPersonalizada(response.Banda);
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
                var response = (ObterBandaPorIdQueryResponse)await _mediatorHandler
                                                                        .EnviarQuery(new ObterBandaPorIdQuery { Id = id });
                return response.Banda == null ? ProcessarRespostaMensagem(
                    StatusCodes.Status404NotFound, "Banda não encontrada.") : RespostaPersonalizada(response.Banda);
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
                var comando = new AdicionarBandaCommand(request);
                ValidationResult = await _mediatorHandler.EnviarComando(comando);
                if (!ValidationResult.IsValid) return RespostaPersonalizada(ValidationResult);
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
                var comando = new AtualizarBandaCommand(request);
                ValidationResult = await _mediatorHandler.EnviarComando(comando);
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
                var comando = new ExcluirBandaCommand(request);
                ValidationResult = await _mediatorHandler.EnviarComando(comando);
                AdicionaMensagemSucesso("Banda excluída com sucesso.");
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
