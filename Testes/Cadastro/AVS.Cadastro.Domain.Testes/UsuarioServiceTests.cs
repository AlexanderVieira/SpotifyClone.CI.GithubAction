using AVS.Cadastro.Domain.Interfaces.Repositories;
using AVS.Cadastro.Domain.Services;
using Moq;
using System.Linq;
using Xunit;

namespace AVS.Cadastro.Domain.Testes
{
    [Collection(nameof(UsuarioCollection))]
    public class UsuarioServiceTests
    {
        private readonly UsuarioTestsFixture _usuarioTestsFixture;

        public UsuarioServiceTests(UsuarioTestsFixture usuarioTestsFixture)
        {
            _usuarioTestsFixture = usuarioTestsFixture;
        }

        [Fact(DisplayName = "Adicionar Usuario com Sucesso")]
        [Trait("Categoria", "Usuario Service Mock Tests")]
        public void UsuarioService_Adicionar_DeveExecutarComSucesso()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var usuarioRepo = new Mock<IUsuarioRepository>();
            var usuarioService = new UsuarioService(usuarioRepo.Object);

            //Act
            usuarioService.Adicionar(usuario);

            //Asset
            //Assert.True(usuario.EhValido());
            usuarioRepo.Verify(r => r.Adicionar(usuario), Times.Once());
        }

        [Fact(DisplayName = "Atualizar Usuario com Sucesso")]
        [Trait("Categoria", "Usuario Service Mock Tests")]
        public void UsuarioService_Atualizar_DeveExecutarComSucesso()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var usuarioRepo = new Mock<IUsuarioRepository>();
            var usuarioService = new UsuarioService(usuarioRepo.Object);

            //Act
            usuarioService.Atualizar(usuario);

            //Asset
            //Assert.True(usuario.EhValido());
            usuarioRepo.Verify(r => r.Atualizar(usuario), Times.Once());
        }

        [Fact(DisplayName = "Remover Usuario com Sucesso")]
        [Trait("Categoria", "Usuario Service Mock Tests")]
        public void UsuarioService_Remover_DeveExecutarComSucesso()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var usuarioRepo = new Mock<IUsuarioRepository>();
            var usuarioService = new UsuarioService(usuarioRepo.Object);

            //Act
            usuarioService.Remover(usuario);

            //Asset
            //Assert.True(usuario.EhValido());
            usuarioRepo.Verify(r => r.Remover(usuario), Times.Once());
        }

        [Fact(DisplayName = "Obter todos Usuarios com Sucesso")]
        [Trait("Categoria", "Usuario Service Mock Tests")]
        public void UsuarioService_ObterTodos_DeveExecutarComSucesso()
        {
            //Arrange            
            var usuarioRepo = new Mock<IUsuarioRepository>();
            usuarioRepo.Setup(r => r.ObterTodos()).Returns(_usuarioTestsFixture.ObterUsuarios());
            var usuarioService = new UsuarioService(usuarioRepo.Object);

            //Act
            var usuarios = usuarioService.ObterTodos();
            
            //Asset
            Assert.True(usuarios.Result.Any());
            usuarioRepo.Verify(r => r.ObterTodos(), Times.Once());
        }

        [Fact(DisplayName = "Obter todos Usuarios Ativos com Sucesso")]
        [Trait("Categoria", "Usuario Service Mock Tests")]
        public void UsuarioService_ObterTodosAtivos_DeveExecutarComSucesso()
        {
            //Arrange            
            var usuarioRepo = new Mock<IUsuarioRepository>();
            usuarioRepo.Setup(r => r.ObterTodosAtivos()).Returns(_usuarioTestsFixture.ObterUsuariosAtivos());
            var usuarioService = new UsuarioService(usuarioRepo.Object);

            //Act
            var usuarios = usuarioService.ObterTodosAtivos();         

            //Asset
            usuarioRepo.Verify(r => r.ObterTodosAtivos(), Times.Once());
            Assert.True(usuarios.Result.Any());            
            Assert.False(usuarios.Result.Count(u => !u.Ativo) > 0);            
        }

        [Fact(DisplayName = "Obter Usuario por ID com Sucesso")]
        [Trait("Categoria", "Usuario Service Mock Tests")]
        public void UsuarioService_ObterPorId_DeveExecutarComSucesso()
        {
            //Arrange            
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var usuarioRepo = new Mock<IUsuarioRepository>();
            usuarioRepo.Setup(r => r.ObterPorId(usuario.Id).Result).Returns(usuario);
            var usuarioService = new UsuarioService(usuarioRepo.Object);

            //Act
            var usuarioAtual = usuarioService.ObterPorId(usuario.Id);

            //Asset
            usuarioRepo.Verify(r => r.ObterPorId(usuario.Id), Times.Once());
            Assert.Equal(usuario.Id, usuarioAtual.Result.Id);            
        }

        [Fact(DisplayName = "Ativar Usuario com Sucesso")]
        [Trait("Categoria", "Usuario Service Mock Tests")]
        public void UsuarioService_Ativar_DeveExecutarComSucesso()
        {
            //Arrange            
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var usuarioRepo = new Mock<IUsuarioRepository>();            
            var usuarioService = new UsuarioService(usuarioRepo.Object);

            //Act
            usuarioService.Ativar(usuario);

            //Asset
            usuarioRepo.Verify(r => r.Atualizar(usuario), Times.Once());            
        }
        
        [Fact(DisplayName = "Inativar Usuario com Sucesso")]
        [Trait("Categoria", "Usuario Service Mock Tests")]
        public void UsuarioService_Inativar_DeveExecutarComSucesso()
        {
            //Arrange            
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var usuarioRepo = new Mock<IUsuarioRepository>();
            var usuarioService = new UsuarioService(usuarioRepo.Object);

            //Act
            usuarioService.Inativar(usuario);

            //Asset
            usuarioRepo.Verify(r => r.Atualizar(usuario), Times.Once());
        }
    }
        
}
