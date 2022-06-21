using AVS.Core.Data;
using System.Linq.Expressions;

namespace AVS.Core.Services
{
    public class GenericService<T> : IAppService<T> where T : class
    {
        protected readonly IRepository<T> _repo;

        public GenericService(IRepository<T> repo)
        {
            _repo = repo;
        }

        public async Task<T> BuscarPorCriterio(Expression<Func<T, bool>> expression)
        {
            return await _repo.BuscarPorCriterio(expression);
        }

        public async Task<IEnumerable<T>> BuscarTodosPorCriterio(Expression<Func<T, bool>> expression)
        {
            return await _repo.BuscarTodosPorCriterio(expression);
        }
        
        public async Task<IEnumerable<T>> ObterTodos()
        {
            return await _repo.ObterTodos();
        }

        public async Task<T> ObterPorId(object id)
        {
            return await _repo.ObterPorId(id);
        }

        public async Task Salvar(T entity)
        {
            await _repo.Salvar(entity);
        }

        public async Task Atualizar(T entity)
        {
            await _repo.Atualizar(entity);
        }

        public async Task Exluir(T entity)
        {
            await _repo.Exluir(entity);
        }

        public void Dispose()
        {            
            _repo.Dispose();
        }
    }
}
