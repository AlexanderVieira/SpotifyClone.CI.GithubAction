using AVS.Banda.Application.DTOs;
using AVS.Banda.Domain.Entities;
using System.Linq.Expressions;

namespace AVS.Banda.Application.Interfaces
{
    public interface IAlbumAppService
    {
        Task<IEnumerable<AlbumResponseDto>> ObterTodos();        
        Task<IEnumerable<AlbumResponseDto>> BuscarTodosPorCriterio(Expression<Func<Album, bool>> expression);
        Task<AlbumResponseDto> BuscarPorCriterio(Expression<Func<Album, bool>> expression);
        Task<AlbumResponseDto> ObterPorId(object id);        
        Task Salvar(AlbumRequestDto request);
        Task Atualizar(AlbumRequestDto request);
        Task Exluir(AlbumRequestDto request);
    }
}