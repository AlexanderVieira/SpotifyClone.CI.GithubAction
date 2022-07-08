using AVS.Banda.Application.DTOs;
using System.Linq.Expressions;

namespace AVS.Banda.Application.Interfaces
{
    public interface IBandaAppService
    {
        Task Atualizar(BandaRequestDto request);
        Task<BandaResponseDto> BuscarPorCriterio(Expression<Func<Domain.Entities.Banda, bool>> expression);
        Task<IEnumerable<BandaResponseDto>> BuscarTodosPorCriterio(Expression<Func<Domain.Entities.Banda, bool>> expression);        
        Task Exluir(BandaRequestDto request);
        Task<BandaResponseDto> ObterPorId(object id);
        Task<IEnumerable<BandaResponseDto>> ObterTodos();
        Task Salvar(BandaRequestDto request);
    }
}