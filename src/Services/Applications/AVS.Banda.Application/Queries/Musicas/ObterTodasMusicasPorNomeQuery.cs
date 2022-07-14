using AVS.Banda.Application.DTOs;
using AVS.Core.Mensagens;
using MediatR;

namespace AVS.Banda.Application.Queries.Musicas
{
    public class ObterTodasMusicasPorNomeQuery : Query, IRequest<ObterTodasMusicasPorNomeQueryResponse>
    {
        public string Filtro { get; set; }
    }
    public class ObterTodasMusicasPorNomeQueryResponse
    {
        public IEnumerable<MusicaAlbumResponseDto> Musicas { get; set; }

        public ObterTodasMusicasPorNomeQueryResponse(IEnumerable<MusicaAlbumResponseDto> musicas)
        {
            Musicas = musicas;
        }
    }
}
