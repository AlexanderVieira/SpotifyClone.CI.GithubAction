using AVS.Banda.Application.Interfaces;
using AVS.Banda.Application.Queries.Musicas;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AVS.Banda.Application.Queries.Handlers
{
    public class MusicaQueryHandler : IRequestHandler<ObterTodasMusicasQuery, ObterTodasMusicasQueryResponse>,
                                     IRequestHandler<ObterTodasMusicasPorNomeQuery, ObterTodasMusicasPorNomeQueryResponse>,
                                     IRequestHandler<ObterDetalheMusicaQuery, ObterDetalheMusicaQueryResponse>,
                                     IRequestHandler<ObterMusicaPorIdQuery, ObterMusicaPorIdQueryResponse>
    {
        private readonly IMusicaAppService _musicaAppService;

        public MusicaQueryHandler(IMusicaAppService musicaAppService)
        {
            _musicaAppService = musicaAppService;
        }

        public async Task<ObterTodasMusicasQueryResponse> Handle(ObterTodasMusicasQuery request, CancellationToken cancellationToken)
        {
            var albunsResponse = await _musicaAppService.ObterTodos();
            return new ObterTodasMusicasQueryResponse(albunsResponse);
        }

        public async Task<ObterTodasMusicasPorNomeQueryResponse> Handle(ObterTodasMusicasPorNomeQuery request, CancellationToken cancellationToken)
        {
            var musicasResponse = await _musicaAppService
                .BuscarTodosPorCriterio(a => EF.Functions.Like(a.Nome.ToLower(), $"%{request.Filtro.ToLower()}%"));
            return new ObterTodasMusicasPorNomeQueryResponse(musicasResponse);
        }

        public async Task<ObterDetalheMusicaQueryResponse> Handle(ObterDetalheMusicaQuery request, CancellationToken cancellationToken)
        {
            var musicaResponse = await _musicaAppService
                                        .BuscarPorCriterio(a => a.Id == request.Id);
            return new ObterDetalheMusicaQueryResponse(musicaResponse);
        }

        public async Task<ObterMusicaPorIdQueryResponse> Handle(ObterMusicaPorIdQuery request, CancellationToken cancellationToken)
        {
            var musicaResponse = await _musicaAppService.ObterPorId(request.Id);
            return new ObterMusicaPorIdQueryResponse(musicaResponse);
        }
    }
}
