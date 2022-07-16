using AVS.Banda.Application.DTOs;
using AVS.Core.Mensagens;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVS.Banda.Application.Queries.Playlists
{
    public class ObterTodasPlaylistsPorNomeQuery : Query, IRequest<ObterTodasPlaylistsPorNomeQueryResponse>
    {
        public string Filtro { get; set; }
        public Guid UsuarioId { get; set; }
    }

    public class ObterTodasPlaylistsPorNomeQueryResponse
    {
        public IEnumerable<PlaylistMusicasQueryAnonimaResponseDto> Playlists { get; set; }

        public ObterTodasPlaylistsPorNomeQueryResponse(IEnumerable<PlaylistMusicasQueryAnonimaResponseDto> playlists)
        {
            Playlists = playlists;
        }
    }
}
