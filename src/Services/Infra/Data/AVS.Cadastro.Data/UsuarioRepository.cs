using AVS.Cadastro.Domain.Entities;
using AVS.Cadastro.Domain.Interfaces.Repositories;
using AVS.Core.Data;

namespace AVS.Cadastro.Data
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public void Adicionar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
