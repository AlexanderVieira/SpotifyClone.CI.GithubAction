using AVS.Cadastro.Domain.Interfaces.Repositories;
using AVS.Cadastro.Domain.Services;
using Moq;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task UsuarioService_Adicionar_DeveExecutarComSucesso()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var usuarioRepo = new Mock<IUsuarioRepository>();
            var usuarioService = new UsuarioService(usuarioRepo.Object);

            //Act
            await usuarioService.Salvar(usuario);

            //Asset
            Assert.True(usuario.EhValido());
            usuarioRepo.Verify(r => r.Salvar(usuario), Times.Once());
        }

        [Fact(DisplayName = "Atualizar Usuario com Sucesso")]
        [Trait("Categoria", "Usuario Service Mock Tests")]
        public async Task UsuarioService_Atualizar_DeveExecutarComSucesso()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var usuarioRepo = new Mock<IUsuarioRepository>();
            var usuarioService = new UsuarioService(usuarioRepo.Object);

            //Act
            await usuarioService.Atualizar(usuario);

            //Asset
            Assert.True(usuario.EhValido());
            usuarioRepo.Verify(r => r.Atualizar(usuario), Times.Once());
        }

        [Fact(DisplayName = "Remover Usuario com Sucesso")]
        [Trait("Categoria", "Usuario Service Mock Tests")]
        public async Task UsuarioService_Remover_DeveExecutarComSucesso()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var usuarioRepo = new Mock<IUsuarioRepository>();
            var usuarioService = new UsuarioService(usuarioRepo.Object);

            //Act
            await usuarioService.Exluir(usuario);

            //Asset
            Assert.True(usuario.EhValido());
            usuarioRepo.Verify(r => r.Exluir(usuario), Times.Once());
        }

        [Fact(DisplayName = "Obter todos Usuarios com Sucesso")]
        [Trait("Categoria", "Usuario Service Mock Tests")]
        public async Task UsuarioService_ObterTodos_DeveExecutarComSucesso()
        {
            //Arrange            
            var usuarioRepo = new Mock<IUsuarioRepository>();
            usuarioRepo.Setup(r => r.ObterTodos()).Returns(_usuarioTestsFixture.ObterUsuarios());
            var usuarioService = new UsuarioService(usuarioRepo.Object);

            //Act
            var usuarios = await usuarioService.ObterTodos();
            
            //Asset
            Assert.True(usuarios.Any());
            usuarioRepo.Verify(r => r.ObterTodos(), Times.Once());
        }

        [Fact(DisplayName = "Obter todos Usuarios Ativos com Sucesso")]
        [Trait("Categoria", "Usuario Service Mock Tests")]
        public async Task UsuarioService_ObterTodosAtivos_DeveExecutarComSucesso()
        {
            //Arrange            
            var usuarioRepo = new Mock<IUsuarioRepository>();
            usuarioRepo.Setup(r => r.ObterTodosAtivos()).Returns(_usuarioTestsFixture.ObterUsuariosAtivos());
            var usuarioService = new UsuarioService(usuarioRepo.Object);

            //Act
            var usuarios = await usuarioService.ObterTodosAtivos();         

            //Asset
            usuarioRepo.Verify(r => r.ObterTodosAtivos(), Times.Once());
            Assert.True(usuarios.Any());            
            Assert.False(usuarios.Count(u => !u.Ativo) > 0);            
        }

        [Fact(DisplayName = "Obter Usuario por ID com Sucesso")]
        [Trait("Categoria", "Usuario Service Mock Tests")]
        public async Task UsuarioService_ObterPorId_DeveExecutarComSucesso()
        {
            //Arrange            
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var usuarioRepo = new Mock<IUsuarioRepository>();
            usuarioRepo.Setup(r => r.ObterPorId(usuario.Id).Result).Returns(usuario);
            var usuarioService = new UsuarioService(usuarioRepo.Object);

            //Act
            var usuarioAtual = await usuarioService.ObterPorId(usuario.Id);

            //Asset
            usuarioRepo.Verify(r => r.ObterPorId(usuario.Id), Times.Once());
            Assert.Equal(usuario.Id, usuarioAtual.Id);            
        }

        [Fact(DisplayName = "Ativar Usuario com Sucesso")]
        [Trait("Categoria", "Usuario Service Mock Tests")]
        public async Task UsuarioService_Ativar_DeveExecutarComSucesso()
        {
            //Arrange            
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var usuarioRepo = new Mock<IUsuarioRepository>();            
            var usuarioService = new UsuarioService(usuarioRepo.Object);

            //Act
            await usuarioService.Ativar(usuario);

            //Asset
            usuarioRepo.Verify(r => r.Atualizar(usuario), Times.Once());            
        }
        
        [Fact(DisplayName = "Inativar Usuario com Sucesso")]
        [Trait("Categoria", "Usuario Service Mock Tests")]
        public async Task UsuarioService_Inativar_DeveExecutarComSucesso()
        {
            //Arrange            
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var usuarioRepo = new Mock<IUsuarioRepository>();
            var usuarioService = new UsuarioService(usuarioRepo.Object);

            //Act
            await usuarioService.Inativar(usuario);

            //Asset
            usuarioRepo.Verify(r => r.Atualizar(usuario), Times.Once());
        }
    }
        
}
