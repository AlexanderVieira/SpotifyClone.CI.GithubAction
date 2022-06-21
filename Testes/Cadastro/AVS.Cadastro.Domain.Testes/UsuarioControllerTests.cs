using AVS.Cadastro.Application.DTOs;
using AVS.Cadastro.Application.Interfaces;
using AVS.Documentacao.API.Controllers;
using Moq;
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
        [Trait("Categoria", "Usuarios Controller Mock Tests")]
        public async Task UsuariosController_Adicionar_DeveExecutarComSucesso()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var usuarioAppService = new Mock<IUsuarioAppService>();
            var usuarioController = new UsuariosController(usuarioAppService.Object);
            var usuarioDTO = UsuarioDTO.ConverterParaUsuarioDTO(usuario);

            //Act
            await usuarioController.AdicionarUsuario(usuarioDTO);

            //Asset
            Assert.True(usuarioDTO.EhValido());
            usuarioAppService.Verify(r => r.Salvar(usuarioDTO), Times.Once());
        }

        [Fact(DisplayName = "Atualizar Usuario com Sucesso")]
        [Trait("Categoria", "Usuario Controller Mock Tests")]
        public async Task UsuariosController_Atualizar_DeveExecutarComSucesso()
        {            
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var usuarioAppService = new Mock<IUsuarioAppService>();
            var usuarioController = new UsuariosController(usuarioAppService.Object);
            var usuarioDTO = UsuarioDTO.ConverterParaUsuarioDTO(usuario);

            //Act
            await usuarioController.AtualizarUsuario(usuarioDTO);

            //Asset
            Assert.True(usuarioDTO.EhValido());
            usuarioAppService.Verify(r => r.Atualizar(usuarioDTO), Times.Once());
        }

        [Fact(DisplayName = "Remover Usuario com Sucesso")]
        [Trait("Categoria", "Usuario Controller Mock Tests")]
        public async Task UsuariosController_Remover_DeveExecutarComSucesso()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var usuarioAppService = new Mock<IUsuarioAppService>();
            var usuarioController = new UsuariosController(usuarioAppService.Object);
            var usuarioDTO = UsuarioDTO.ConverterParaUsuarioDTO(usuario);

            //Act
            await usuarioController.ExcluirUsuario(usuarioDTO);

            //Asset
            Assert.True(usuarioDTO.EhValido());
            usuarioAppService.Verify(r => r.Exluir(usuarioDTO), Times.Once());
        }

        [Fact(DisplayName = "Obter todos Usuarios com Sucesso")]
        [Trait("Categoria", "Usuario Controller Mock Tests")]
        public async Task UsuariosController_ObterTodos_DeveExecutarComSucesso()
        {
            //Arrange            
            var usuarioAppService = new Mock<IUsuarioAppService>();
            var usuarioController = new UsuariosController(usuarioAppService.Object);            

            //Act
            await usuarioController.ObterTodosUsuarios();
            
            //Asset            
            usuarioAppService.Verify(r => r.ObterTodos(), Times.Once());
        }

        [Fact(DisplayName = "Obter todos Usuarios Ativos com Sucesso")]
        [Trait("Categoria", "Usuario Controller Mock Tests")]
        public async Task UsuariosController_ObterTodosAtivos_DeveExecutarComSucesso()
        {
            //Arrange            
            var usuarioAppService = new Mock<IUsuarioAppService>();
            var usuarioController = new UsuariosController(usuarioAppService.Object);            

            //Act
            await usuarioController.ObterTodosUsuariosAtivos();

            //Asset            
            usuarioAppService.Verify(r => r.ObterTodosAtivos(), Times.Once());
        }

        [Fact(DisplayName = "Obter Usuario por ID com Sucesso")]
        [Trait("Categoria", "Usuario Controller Mock Tests")]
        public async Task UsuariosController_ObterPorId_DeveExecutarComSucesso()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var usuarioAppService = new Mock<IUsuarioAppService>();
            var usuarioController = new UsuariosController(usuarioAppService.Object);
            var usuarioDTO = UsuarioDTO.ConverterParaUsuarioDTO(usuario);

            //Act
            await usuarioController.ObterUsuarioPorId(usuarioDTO.Id);

            //Asset
            Assert.True(usuarioDTO.EhValido());
            usuarioAppService.Verify(r => r.ObterPorId(usuarioDTO.Id), Times.Once());
        }

        [Fact(DisplayName = "Ativar Usuario com Sucesso")]
        [Trait("Categoria", "Usuario Controller Mock Tests")]
        public async Task UsuariosController_Ativar_DeveExecutarComSucesso()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var usuarioAppService = new Mock<IUsuarioAppService>();
            var usuarioController = new UsuariosController(usuarioAppService.Object);
            var usuarioDTO = UsuarioDTO.ConverterParaUsuarioDTO(usuario);

            //Act
            await usuarioController.AtivarUsuario(usuarioDTO);

            //Asset
            Assert.True(usuarioDTO.EhValido());
            usuarioAppService.Verify(r => r.Ativar(usuarioDTO), Times.Once());
        }

        [Fact(DisplayName = "Inativar Usuario com Sucesso")]
        [Trait("Categoria", "Usuario Controller Mock Tests")]
        public async Task UsuariosController_Inativar_DeveExecutarComSucesso()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var usuarioAppService = new Mock<IUsuarioAppService>();
            var usuarioController = new UsuariosController(usuarioAppService.Object);
            var usuarioDTO = UsuarioDTO.ConverterParaUsuarioDTO(usuario);

            //Act
            await usuarioController.InativarUsuario(usuarioDTO);

            //Asset
            Assert.True(usuarioDTO.EhValido());
            usuarioAppService.Verify(r => r.Inativar(usuarioDTO), Times.Once());
        }
    }
        
}
