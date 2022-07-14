using AVS.Banda.Application.Commands.Playlists;
using AVS.Banda.Application.Interfaces;
using AVS.Core.Mensagens;
using FluentValidation.Results;
using MediatR;

namespace AVS.Banda.Application.Commands.Handlers
{
    public class PlaylistCommandHandler : IRequestHandler<AdicionarPlaylistCommand, ValidationResult>,
                                          IRequestHandler<AtualizarPlaylistCommand, ValidationResult>,
                                          IRequestHandler<ExcluirPlaylistCommand, ValidationResult>,
                                          IRequestHandler<AdicionarMusicaPlaylistCommand, ValidationResult>,
                                          IRequestHandler<ExcluirMusicaPlaylistCommand, ValidationResult>
    {
        
        private readonly IPlaylistAppService _playlistAppService;
        private readonly IMusicaPlaylistAppService _musicaPlaylistAppService;

        public PlaylistCommandHandler(IPlaylistAppService playlistAppService, IMusicaPlaylistAppService musicaPlaylistAppService)
        {
            _playlistAppService = playlistAppService;
            _musicaPlaylistAppService = musicaPlaylistAppService;
        }

        public async Task<ValidationResult> Handle(AdicionarPlaylistCommand mensagem, CancellationToken cancellationToken)
        {
            if (!ValidarComando(mensagem)) return mensagem.ValidationResult;
            
            var numero = 0;
            var playlistsExistentes = await _playlistAppService.BuscarTodosPorCriterio(x => x.UsuarioId == mensagem.PlaylistRequest.UsuarioId);            
            if (playlistsExistentes != null || (!playlistsExistentes.Any())) { numero = playlistsExistentes.Count(); }
            mensagem.PlaylistRequest.Titulo = $"Minha Playlist nº{++numero}";
            
            await _playlistAppService.Salvar(mensagem.PlaylistRequest);
            var playlistSalva = _playlistAppService.ObterPorId(mensagem.PlaylistRequest.Id);

            if (playlistSalva != null)
            {
                return mensagem.ValidationResult;
            }           
            
            AdicionarErroProcessamento(mensagem, "Ocorreu um erro ao tentar adicionar playlist.");
            return mensagem.ValidationResult;
        }      

        public async Task<ValidationResult> Handle(AtualizarPlaylistCommand mensagem, CancellationToken cancellationToken)
        {
            if (!ValidarComando(mensagem)) return mensagem.ValidationResult;

            var playlist = await _playlistAppService.ObterPorId(mensagem.PlaylistRequest.Id);
            if (playlist != null)
            {
                await _playlistAppService.Atualizar(mensagem.PlaylistRequest);
                return mensagem.ValidationResult;
            }
            AdicionarErroProcessamento(mensagem, "Ocorreu um erro ao tentar atualizar playlist.");
            return mensagem.ValidationResult;
        }

        public async Task<ValidationResult> Handle(ExcluirPlaylistCommand mensagem, CancellationToken cancellationToken)
        {
            if (!ValidarComando(mensagem)) return mensagem.ValidationResult;

            var playlist = await _playlistAppService.ObterPorId(mensagem.PlaylistRequest.Id);
            if (playlist != null)
            {
                await _playlistAppService.Exluir(mensagem.PlaylistRequest);
                return mensagem.ValidationResult;
            }
            AdicionarErroProcessamento(mensagem, "Ocorreu um erro ao tentar excluir playlist.");
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

        public async Task<ValidationResult> Handle(AdicionarMusicaPlaylistCommand mensagem, CancellationToken cancellationToken)
        {
            if (!ValidarComando(mensagem)) return mensagem.ValidationResult;

            var musicaPlaylist = await _musicaPlaylistAppService
                .BuscarPorCriterio(mp => 
                mp.PlaylistId == mensagem.MusicaPlaylistRequest.PlaylistId && mp.MusicaId == mensagem.MusicaPlaylistRequest.MusicaId);
            if (musicaPlaylist != null)
            {
                await _musicaPlaylistAppService.Salvar(mensagem.MusicaPlaylistRequest);
                return mensagem.ValidationResult;
            }
            AdicionarErroProcessamento(mensagem, "Ocorreu um erro ao tentar adicionar música à playlist.");
            return mensagem.ValidationResult;
        }

        public async Task<ValidationResult> Handle(ExcluirMusicaPlaylistCommand mensagem, CancellationToken cancellationToken)
        {
            if (!ValidarComando(mensagem)) return mensagem.ValidationResult;

            var playlist = await _musicaPlaylistAppService
                .BuscarPorCriterio(mp => 
                mp.PlaylistId == mensagem.MusicaPlaylistRequest.PlaylistId && mp.MusicaId == mensagem.MusicaPlaylistRequest.MusicaId);
            if (playlist != null)
            {
                await _musicaPlaylistAppService.Exluir(mensagem.MusicaPlaylistRequest);
                return mensagem.ValidationResult;
            }
            AdicionarErroProcessamento(mensagem, "Ocorreu um erro ao tentar excluir música associada a playlist.");
            return mensagem.ValidationResult;
        }
    }
}
 