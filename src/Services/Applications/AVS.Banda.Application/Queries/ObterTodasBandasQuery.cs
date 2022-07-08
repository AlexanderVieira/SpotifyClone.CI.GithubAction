using AVS.Banda.Application.DTOs;
using AVS.Core.Mensagens;
using MediatR;

namespace AVS.Banda.Application.Queries
{
    public class ObterTodasBandasQuery : Query, IRequest<ObterTodasBandasQueryResponse>
    {
    }

    public class ObterTodasBandasQueryResponse
    {
        public IEnumerable<BandaResponseDto> Bandas { get; set; }

        public ObterTodasBandasQueryResponse(IEnumerable<BandaResponseDto> bandas)
        {
            Bandas = bandas;
        }
    }
}
