using AVS.Cadastro.Application.DTOs;

namespace AVS.Cadastro.Application.Interfaces
{
    public interface IUsuarioAppService : IAppService<UsuarioDTO>
    {
        Task<IEnumerable<UsuarioDTO>> ObterTodosAtivos();
        void Ativar(UsuarioDTO usuario);
        void Inativar(UsuarioDTO usuario);
    }
}
