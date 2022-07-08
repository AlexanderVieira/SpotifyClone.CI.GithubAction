using AVS.Banda.Application.DTOs;
using AVS.Banda.Domain.Entities;
using System.Linq.Expressions;

namespace AVS.Banda.Application.Interfaces
{
    public interface IAlbumAppService
    {
        Task Atualizar(AlbumRequestDto request);
        //Task<AlbumResponseDto> BuscarPorCriterio(Expression<Func<Album, bool>> expression);
        Task<AlbumResponseDto> BuscarPorCriterio(Expression<Func<AlbumRequestDto, bool>> expression);
        //Task<IEnumerable<AlbumResponseDto>> BuscarTodosPorCriterio(Expression<Func<Album, bool>> expression);
        Task<IEnumerable<AlbumResponseDto>> BuscarTodosPorCriterio(Expression<Func<AlbumRequestDto, bool>> expression);
        Task Exluir(AlbumRequestDto request);
        Task<AlbumResponseDto> ObterPorId(object id);
        Task<IEnumerable<AlbumResponseDto>> ObterTodos();
        Task Salvar(AlbumRequestDto request);
    }
}