using AVS.Core.Data;
using AVS.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using System.Linq.Expressions;

namespace AVS.Infra.CrossCutting
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        //private readonly UsuarioContext _context;
        public IUnitOfWork UnitOfWork => (IUnitOfWork)Context;
        protected DbSet<T> Query { get; set; }
        protected DbContext Context { get; set; }

        public GenericRepository(SpotifyCloneContext context)
        {
            Context = context;
            Query = Context.Set<T>();
        }

        public async Task<IEnumerable<T>> ObterTodos()
        {
            return await Query
                            .AsNoTrackingWithIdentityResolution()
                            .ToListAsync();
        }

        public async Task<IEnumerable<T>> BuscarTodosPorCriterio(Expression<Func<T, bool>> expression)
        {
            return await Query
                             .AsNoTrackingWithIdentityResolution()
                             .Where(expression)
                             .ToListAsync();
        }

        public async Task<T> BuscarPorCriterio(Expression<Func<T, bool>> expression)
        {
            return await Query
                             .AsNoTrackingWithIdentityResolution()
                             .FirstOrDefaultAsync(expression);
        }

        public async Task<T> ObterPorId(object id)
        {
            return await Query.FindAsync(id);
        }

        public async Task Salvar(T entity)
        {
            await Query.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Atualizar(T entity)
        {
            Query.Update(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Exluir(T entity)
        {
            Query.Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> CriarTransacao()
        {
            return await Context.Database.BeginTransactionAsync();
        }

        public async Task<IDbContextTransaction> CriarTransacao(IsolationLevel isolation)
        {
            return await Context.Database.BeginTransactionAsync(isolation);
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
