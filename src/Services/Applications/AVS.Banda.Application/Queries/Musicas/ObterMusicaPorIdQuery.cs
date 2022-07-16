using AVS.Banda.Application.DTOs;
using AVS.Core.Mensagens;
using MediatR;

namespace AVS.Banda.Application.Queries.Musicas
{
    public class ObterMusicaPorIdQuery : Query, IRequest<ObterMusicaPorIdQueryResponse>
    {
        public Guid Id { get; set; }
    }

    public class ObterMusicaPorIdQueryResponse
    {
        public MusicaResponseDto Musica { get; set; }

        public ObterMusicaPorIdQueryResponse(MusicaResponseDto musica)
        {
            Musica = musica;
        }
    }
}
