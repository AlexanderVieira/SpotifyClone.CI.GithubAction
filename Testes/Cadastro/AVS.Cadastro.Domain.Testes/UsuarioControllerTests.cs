using AVS.Banda.Application.DTOs;
using AVS.Cadastro.Application.Commands;
using AVS.Cadastro.Application.DTOs;
using AVS.Cadastro.Application.Interfaces;
using AVS.Cadastro.Application.Queries;
using AVS.Core.Comunicacao.Mediator;
using AVS.Documentacao.API.Controllers;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AVS.Cadastro.Domain.Testes
{
    [Collection(nameof(UsuarioCollection))]
    public class UsuarioControllerTests
    {
        private readonly UsuarioTestsFixture _usuarioTestsFixture;

        public UsuarioControllerTests(UsuarioTestsFixture usuarioTestsFixture)
        {
            _usuarioTestsFixture = usuarioTestsFixture;
        }

        [Fact(DisplayName = "Adicionar Usuario com Sucesso")]
        [Trait("Categoria", "Usuario Controller Mock Tests")]
        public async Task UsuariosController_Adicionar_DeveExecutarComSucesso()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            //var usuarioAppService = new Mock<IUsuarioAppService>();
            var mediatorHandler = new Mock<IMediatorHandler>();
            var usuarioController = new UsuariosController(mediatorHandler.Object);
            mediatorHandler.Setup(x => x.EnviarComando(It.IsAny<AdicionarUsuarioCommand>()))
                                        .Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));            

            //Act
            await usuarioController.AdicionarUsuario(new UsuarioRequestDto(usuario.Id,
                                                                           usuario.Nome,
                                                                           usuario.Email.Address,
                                                                           usuario.Cpf.Numero,
                                                                           usuario.Ativo,
                                                                           usuario.Foto));

            //Asset            
            mediatorHandler.Verify(r => r.EnviarComando(It.IsAny<AdicionarUsuarioCommand>()), Times.Once());
        }

        [Fact(DisplayName = "Atualizar Usuario com Sucesso")]
        [Trait("Categoria", "Usuario Controller Mock Tests")]
        public async Task UsuariosController_Atualizar_DeveExecutarComSucesso()
        {            
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            //var usuarioAppService = new Mock<IUsuarioAppService>();
            var mediatorHandler = new Mock<IMediatorHandler>();
            var usuarioController = new UsuariosController(mediatorHandler.Object);
            mediatorHandler.Setup(x => x.EnviarComando(It.IsAny<AtualizarUsuarioCommand>()))
                                        .Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));            

            //Act
            await usuarioController.AtualizarUsuario(new UsuarioRequestDto(usuario.Id,
                                                                           usuario.Nome,
                                                                           usuario.Email.Address,
                                                                           usuario.Cpf.Numero,
                                                                           usuario.Ativo,
                                                                           usuario.Foto));

            //Asset            
            mediatorHandler.Verify(r => r.EnviarComando(It.IsAny<AtualizarUsuarioCommand>()), Times.Once());
        }

        [Fact(DisplayName = "Remover Usuario com Sucesso")]
        [Trait("Categoria", "Usuario Controller Mock Tests")]
        public async Task UsuariosController_Remover_DeveExecutarComSucesso()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            //var usuarioAppService = new Mock<IUsuarioAppService>();
            var mediatorHandler = new Mock<IMediatorHandler>();
            var usuarioController = new UsuariosController(mediatorHandler.Object);
            mediatorHandler.Setup(x => x.EnviarComando(It.IsAny<ExcluirUsuarioCommand>()))
                                        .Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));

            //Act
            await usuarioController.ExcluirUsuario(new UsuarioRequestDto(usuario.Id,
                                                                         usuario.Nome, 
                                                                         usuario.Email.Address, 
                                                                         usuario.Cpf.Numero, 
                                                                         usuario.Ativo, 
                                                                         usuario.Foto));

            //Asset            
            mediatorHandler.Verify(r => r.EnviarComando(It.IsAny<ExcluirUsuarioCommand>()), Times.Once());
        }

        [Fact(DisplayName = "Obter todos Usuarios com Sucesso")]
        [Trait("Categoria", "Usuario Controller Mock Tests")]
        public async Task UsuariosController_ObterTodos_DeveExecutarComSucesso()
        {
            //Arrange            
            //var usuarioAppService = new Mock<IUsuarioAppService>();
            var mediatorHandler = new Mock<IMediatorHandler>();
            var usuarioController = new UsuariosController(mediatorHandler.Object);
            var usuariosResponse = new ObterTodosUsuariosQueryResponse(new List<UsuarioResponseDto>());
            mediatorHandler.Setup(x => x.EnviarQuery(It.IsAny<ObterTodosUsuariosQuery>()))
                                        .Returns(Task.FromResult((object)usuariosResponse));

            //Act
            await usuarioController.ObterTodosUsuarios();

            //Asset
            mediatorHandler.Verify(x => x.EnviarQuery(It.IsAny<ObterTodosUsuariosQuery>()), Times.Once());            
        }

        [Fact(DisplayName = "Obter todos Usuarios Ativos com Sucesso")]
        [Trait("Categoria", "Usuario Controller Mock Tests")]
        public async Task UsuariosController_ObterTodosAtivos_DeveExecutarComSucesso()
        {
            //Arrange            
            //var usuarioAppService = new Mock<IUsuarioAppService>();
            var mediatorHandler = new Mock<IMediatorHandler>();
            var usuarioController = new UsuariosController(mediatorHandler.Object);
            var usuariosResponse = new ObterTodosUsuariosQueryResponse(new List<UsuarioResponseDto>());
            mediatorHandler.Setup(x => x.EnviarQuery(It.IsAny<ObterTodosUsuariosAtivosQuery>()))
                                        .Returns(Task.FromResult((object)usuariosResponse));

            //Act
            await usuarioController.ObterTodosUsuariosAtivos();

            //Asset            
            mediatorHandler.Verify(x => x.EnviarQuery(It.IsAny<ObterTodosUsuariosAtivosQuery>()), Times.Once());
        }

        [Fact(DisplayName = "Obter Usuario por ID com Sucesso")]
        [Trait("Categoria", "Usuario Controller Mock Tests")]
        public async Task UsuariosController_ObterPorId_DeveExecutarComSucesso()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            //var usuarioAppService = new Mock<IUsuarioAppService>();
            var mediatorHandler = new Mock<IMediatorHandler>();
            var usuarioController = new UsuariosController(mediatorHandler.Object);
            var usuarioResponseDto = new UsuarioResponseDto(usuario.Id, 
                                                            usuario.Nome, 
                                                            usuario.Email.Address, 
                                                            usuario.Cpf.Numero, 
                                                            usuario.Ativo, 
                                                            usuario.Foto, 
                                                            new List<PlaylistResponseDto>());
            var usuariosDetalheResponse = new ObterDetalheUsuarioQueryResponse(usuarioResponseDto);
            mediatorHandler.Setup(x => x.EnviarQuery(It.IsAny<ObterDetalheUsuarioQuery>()))
                                        .Returns(Task.FromResult((object)usuariosDetalheResponse));
            //var usuarioDTO = UsuarioDTO.ConverterParaUsuarioDTO(usuario);

            //Act
            await usuarioController.ObterUsuarioPorId(usuarioResponseDto.Id);

            //Asset
            //Assert.True(usuarioDTO.EhValido());
            //usuarioAppService.Verify(r => r.ObterPorId(usuarioDTO.Id), Times.Once());
            mediatorHandler.Verify(x => x.EnviarQuery(It.IsAny<ObterDetalheUsuarioQuery>()), Times.Once());
        }

        [Fact(DisplayName = "Ativar Usuario com Sucesso")]
        [Trait("Categoria", "Usuario Controller Mock Tests")]
        public async Task UsuariosController_Ativar_DeveExecutarComSucesso()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            //var usuarioAppService = new Mock<IUsuarioAppService>();
            var mediatorHandler = new Mock<IMediatorHandler>();
            var usuarioController = new UsuariosController(mediatorHandler.Object);
            mediatorHandler.Setup(x => x.EnviarComando(It.IsAny<AtivarUsuarioCommand>()))
                                        .Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));            

            //Act
            await usuarioController.AtivarUsuario(new UsuarioRequestDto(usuario.Id,
                                                                        usuario.Nome,
                                                                        usuario.Email.Address,
                                                                        usuario.Cpf.Numero,
                                                                        usuario.Ativo,
                                                                        usuario.Foto));

            //Asset            
            mediatorHandler.Verify(r => r.EnviarComando(It.IsAny<AtivarUsuarioCommand>()), Times.Once());
        }

        [Fact(DisplayName = "Inativar Usuario com Sucesso")]
        [Trait("Categoria", "Usuario Controller Mock Tests")]
        public async Task UsuariosController_Inativar_DeveExecutarComSucesso()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            //var usuarioAppService = new Mock<IUsuarioAppService>();
            var mediatorHandler = new Mock<IMediatorHandler>();
            var usuarioController = new UsuariosController(mediatorHandler.Object);
            mediatorHandler.Setup(x => x.EnviarComando(It.IsAny<InativarUsuarioCommand>()))
                                        .Returns(Task.FromResult(new FluentValidation.Results.ValidationResult()));            

            //Act
            await usuarioController.InativarUsuario(new UsuarioRequestDto(usuario.Id,
                                                                          usuario.Nome,
                                                                          usuario.Email.Address,
                                                                          usuario.Cpf.Numero,
                                                                          usuario.Ativo,
                                                                          usuario.Foto));

            //Asset            
            mediatorHandler.Verify(r => r.EnviarComando(It.IsAny<InativarUsuarioCommand>()), Times.Once());
        }
    }
        
}
