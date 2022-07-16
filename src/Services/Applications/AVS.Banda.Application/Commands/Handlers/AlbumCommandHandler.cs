using AVS.Banda.Application.Commands.Albuns;
using AVS.Banda.Application.Interfaces;
using AVS.Core.Mensagens;
using FluentValidation.Results;
using MediatR;

namespace AVS.Banda.Application.Commands.Handlers
{
    public class AlbumCommandHandler : IRequestHandler<AdicionarAlbumCommand, ValidationResult>,
                                       IRequestHandler<AtualizarAlbumCommand, ValidationResult>,
                                       IRequestHandler<ExcluirAlbumCommand, ValidationResult>                                         
    {
        
        private readonly IAlbumAppService _albumAppService;

        public AlbumCommandHandler(IAlbumAppService albumAppService)
        {
            _albumAppService = albumAppService;
        }

        public async Task<ValidationResult> Handle(AdicionarAlbumCommand mensagem, CancellationToken cancellationToken)
        {
            if (!ValidarComando(mensagem)) return mensagem.ValidationResult;
            
            var album = await _albumAppService.ObterPorId(mensagem.AlbumRequest.Id);
            if (album == null)
            {
                await _albumAppService.Salvar(mensagem.AlbumRequest);
                return mensagem.ValidationResult;
            }
            AdicionarErroProcessamento(mensagem, "Ocorreu um erro ao tentar adicionar album.");
            return mensagem.ValidationResult;
        }      

        public async Task<ValidationResult> Handle(AtualizarAlbumCommand mensagem, CancellationToken cancellationToken)
        {
            if (!ValidarComando(mensagem)) return mensagem.ValidationResult;

            var album = await _albumAppService.ObterPorId(mensagem.AlbumRequest.Id);
            if (album != null)
            {
                await _albumAppService.Atualizar(mensagem.AlbumRequest);
                return mensagem.ValidationResult;
            }
            AdicionarErroProcessamento(mensagem, "Ocorreu um erro ao tentar atualizar album.");
            return mensagem.ValidationResult;
        }

        public async Task<ValidationResult> Handle(ExcluirAlbumCommand mensagem, CancellationToken cancellationToken)
        {
            if (!ValidarComando(mensagem)) return mensagem.ValidationResult;

            var album = await _albumAppService.ObterPorId(mensagem.AlbumRequest.Id);
            if (album != null)
            {
                await _albumAppService.Exluir(mensagem.AlbumRequest);
                return mensagem.ValidationResult;
            }
            AdicionarErroProcessamento(mensagem, "Ocorreu um erro ao tentar excluir album.");
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
 