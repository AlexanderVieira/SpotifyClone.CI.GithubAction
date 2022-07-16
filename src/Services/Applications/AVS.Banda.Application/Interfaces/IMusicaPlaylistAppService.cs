using AVS.Banda.Application.DTOs;
using AVS.Banda.Domain.Entities;
using System.Linq.Expressions;

namespace AVS.Banda.Application.Interfaces
{
    public interface IMusicaPlaylistAppService
    {
        Task<MusicaPlaylistResponseDto> BuscarPorCriterio(Expression<Func<MusicaPlaylist, bool>> expression);
        Task Salvar(MusicaPlaylistRequestDto request);
        Task Exluir(MusicaPlaylistRequestDto request);
        Task<bool> Commit();
    }
}
 