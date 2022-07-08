using AVS.Banda.Application.Interfaces;
using AVS.Core.Mensagens;
using FluentValidation.Results;
using MediatR;

namespace AVS.Banda.Application.Commands.Handlers
{
    public class BandaCommandHandler : IRequestHandler<AdicionarBandaCommand, ValidationResult>,
                                       IRequestHandler<AtualizarBandaCommand, ValidationResult>,
                                       IRequestHandler<ExcluirBandaCommand, ValidationResult>                                         
    {
        
        private readonly IBandaAppService _bandaAppService;

        public BandaCommandHandler(IBandaAppService bandaAppService)
        {
            _bandaAppService = bandaAppService;
        }

        public async Task<ValidationResult> Handle(AdicionarBandaCommand mensagem, CancellationToken cancellationToken)
        {
            if (!ValidarComando(mensagem)) return mensagem.ValidationResult;
            
            var banda = await _bandaAppService.ObterPorId(mensagem.BandaRequest.Id);
            if (banda == null)
            {
                await _bandaAppService.Salvar(mensagem.BandaRequest);
                return mensagem.ValidationResult;
            }
            AdicionarErroProcessamento(mensagem, "Ocorreu um erro ao tentar adicionar banda.");
            return mensagem.ValidationResult;
        }

        private bool ValidarComando(Comando mensagem)
        {
            if (mensagem.EhValido()) return true;            
            return false;
        }

        protected void AdicionarErroProcessamento(Comando mensagem, string mensagemErro)
        {
            mensagem.ValidationResult.Errors.Add(new ValidationFailure(mensagem.TipoMensagem, mensagemErro));
        }

        public async Task<ValidationResult> Handle(AtualizarBandaCommand mensagem, CancellationToken cancellationToken)
        {
            if (!ValidarComando(mensagem)) return mensagem.ValidationResult;

            var banda = await _bandaAppService.ObterPorId(mensagem.BandaRequest.Id);
            if (banda != null)
            {
                await _bandaAppService.Atualizar(mensagem.BandaRequest);
                return mensagem.ValidationResult;
            }
            AdicionarErroProcessamento(mensagem, "Ocorreu um erro ao tentar atualizar banda.");
            return mensagem.ValidationResult;
        }

        public async Task<ValidationResult> Handle(ExcluirBandaCommand mensagem, CancellationToken cancellationToken)
        {
            if (!ValidarComando(mensagem)) return mensagem.ValidationResult;

            var banda = await _bandaAppService.ObterPorId(mensagem.BandaRequest.Id);
            if (banda != null)
            {
                await _bandaAppService.Exluir(mensagem.BandaRequest);
                return mensagem.ValidationResult;
            }
            AdicionarErroProcessamento(mensagem, "Ocorreu um erro ao tentar excluir banda.");
            return mensagem.ValidationResult;
        }
    }
}
 