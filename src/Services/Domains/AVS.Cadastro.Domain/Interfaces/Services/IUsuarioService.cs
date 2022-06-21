using AVS.Cadastro.Domain.Entities;
using AVS.Core.Services;

namespace AVS.Cadastro.Domain.Interfaces.Services
{
    public interface IUsuarioService : IAppService<Usuario>
    {        
        Task<IEnumerable<Usuario>> ObterTodosAtivos();
        Task Ativar(Usuario usuario);
        Task Inativar(Usuario usuario);        
    }
}
