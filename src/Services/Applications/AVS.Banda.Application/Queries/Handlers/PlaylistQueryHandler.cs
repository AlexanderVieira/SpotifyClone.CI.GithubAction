using AVS.Banda.Application.Interfaces;
using AVS.Banda.Application.Queries.Playlists;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AVS.Banda.Application.Queries.Handlers
{
    public class PlaylistQueryHandler : IRequestHandler<ObterTodasPlaylistsQuery, ObterTodasPlaylistsQueryResponse>,
                                        IRequestHandler<ObterTodasPlaylistsPorNomeQuery, ObterTodasPlaylistsPorNomeQueryResponse>,
                                        IRequestHandler<ObterDetalhePlaylistQuery, ObterDetalhePlaylistQueryResponse>,
                                        IRequestHandler<ObterPlaylistComMusicasQuery, ObterPlaylistComMusicasQueryResponse>                                        
    {
        private readonly IPlaylistAppService _playlistAppService;

        public PlaylistQueryHandler(IPlaylistAppService playlistAppService)
        {
            _playlistAppService = playlistAppService;
        }

        public async Task<ObterTodasPlaylistsQueryResponse> Handle(ObterTodasPlaylistsQuery request, CancellationToken cancellationToken)
        {
            var playlists = await _playlistAppService.ObterTodos();
            return new ObterTodasPlaylistsQueryResponse(playlists);
        }

        public async Task<ObterTodasPlaylistsPorNomeQueryResponse> Handle(ObterTodasPlaylistsPorNomeQuery request, CancellationToken cancellationToken)
        {
            var playlists = await _playlistAppService
                .BuscarPlaylistsPorCriterio(p => EF.Functions.Like(p.Titulo.ToLower(), $"%{request.Filtro.ToLower()}%") && p.UsuarioId == request.UsuarioId );
            return new ObterTodasPlaylistsPorNomeQueryResponse(playlists);
        }

        public async Task<ObterDetalhePlaylistQueryResponse> Handle(ObterDetalhePlaylistQuery request, CancellationToken cancellationToken)
        {
            var playlist = await _playlistAppService.ObterPorId(request.Id);                                        
            return new ObterDetalhePlaylistQueryResponse(playlist);
        }

        public async Task<ObterPlaylistComMusicasQueryResponse> Handle(ObterPlaylistComMusicasQuery request, CancellationToken cancellationToken)
        {
            var playlist = await _playlistAppService.BuscarPlaylistComMusicas(x => x.UsuarioId == request.UsuarioId);
            return new ObterPlaylistComMusicasQueryResponse(playlist);
        }
    }
}
