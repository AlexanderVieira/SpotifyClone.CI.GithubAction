using AVS.Cadastro.Application.DTOs;
using AVS.Cadastro.Application.Interfaces;
using AVS.Documentacao.API.Controllers;
using Moq;
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
        public void UsuariosController_Adicionar_DeveExecutarComSucesso()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var usuarioAppService = new Mock<IUsuarioAppService>();
            var usuarioController = new UsuariosController(usuarioAppService.Object);
            var usuarioDTO = UsuarioDTO.ConverteParaUsuarioDTO(usuario);

            //Act
            usuarioController.AdicionarUsuario(usuarioDTO);

            //Asset
            Assert.True(usuarioDTO.EhValido());
            usuarioAppService.Verify(r => r.Adicionar(usuarioDTO), Times.Once());
        }

        //[Fact(DisplayName = "Atualizar Usuario com Sucesso")]
        //[Trait("Categoria", "Usuario AppService Mock Tests")]
        //public void UsuarioAppService_Atualizar_DeveExecutarComSucesso()
        //{
        //    //Arrange
        //    var usuario = _usuarioTestsFixture.CriarUsuarioValido();
        //    var usuarioService = new Mock<IUsuarioService>();
        //    var usuarioAppService = new UsuarioAppService(usuarioService.Object);
        //    var usuarioDTO = UsuarioDTO.ConverteParaUsuarioDTO(usuario);

        //    //Act
        //    usuarioAppService.Atualizar(usuarioDTO);

        //    //Asset
        //    Assert.True(usuarioDTO.EhValido());
        //    usuarioService.Verify(r => r.Atualizar(usuario), Times.Once());
        //}

        //[Fact(DisplayName = "Remover Usuario com Sucesso")]
        //[Trait("Categoria", "Usuario AppService Mock Tests")]
        //public void UsuarioAppService_Remover_DeveExecutarComSucesso()
        //{
        //    //Arrange
        //    var usuario = _usuarioTestsFixture.CriarUsuarioValido();
        //    var usuarioService = new Mock<IUsuarioService>();
        //    var usuarioAppService = new UsuarioAppService(usuarioService.Object);
        //    var usuarioDTO = UsuarioDTO.ConverteParaUsuarioDTO(usuario);

        //    //Act
        //    usuarioAppService.Remover(usuarioDTO);

        //    //Asset
        //    Assert.True(usuarioDTO.EhValido());
        //    usuarioService.Verify(r => r.Remover(usuario), Times.Once());
        //}

        //[Fact(DisplayName = "Obter todos Usuarios com Sucesso")]
        //[Trait("Categoria", "Usuario AppService Mock Tests")]
        //public void UsuarioAppService_ObterTodos_DeveExecutarComSucesso()
        //{
        //    //Arrange            
        //    var usuarioService = new Mock<IUsuarioService>();
        //    usuarioService.Setup(r => r.ObterTodos()).Returns(_usuarioTestsFixture.ObterUsuarios());
        //    var usuarioAppService = new UsuarioAppService(usuarioService.Object);

        //    //Act
        //    var usuarioDTOs = usuarioAppService.ObterTodos();

        //    //Asset
        //    Assert.NotNull(usuarioDTOs.Result.Any());
        //    usuarioService.Verify(r => r.ObterTodos(), Times.Once());
        //}

        //[Fact(DisplayName = "Obter todos Usuarios Ativos com Sucesso")]
        //[Trait("Categoria", "Usuario AppService Mock Tests")]
        //public void UsuarioAppService_ObterTodosAtivos_DeveExecutarComSucesso()
        //{
        //    //Arrange            
        //    var usuarioService = new Mock<IUsuarioService>();
        //    usuarioService.Setup(r => r.ObterTodosAtivos()).Returns(_usuarioTestsFixture.ObterUsuariosAtivos());
        //    var usuarioAppService = new UsuarioAppService(usuarioService.Object);

        //    //Act
        //    var usuarioDTOs = usuarioAppService.ObterTodosAtivos();

        //    //Asset
        //    usuarioService.Verify(r => r.ObterTodosAtivos(), Times.Once());
        //    Assert.NotNull(usuarioDTOs.Result.Any());
        //    Assert.False(usuarioDTOs.Result.Count(u => !u.Ativo) > 0);
        //}

        //[Fact(DisplayName = "Obter Usuario por ID com Sucesso")]
        //[Trait("Categoria", "Usuario AppService Mock Tests")]
        //public void UsuarioAppService_ObterPorId_DeveExecutarComSucesso()
        //{
        //    //Arrange            
        //    var usuario = _usuarioTestsFixture.CriarUsuarioValido();
        //    var usuarioService = new Mock<IUsuarioService>();
        //    usuarioService.Setup(r => r.ObterPorId(usuario.Id).Result).Returns(usuario);
        //    var UsuarioAppService = new UsuarioAppService(usuarioService.Object);

        //    //Act
        //    var usuarioAtual = UsuarioAppService.ObterPorId(usuario.Id);

        //    //Asset
        //    usuarioService.Verify(r => r.ObterPorId(usuario.Id), Times.Once());
        //    Assert.Equal(usuario.Id, usuarioAtual.Result.Id);
        //}

        //[Fact(DisplayName = "Ativar Usuario com Sucesso")]
        //[Trait("Categoria", "Usuario AppService Mock Tests")]
        //public void UsuarioAppService_Ativar_DeveExecutarComSucesso()
        //{
        //    //Arrange            
        //    var usuario = _usuarioTestsFixture.CriarUsuarioValido();
        //    var usuarioService = new Mock<IUsuarioService>();
        //    var usuarioAppService = new UsuarioAppService(usuarioService.Object);
        //    var usuarioDTO = UsuarioDTO.ConverteParaUsuarioDTO(usuario);

        //    //Act
        //    usuarioAppService.Ativar(usuarioDTO);

        //    //Asset
        //    usuarioService.Verify(r => r.Ativar(usuario), Times.Once());
        //}

        //[Fact(DisplayName = "Inativar Usuario com Sucesso")]
        //[Trait("Categoria", "Usuario AppService Mock Tests")]
        //public void UsuarioAppService_Inativar_DeveExecutarComSucesso()
        //{
        //    //Arrange            
        //    var usuario = _usuarioTestsFixture.CriarUsuarioValido();
        //    var usuarioService = new Mock<IUsuarioService>();
        //    var usuarioAppService = new UsuarioAppService(usuarioService.Object);
        //    var usuarioDTO = UsuarioDTO.ConverteParaUsuarioDTO(usuario);

        //    //Act
        //    usuarioAppService.Inativar(usuarioDTO);

        //    //Asset
        //    usuarioService.Verify(r => r.Inativar(usuario), Times.Once());
        //}
    }
        
}
