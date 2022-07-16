using AVS.Core.ObjDoinio;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Linq.Expressions;

namespace AVS.Core.Data
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IUnitOfWork UnitOfWork { get; }        
        Task Salvar(T entity);
        Task Exluir(T entity);
        Task Atualizar(T entity);
        Task<T> ObterPorId(object id);
        Task<IEnumerable<T>> ObterTodos();
        Task<IEnumerable<T>> BuscarTodosPorCriterio(Expression<Func<T, bool>> expression);
        Task<T> BuscarPorCriterio(Expression<Func<T, bool>> expression);
        Task<IDbContextTransaction> CriarTransacao();
        Task<IDbContextTransaction> CriarTransacao(IsolationLevel isolation);
    }
}
