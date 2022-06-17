﻿using AVS.Core.ObjDoinio;

namespace AVS.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
        Task<IEnumerable<T>> ObterTodos();
        Task<T> ObterPorId(Guid id);
        void Adicionar(T TEntity);        
        void Atualizar(T TEntity);
        void Remover(T TEntity);
    }
}
