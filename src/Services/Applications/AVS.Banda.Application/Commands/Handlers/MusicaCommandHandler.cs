using AVS.Banda.Application.Commands.Musicas;
using AVS.Banda.Application.Interfaces;
using AVS.Core.Mensagens;
using FluentValidation.Results;
using MediatR;

namespace AVS.Banda.Application.Commands.Handlers
{
    public class MusicaCommandHandler : IRequestHandler<AdicionarMusicaCommand, ValidationResult>,
                                       IRequestHandler<AtualizarMusicaCommand, ValidationResult>,
                                       IRequestHandler<ExcluirMusicaCommand, ValidationResult>                                         
    {
        
        private readonly IMusicaAppService _musicaAppService;

        public MusicaCommandHandler(IMusicaAppService musicaAppService)
        {
            _musicaAppService = musicaAppService;
        }

        public async Task<ValidationResult> Handle(AdicionarMusicaCommand mensagem, CancellationToken cancellationToken)
        {
            if (!ValidarComando(mensagem)) return mensagem.ValidationResult;
            
            var musica = await _musicaAppService.ObterPorId(mensagem.MusicaRequest.Id);
            if (musica == null)
            {
                await _musicaAppService.Salvar(mensagem.MusicaRequest);
                return mensagem.ValidationResult;
            }
            AdicionarErroProcessamento(mensagem, "Ocorreu um erro ao tentar adicionar musica.");
            return mensagem.ValidationResult;
        }      

        public async Task<ValidationResult> Handle(AtualizarMusicaCommand mensagem, CancellationToken cancellationToken)
        {
            if (!ValidarComando(mensagem)) return mensagem.ValidationResult;

            var musica = await _musicaAppService.ObterPorId(mensagem.MusicaRequest.Id);
            if (musica != null)
            {
                await _musicaAppService.Atualizar(mensagem.MusicaRequest);
                return mensagem.ValidationResult;
            }
            AdicionarErroProcessamento(mensagem, "Ocorreu um erro ao tentar atualizar musica.");
            return mensagem.ValidationResult;
        }

        public async Task<ValidationResult> Handle(ExcluirMusicaCommand mensagem, CancellationToken cancellationToken)
        {
            if (!ValidarComando(mensagem)) return mensagem.ValidationResult;

            var musica = await _musicaAppService.ObterPorId(mensagem.MusicaRequest.Id);
            if (musica != null)
            {
                await _musicaAppService.Exluir(mensagem.MusicaRequest);
                return mensagem.ValidationResult;
            }
            AdicionarErroProcessamento(mensagem, "Ocorreu um erro ao tentar excluir musica.");
            return mensagem.ValidationResult;
        }

        private static bool ValidarComando(Comando mensagem)
        {
            if (mensagem.EhValido()) return true;
            return false;
        }

        protected static void AdicionarErroProcessamento(Comando mensagem, string mensagemErro)
        {
            mensagem.ValidationResult.Errors.Add(new ValidationFailure(mensagem.TipoMensagem, mensagemErro));
        }
    }
}
 