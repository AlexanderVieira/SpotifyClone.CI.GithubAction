using AVS.Banda.Application.DTOs;
using AVS.Core.Mensagens;
using MediatR;

namespace AVS.Banda.Application.Queries
{
    public class ObterBandaPorIdQuery : Query, IRequest<ObterBandaPorIdQueryResponse>
    {
        public Guid Id { get; set; }
    }

    public class ObterBandaPorIdQueryResponse
    {
        public BandaResponseDto Banda { get; set; }

        public ObterBandaPorIdQueryResponse(BandaResponseDto banda)
        {
            Banda = banda;
        }
    }
}
