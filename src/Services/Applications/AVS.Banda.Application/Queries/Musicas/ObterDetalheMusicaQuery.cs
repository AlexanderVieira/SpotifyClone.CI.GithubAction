using AVS.Banda.Application.DTOs;
using AVS.Core.Mensagens;
using MediatR;

namespace AVS.Banda.Application.Queries.Musicas
{
    public class ObterDetalheMusicaQuery : Query, IRequest<ObterDetalheMusicaQueryResponse>
    {
        public Guid Id { get; set; }
    }

    public class ObterDetalheMusicaQueryResponse
    {
        public MusicaQueryAnonimaResponseDto Musica { get; set; }

        public ObterDetalheMusicaQueryResponse(MusicaQueryAnonimaResponseDto musica)
        {
            Musica = musica;
        }
    }
}
