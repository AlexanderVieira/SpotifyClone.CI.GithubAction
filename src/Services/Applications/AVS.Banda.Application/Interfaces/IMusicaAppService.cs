using AVS.Banda.Application.DTOs;
using AVS.Banda.Domain.Entities;
using System.Linq.Expressions;

namespace AVS.Banda.Application.Interfaces
{
    public interface IMusicaAppService
    {
        Task<IEnumerable<MusicaResponseDto>> ObterTodos();        
        Task<MusicaQueryAnonimaResponseDto> BuscarPorCriterio(Expression<Func<Musica, bool>> expression);
        Task<IEnumerable<MusicaQueryAnonimaResponseDto>> BuscarTodosPorCriterio(Expression<Func<Musica, bool>> expression);
        Task<MusicaResponseDto> ObterPorId(object id);        
        Task Salvar(MusicaRequestDto request);
        Task Atualizar(MusicaRequestDto request);
        Task Exluir(MusicaRequestDto entity);
    }
}