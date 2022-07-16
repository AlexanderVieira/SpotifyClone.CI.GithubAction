using AutoMapper;
using AVS.Cadastro.Application.DTOs;
using AVS.Cadastro.Application.Interfaces;
using AVS.Cadastro.Domain.Entities;
using AVS.Cadastro.Domain.Interfaces.Services;
using AVS.Core.ObjDoinio;

namespace AVS.Cadastro.Application.AppServices
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioAppService(IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UsuarioResponseDto>> ObterTodos()
        {
            var usuarios = await _usuarioService.ObterTodos();            
            if (usuarios == null) return null;
            var response = _mapper.Map<IEnumerable<UsuarioResponseDto>>(usuarios);
            return response;            
        }

        public async Task<IEnumerable<UsuarioResponseDto>> ObterTodosAtivos()
        {
            var usuarios = await _usuarioService.ObterTodosAtivos();            
            if (usuarios == null) return null;
            var response = _mapper.Map<IEnumerable<UsuarioResponseDto>>(usuarios);
            return response;
        }

        public async Task<UsuarioResponseDto> ObterPorId(object id)
        {
            var usuario = await _usuarioService.ObterPorId(id);            
            if (usuario == null) return null;
            var response = _mapper.Map<UsuarioResponseDto>(usuario);
            return response;
        }

        public async Task Salvar(UsuarioRequestDto request)
        {
            var usuario = _mapper.Map<Usuario>(request);
            usuario.Validar();
            await _usuarioService.Salvar(usuario);
        }

        public async Task Atualizar(UsuarioRequestDto request)
        {
            var usuario = _mapper.Map<Usuario>(request);
            usuario.Validar();
            await _usuarioService.Atualizar(usuario);
        }

        public async Task Ativar(UsuarioRequestDto request)
        {
            var usuario = _mapper.Map<Usuario>(request);
            usuario.Validar();
            await _usuarioService.Ativar(usuario);
        }

        public async Task Inativar(UsuarioRequestDto request)
        {
            var usuario = _mapper.Map<Usuario>(request);
            usuario.Validar();
            await _usuarioService.Inativar(usuario);
        }

        public async Task Exluir(UsuarioRequestDto request)
        {
            Validacao.ValidarSeNulo(request, "Opa! Ocorreu um erro.");
            var usuario = _mapper.Map<Usuario>(request);
            usuario.Validar();
            await _usuarioService.Exluir(usuario);
        }
    }
}
