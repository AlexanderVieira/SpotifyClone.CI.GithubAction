using AVS.Banda.Domain.AppServices.DTOs;
using AVS.Banda.Domain.Interfaces.AppServices;
using AVS.Banda.Domain.Interfaces.Services;
using AVS.Core.ObjDoinio;
using System.Linq.Expressions;

namespace AVS.Banda.Domain.AppServices
{
    public class BandaAppService : IBandaAppService
    {
        private readonly IBandaService _bandaService;

        public BandaAppService(IBandaService bandaService)
        {
            _bandaService = bandaService;
        }

        public Task<BandaDTO> BuscarPorCriterio(Expression<Func<BandaDTO, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<BandaDTO> BuscarPorCriterio(Expression<Func<Entities.Banda, bool>> expression)
        {
            var banda = await _bandaService.BuscarPorCriterio(expression);            
            if (banda == null) return null;
            var bandaDTO = BandaDTO.ConverterParaBandaDTO(banda);
            return bandaDTO;
        }
        
        public async Task<IEnumerable<BandaDTO>> BuscarTodosPorCriterio(Expression<Func<BandaDTO, bool>> expression)
        {
            //var domainExpression = Expression.Lambda<Func<Entities.Banda, bool>>(expression, expression.Parameters);

            //Expression<Func<MyClass, object>> e1 = t => t.MyProperty;
            //var p = Expression.Parameter(typeof(Entities.Banda));
            //var e2 = Expression.Lambda<Func<Entities.Banda, bool>>(
            //    Expression.Invoke(expression, Expression.Convert(p,typeof(Entities.Banda))),p);

            var domainExpression = expression.ToUntypedPropertyExpression();

            //var x = Cast<Entities.Banda, bool, string>(expression);

            var bandas = await _bandaService.BuscarTodosPorCriterio(domainExpression);
            if (bandas == null) return null;
            return bandas.Select(BandaDTO.ConverterParaBandaDTO);            
        }

        public async Task<IEnumerable<BandaDTO>> BuscarTodosPorCriterio(Expression<Func<Entities.Banda, bool>> expression)
        {
            var bandas = await _bandaService.BuscarTodosPorCriterio(expression);
            if (bandas == null) return null;
            return bandas.Select(BandaDTO.ConverterParaBandaDTO);
        }

        public async Task<IEnumerable<BandaDTO>> ObterTodos()
        {
            var bandas = await _bandaService.ObterTodos();
            //Validacao.ValidarSeNulo(bandas.Cast<object>().ToList(), "Não existem dados para exibição.");
            if (bandas == null) return null;
            IEnumerable<BandaDTO> bandaDTOs = new List<BandaDTO>();
            foreach (var banda in bandas)
            {
                var bandaDTO = BandaDTO.ConverterParaBandaDTO(banda);
                bandaDTOs = bandaDTOs.Append(bandaDTO);
            }
            return bandaDTOs;
        }

        public async Task<BandaDTO> ObterPorId(object id)
        {
            var banda = await _bandaService.ObterPorId(id);
            //Validacao.ValidarSeNulo(banda, "Banda não encontrada.");
            if (banda == null) return null;
            var bandaDTO = BandaDTO.ConverterParaBandaDTO(banda);
            return bandaDTO;
        }

        public async Task Salvar(BandaDTO entity)
        {
            var banda = BandaDTO.ConverterParaBanda(entity);
            banda.Validar();
            await _bandaService.Salvar(banda);
        }

        public async Task Atualizar(BandaDTO entity)
        {
            var banda = BandaDTO.ConverterParaBanda(entity);
            banda.Validar();
            await _bandaService.Atualizar(banda);
        }
        
        public async Task Exluir(BandaDTO entity)
        {
            var banda = BandaDTO.ConverterParaBanda(entity);
            banda.Validar();
            await _bandaService.Exluir(banda);
        }

        //public static Expression<Func<TModel, TToProperty>> Cast<TModel, TFromProperty, TToProperty>(Expression<Func<TModel, TFromProperty>> expression)
        //{
        //    Expression converted = Expression.Convert(expression.Body, typeof(TToProperty));

        //    return Expression.Lambda<Func<TModel, TToProperty>>(converted, expression.Parameters);
        //}

        //private static Expression<Func<T, bool>> FuncToExpression<T, TE>(Func<T, bool> f, Func<TE, bool> fu) where T : Entities.Banda where TE : BandaDTO
        //{
        //    return x => fu(x.);
        //}
    }

    public static class LambdaExpressionExtensions
    {
        public static Expression<Func<Entities.Banda, bool>> ToUntypedPropertyExpression<TInput, TOutput>(this Expression<Func<TInput, TOutput>> expression)
        {
            //var memberName = ((MemberExpression)expression.Body).Member.Name;

            var param = Expression.Parameter(typeof(Entities.Banda));
            //var field = Expression.Property(param, memberName);
            return Expression.Lambda<Func<Entities.Banda, bool>>(expression.Body, param);
        }
    }
}
