using AVS.Cadastro.Application.DTOs;

namespace AVS.Cadastro.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        Task Ativar(UsuarioRequestDto request);
        Task Atualizar(UsuarioRequestDto request);
        Task Exluir(UsuarioRequestDto request);
        Task Inativar(UsuarioRequestDto request);
        Task<UsuarioResponseDto> ObterPorId(object id);
        Task<IEnumerable<UsuarioResponseDto>> ObterTodos();
        Task<IEnumerable<UsuarioResponseDto>> ObterTodosAtivos();
        Task Salvar(UsuarioRequestDto request);
    }
}