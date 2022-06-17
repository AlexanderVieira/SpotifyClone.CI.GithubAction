using AVS.Core.ObjDoinio;

namespace AVS.Cadastro.Domain.Interfaces.Services
{
    public interface IService<T> where T : IAggregateRoot
    {
        Task<IEnumerable<T>> ObterTodos();
        Task<T> ObterPorId(Guid id);
        void Adicionar(T TEntity);
        void Atualizar(T TEntity);
        void Remover(T TEntity);
    }
}
