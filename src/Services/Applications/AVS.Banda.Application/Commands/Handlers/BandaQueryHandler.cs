using AVS.Banda.Application.Interfaces;
using AVS.Banda.Application.Queries;
using MediatR;

namespace AVS.Banda.Application.Commands.Handlers
{
    public class BandaQueryHandler : IRequestHandler<ObterTodasBandasQuery, ObterTodasBandasQueryResponse>,
                                     IRequestHandler<ObterTodasBandasPorNomeQuery, ObterTodasBandasQueryResponse>,
                                     IRequestHandler<ObterDetalheBandaQuery, ObterDetalheBandaQueryResponse>,
                                     IRequestHandler<ObterBandaPorIdQuery, ObterBandaPorIdQueryResponse>
    {
        private readonly IBandaAppService _bandaAppService;

        public BandaQueryHandler(IBandaAppService bandaAppService)
        {
            _bandaAppService = bandaAppService;
        }

        public async Task<ObterTodasBandasQueryResponse> Handle(ObterTodasBandasQuery request, CancellationToken cancellationToken)
        {
            var bandasResponse = await _bandaAppService.ObterTodos();
            return new ObterTodasBandasQueryResponse(bandasResponse);
        }

        public async Task<ObterTodasBandasQueryResponse> Handle(ObterTodasBandasPorNomeQuery request, CancellationToken cancellationToken)
        {
            var bandasResponse = await _bandaAppService
                .BuscarTodosPorCriterio(b => b.Nome.ToLower().Contains(request.Filtro.ToLower()));
            return new ObterTodasBandasQueryResponse(bandasResponse);            
        }

        public async Task<ObterDetalheBandaQueryResponse> Handle(ObterDetalheBandaQuery request, CancellationToken cancellationToken)
        {
            var bandaResponse = await _bandaAppService
                .BuscarPorCriterio(b => b.Id == request.Id);
            return new ObterDetalheBandaQueryResponse(bandaResponse);
        }

        public async Task<ObterBandaPorIdQueryResponse> Handle(ObterBandaPorIdQuery request, CancellationToken cancellationToken)
        {
            var bandaResponse = await _bandaAppService.ObterPorId(request.Id);
            return new ObterBandaPorIdQueryResponse(bandaResponse);
        }
    }
}
