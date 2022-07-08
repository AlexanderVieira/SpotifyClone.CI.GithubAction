using AVS.Banda.Application.DTOs;
using AVS.Banda.Domain.ConsultasProjetadas;
using AVS.Banda.Domain.Entities;
using System.Linq.Expressions;

namespace AVS.Banda.Application.Interfaces
{
    public interface IMusicaAppService
    {
        Task Atualizar(MusicaRequestDto request);
        Task<MusicaResponseDto> BuscarPorCriterio(Expression<Func<MusicaRequestDto, bool>> expression);
        Task<IEnumerable<MusicaAlbumQueryAnonima>> BuscarTodosPorCriterio(Expression<Func<Musica, bool>> expression);
        //Task<IEnumerable<MusicaResponseDto>> BuscarTodosPorCriterio(Expression<Func<MusicaRequestDto, bool>> expression);
        Task Exluir(MusicaRequestDto entity);
        Task<MusicaResponseDto> ObterPorId(object id);
        Task<IEnumerable<MusicaResponseDto>> ObterTodos();
        Task Salvar(MusicaRequestDto request);
    }
}