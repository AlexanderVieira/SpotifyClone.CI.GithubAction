using AutoMapper;
using AVS.Banda.Application.DTOs;
using AVS.Banda.Application.Interfaces;
using AVS.Banda.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace AVS.Banda.Application.AppServices
{
    public class BandaAppService : IBandaAppService
    {
        private readonly IBandaService _bandaService;
        private readonly IMapper _mapper;

        public BandaAppService(IBandaService bandaService, IMapper mapper)
        {
            _bandaService = bandaService;
            _mapper = mapper;
        }
                
        public async Task<BandaResponseDto> BuscarPorCriterio(Expression<Func<Domain.Entities.Banda, bool>> expression)
        {
            var banda = await _bandaService.BuscarPorCriterio(expression);
            if (banda == null) return null;            
            var response = _mapper.Map<BandaResponseDto>(banda);
            return response;
        }
        
        public async Task<IEnumerable<BandaResponseDto>> BuscarTodosPorCriterio(Expression<Func<Domain.Entities.Banda, bool>> expression)
        {
            var bandas = await _bandaService.BuscarTodosPorCriterio(expression);
            if (bandas == null) return null;
            var response = _mapper.Map<IList<BandaResponseDto>>(bandas);
            return response;            
        }

        public async Task<IEnumerable<BandaResponseDto>> ObterTodos()
        {
            var bandas = await _bandaService.ObterTodos();            
            if (bandas == null) return null;
            var response = _mapper.Map<IList<BandaResponseDto>>(bandas);
            return response;
        }

        public async Task<BandaResponseDto> ObterPorId(object id)
        {
            var banda = await _bandaService.ObterPorId(id);            
            if (banda == null) return null;
            var response = _mapper.Map<BandaResponseDto>(banda);
            return response;
        }

        public async Task Salvar(BandaRequestDto request)
        {
            var banda = _mapper.Map<Domain.Entities.Banda>(request);
            banda.Validar();
            await _bandaService.Salvar(banda);
        }

        public async Task Atualizar(BandaRequestDto request)
        {
            var banda = _mapper.Map<Domain.Entities.Banda>(request);
            banda.Validar();
            await _bandaService.Atualizar(banda);
        }

        public async Task Exluir(BandaRequestDto request)
        {
            var banda = _mapper.Map<Domain.Entities.Banda>(request);
            banda.Validar();
            await _bandaService.Exluir(banda);
        }       
    }

    public static class LambdaExpressionExtensions
    {
        public static Expression<Func<Domain.Entities.Banda, bool>> ToUntypedPropertyExpression<TInput, TOutput>(this Expression<Func<TInput, TOutput>> expression)
        {
            //var memberName = ((MemberExpression)expression.Body).Member.Name;

            var param = Expression.Parameter(typeof(Domain.Entities.Banda));
            //var field = Expression.Property(param, memberName);
            return Expression.Lambda<Func<Domain.Entities.Banda, bool>>(expression.Body, param);
        }
    }
}
