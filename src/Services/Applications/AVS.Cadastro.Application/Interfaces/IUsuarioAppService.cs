using AVS.Cadastro.Application.DTOs;
using AVS.Core.Services;

namespace AVS.Cadastro.Application.Interfaces
{
    public interface IUsuarioAppService : IAppService<UsuarioDTO>
    {        
        Task<IEnumerable<UsuarioDTO>> ObterTodosAtivos();
        Task Ativar(UsuarioDTO usuario);
        Task Inativar(UsuarioDTO usuario);        
    }
}
