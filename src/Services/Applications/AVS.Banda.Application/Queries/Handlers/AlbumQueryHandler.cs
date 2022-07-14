using AVS.Banda.Application.Interfaces;
using AVS.Banda.Application.Queries.Albuns;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AVS.Banda.Application.Queries.Handlers
{
    public class AlbumQueryHandler : IRequestHandler<ObterTodosAlbunsQuery, ObterTodosAlbunsQueryResponse>,
                                     IRequestHandler<ObterTodosAlbunsPorNomeQuery, ObterTodosAlbunsQueryResponse>,
                                     IRequestHandler<ObterDetalheAlbumQuery, ObterDetalheAlbumQueryResponse>,
                                     IRequestHandler<ObterAlbumPorIdQuery, ObterAlbumPorIdQueryResponse>
    {
        private readonly IAlbumAppService _albumAppService;

        public AlbumQueryHandler(IAlbumAppService albumAppService)
        {
            _albumAppService = albumAppService;
        }

        public async Task<ObterTodosAlbunsQueryResponse> Handle(ObterTodosAlbunsQuery request, CancellationToken cancellationToken)
        {
            var albunsResponse = await _albumAppService.ObterTodos();
            return new ObterTodosAlbunsQueryResponse(albunsResponse);
        }

        public async Task<ObterTodosAlbunsQueryResponse> Handle(ObterTodosAlbunsPorNomeQuery request, CancellationToken cancellationToken)
        {
            var albunsResponse = await _albumAppService
                .BuscarTodosPorCriterio(a => EF.Functions.Like(a.Titulo.ToLower(), $"%{request.Filtro.ToLower()}%"));
            return new ObterTodosAlbunsQueryResponse(albunsResponse);
        }

        public async Task<ObterDetalheAlbumQueryResponse> Handle(ObterDetalheAlbumQuery request, CancellationToken cancellationToken)
        {
            var albumResponse = await _albumAppService
                .BuscarPorCriterio(a => a.Id == request.Id);
            return new ObterDetalheAlbumQueryResponse(albumResponse);
        }

        public async Task<ObterAlbumPorIdQueryResponse> Handle(ObterAlbumPorIdQuery request, CancellationToken cancellationToken)
        {
            var albumResponse = await _albumAppService.ObterPorId(request.Id);
            return new ObterAlbumPorIdQueryResponse(albumResponse);
        }
    }
}
