using System.Linq.Expressions;

namespace AVS.Core.Services
{
    public interface IAppService<T> where T : class
    {
        Task Salvar(T entity);
        Task Atualizar(T entity);
        Task Exluir(T entity);
        Task<T> ObterPorId(object id);
        Task<IEnumerable<T>> ObterTodos();
        Task<IEnumerable<T>> BuscarTodosPorCriterio(Expression<Func<T, bool>> expression);
        Task<T> BuscarPorCriterio(Expression<Func<T, bool>> expression);
    }
}
