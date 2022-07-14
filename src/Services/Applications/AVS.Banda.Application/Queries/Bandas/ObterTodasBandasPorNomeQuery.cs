using AVS.Banda.Application.DTOs;
using AVS.Core.Mensagens;
using MediatR;

namespace AVS.Banda.Application.Queries.Bandas
{
    public class ObterTodasBandasPorNomeQuery : Query, IRequest<ObterTodasBandasQueryResponse>
    {
        public string Filtro { get; set; }
    }
}
