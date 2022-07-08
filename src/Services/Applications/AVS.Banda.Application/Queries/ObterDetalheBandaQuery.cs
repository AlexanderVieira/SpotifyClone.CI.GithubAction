using AVS.Banda.Application.DTOs;
using AVS.Core.Mensagens;
using MediatR;

namespace AVS.Banda.Application.Queries
{
    public class ObterDetalheBandaQuery : Query, IRequest<ObterDetalheBandaQueryResponse>
    {
        public Guid Id { get; set; }
    }

    public class ObterDetalheBandaQueryResponse
    {
        public BandaResponseDto Banda { get; set; }

        public ObterDetalheBandaQueryResponse(BandaResponseDto banda)
        {
            Banda = banda;
        }
    }
}
