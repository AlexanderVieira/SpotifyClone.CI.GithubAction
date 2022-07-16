using AVS.Cadastro.Application.Interfaces;
using AVS.Core.Comunicacao.Mediator;
using AVS.Core.Mensagens;
using FluentValidation.Results;
using MediatR;

namespace AVS.Cadastro.Application.Commands.Handlers
{
    public class UsuarioCommandHandler : IRequestHandler<AdicionarUsuarioCommand, ValidationResult>,
                                         IRequestHandler<AtualizarUsuarioCommand, ValidationResult>,
                                         IRequestHandler<ExcluirUsuarioCommand, ValidationResult>,
                                         IRequestHandler<AtivarUsuarioCommand, ValidationResult>,
                                         IRequestHandler<InativarUsuarioCommand, ValidationResult>
    {
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioCommandHandler(IMediatorHandler mediatorHandler, IUsuarioAppService usuarioAppService)
        {
            _mediatorHandler = mediatorHandler;
            _usuarioAppService = usuarioAppService;
        }

        public async Task<ValidationResult> Handle(AdicionarUsuarioCommand mensagem, CancellationToken cancellationToken)
        {
            if (!ValidarComando(mensagem)) return mensagem.ValidationResult;
            
            var usuario = await _usuarioAppService.ObterPorId(mensagem.UsuarioRequest.Id);
            if (usuario == null)
            {
                await _usuarioAppService.Salvar(mensagem.UsuarioRequest);
                return mensagem.ValidationResult;
            }
            AdicionarErroProcessamento(mensagem, "Usuário já existe.");
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

        public async Task<ValidationResult> Handle(AtualizarUsuarioCommand mensagem, CancellationToken cancellationToken)
        {
            if (!ValidarComando(mensagem)) return mensagem.ValidationResult;

            var usuario = await _usuarioAppService.ObterPorId(mensagem.UsuarioRequest.Id);
            if (usuario != null)
            {
                await _usuarioAppService.Atualizar(mensagem.UsuarioRequest);
                return mensagem.ValidationResult;
            }
            AdicionarErroProcessamento(mensagem, "Ocorreu um erro ao tentar atualizar usuário.");
            return mensagem.ValidationResult;
        }

        public async Task<ValidationResult> Handle(ExcluirUsuarioCommand mensagem, CancellationToken cancellationToken)
        {
            if (!ValidarComando(mensagem)) return mensagem.ValidationResult;

            var usuario = await _usuarioAppService.ObterPorId(mensagem.UsuarioRequest.Id);
            if (usuario != null)
            {
                await _usuarioAppService.Exluir(mensagem.UsuarioRequest);
                return mensagem.ValidationResult;
            }
            AdicionarErroProcessamento(mensagem, "Ocorreu um erro ao tentar excluir usuário.");
            return mensagem.ValidationResult;
        }

        public async Task<ValidationResult> Handle(AtivarUsuarioCommand mensagem, CancellationToken cancellationToken)
        {
            if (!ValidarComando(mensagem)) return mensagem.ValidationResult;

            var usuario = await _usuarioAppService.ObterPorId(mensagem.UsuarioRequest.Id);
            if (usuario != null)
            {
                await _usuarioAppService.Ativar(mensagem.UsuarioRequest);
                return mensagem.ValidationResult;
            }
            AdicionarErroProcessamento(mensagem, "Ocorreu um erro ao tentar Ativar usuário.");
            return mensagem.ValidationResult;
        }

        public async Task<ValidationResult> Handle(InativarUsuarioCommand mensagem, CancellationToken cancellationToken)
        {
            if (!ValidarComando(mensagem)) return mensagem.ValidationResult;

            var usuario = await _usuarioAppService.ObterPorId(mensagem.UsuarioRequest.Id);
            if (usuario != null)
            {
                await _usuarioAppService.Inativar(mensagem.UsuarioRequest);
                return mensagem.ValidationResult;
            }
            AdicionarErroProcessamento(mensagem, "Ocorreu um erro ao tentar Inativar usuário.");
            return mensagem.ValidationResult;
        }
    }
}
 