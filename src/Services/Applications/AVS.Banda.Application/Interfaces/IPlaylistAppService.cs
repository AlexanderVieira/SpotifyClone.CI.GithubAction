using AVS.Banda.Application.DTOs;
using AVS.Banda.Domain.Entities;
using System.Linq.Expressions;

namespace AVS.Banda.Application.Interfaces
{
    public interface IPlaylistAppService
    {
        Task<IEnumerable<PlaylistResponseDto>> ObterTodos();
        Task<IEnumerable<PlaylistResponseDto>> BuscarTodosPorCriterio(Expression<Func<Playlist, bool>> expression);
        Task<IEnumerable<PlaylistMusicasQueryAnonimaResponseDto>> BuscarPlaylistsPorCriterio(Expression<Func<Playlist, bool>> expression);
        Task<PlaylistMusicasQueryAnonimaResponseDto> BuscarPlaylistComMusicas(Expression<Func<Playlist, bool>> expression);
        Task<PlaylistResponseDto> ObterPorId(object id);
        Task Salvar(PlaylistRequestDto request);
        Task Atualizar(PlaylistRequestDto request);
        Task Exluir(PlaylistRequestDto entity);

    }
}
