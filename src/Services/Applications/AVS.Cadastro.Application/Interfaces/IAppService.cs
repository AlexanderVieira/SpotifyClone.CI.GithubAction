using AVS.Core.ObjDoinio;

namespace AVS.Cadastro.Application.Interfaces
{
    public interface IAppService<T> where T : class
    {
        Task<IEnumerable<T>> ObterTodos();
        Task<T> ObterPorId(Guid id);
        void Adicionar(T TEntity);
        void Atualizar(T TEntity);
        void Remover(T TEntity);
    }
}
