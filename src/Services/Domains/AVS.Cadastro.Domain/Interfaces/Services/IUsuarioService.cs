using AVS.Cadastro.Domain.Entities;

namespace AVS.Cadastro.Domain.Interfaces.Services
{
    public interface IUsuarioService : IService<Usuario>
    {        
        Task<IEnumerable<Usuario>> ObterTodosAtivos();
        void Ativar(Usuario usuario);
        void Inativar(Usuario usuario);
    }
}
