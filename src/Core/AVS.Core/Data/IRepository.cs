using AVS.Core.ObjDoinio;

namespace AVS.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
        void Adicionar(T obj);
    }
}
