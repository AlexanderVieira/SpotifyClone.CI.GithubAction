using AVS.Banda.Application.DTOs;
using AVS.Core.Mensagens;
using MediatR;

namespace AVS.Banda.Application.Queries.Musicas
{
    public class ObterTodasMusicasQuery : Query, IRequest<ObterTodasMusicasQueryResponse>
    {
        
    }

    public class ObterTodasMusicasQueryResponse
    {
        public IEnumerable<MusicaResponseDto> Musicas { get; set; }

        public ObterTodasMusicasQueryResponse(IEnumerable<MusicaResponseDto> musicas)
        {
            Musicas = musicas;
        }
    }
}
