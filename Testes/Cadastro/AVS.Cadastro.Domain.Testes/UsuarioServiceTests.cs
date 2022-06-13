using AVS.Cadastro.Domain.Interfaces.Repositories;
using AVS.Cadastro.Domain.Services;
using Moq;
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
            Assert.True(usuario.EhValido());
            usuarioRepo.Verify(r => r.Adicionar(usuario), Times.Once());
        }
    }
        
}
