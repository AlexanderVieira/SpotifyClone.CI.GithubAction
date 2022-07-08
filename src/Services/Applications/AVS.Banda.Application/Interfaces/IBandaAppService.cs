using AVS.Banda.Application.DTOs;
using System.Linq.Expressions;

namespace AVS.Banda.Application.Interfaces
{
    public interface IBandaAppService
    {
        Task<IEnumerable<BandaResponseDto>> ObterTodos();
        Task<BandaResponseDto> BuscarPorCriterio(Expression<Func<Domain.Entities.Banda, bool>> expression);
        Task<IEnumerable<BandaResponseDto>> BuscarTodosPorCriterio(Expression<Func<Domain.Entities.Banda, bool>> expression);
        Task<BandaResponseDto> ObterPorId(object id);
        Task Salvar(BandaRequestDto request);
        Task Atualizar(BandaRequestDto request);
        Task Exluir(BandaRequestDto request);
    }
}