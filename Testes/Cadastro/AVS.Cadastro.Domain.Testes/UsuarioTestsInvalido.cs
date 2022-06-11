using AVS.Cadastro.Domain.Entities;
using AVS.Core.ObjDoinio;
using FluentAssertions;
using Xunit;

namespace AVS.Cadastro.Domain.Testes
{
    [Collection(nameof(UsuarioCollection))]
    public class UsuarioTestsInvalido
    {
        private readonly UsuarioTestsFixture _usuarioTestsFixture;

        public UsuarioTestsInvalido(UsuarioTestsFixture usuarioTestsFixture)
        {
            _usuarioTestsFixture = usuarioTestsFixture;
        }

        [Fact(DisplayName = "Novo Usuario: Nome vazio retornar mensagem")]
        [Trait("Categoria", "Usuario Bogus Testes")]
        public void Usuario_ValidarNomeVazio_DeveRetornarMensagem()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioInvalido();

            //Act
            var result = usuario.EhValido();
            
            //Assert            
            Assert.False(result);            
            Assert.True(usuario.ValidationResult.Errors
                        .TrueForAll(f => { f.ErrorMessage = "Nome é obrigatório."; return true; }));
            
        }

        [Fact(DisplayName = "Novo Usuario Nome Vazio")]
        [Trait("Categoria", "Usuario Bogus Testes")]
        public void Usuario_ValidarNomeVazio_DeveRetornarExcecao()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();

            //Act
            
            //Assert
            var ex = Assert.Throws<DomainException>(() =>                
                UsuarioFactory.Criar(string.Empty, usuario.Email.Address, usuario.Cpf.Numero, usuario.Foto, usuario.Excluido)
            );

            Assert.Equal("Nome é obrigatório.", ex.Message);
        }

        [Fact(DisplayName = "Novo Usuario Nome Nulo")]
        [Trait("Categoria", "Usuario Bogus Testes")]
        public void Usuario_ValidarNomeNulo_DeveRetornarExcecao()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();

            //Act
            //var result = usuario.EhValido();

            //Assert
            var ex = Assert.Throws<DomainException>(() =>                
                UsuarioFactory.Criar(null, usuario.Email.Address, usuario.Cpf.Numero, usuario.Foto, usuario.Excluido)
            );

            Assert.Equal("Nome é obrigatório.", ex.Message);
        }

        [Fact(DisplayName = "Novo Usuario E-mail Vazio")]
        [Trait("Categoria", "Usuario Bogus Testes")]
        public void Usuario_ValidarEmailVazio_DeveRetornarExcecao()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();

            //Act
            var result = usuario.EhValido();

            //Assert
            var ex = Assert.Throws<DomainException>(() =>
                new Usuario(usuario.Nome, string.Empty, usuario.Cpf.Numero, usuario.Foto, usuario.Excluido)
            );

            Assert.Equal("E-mail é obrigatório.", ex.Message);
        }

        [Fact(DisplayName = "Novo Usuario E-mail Nulo")]
        [Trait("Categoria", "Usuario Bogus Testes")]
        public void Usuario_ValidarEmailNulo_DeveRetornarExcecao()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();

            //Act
            var result = usuario.EhValido();

            //Assert
            var ex = Assert.Throws<DomainException>(() =>
                new Usuario(usuario.Nome, null, usuario.Cpf.Numero, usuario.Foto, usuario.Excluido)
            );

            Assert.Equal("E-mail é obrigatório.", ex.Message);
        }

        [Fact(DisplayName = "Novo Usuario CPF Vazio")]
        [Trait("Categoria", "Usuario Bogus Testes")]
        public void Usuario_ValidarCpfVazio_DeveRetornarExcecao()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();

            //Act
            var result = usuario.EhValido();

            //Assert
            var ex = Assert.Throws<DomainException>(() =>
                new Usuario(usuario.Nome, usuario.Email.Address, string.Empty, usuario.Foto, usuario.Excluido)
            );

            Assert.Equal("Documento é obrigatório.", ex.Message);
        }

        [Fact(DisplayName = "Novo Usuario CPF Nulo")]
        [Trait("Categoria", "Usuario Bogus Testes")]
        public void Usuario_ValidarCpfNulo_DeveRetornarExcecao()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();

            //Act
            var result = usuario.EhValido();

            //Assert
            var ex = Assert.Throws<DomainException>(() =>
                new Usuario(usuario.Nome, usuario.Email.Address, null, usuario.Foto, usuario.Excluido)
            );

            Assert.Equal("Documento é obrigatório.", ex.Message);
        }

        [Fact(DisplayName = "Novo Usuario Invalido")]
        [Trait("Categoria", "Usuario Bogus Testes")]
        public void Usuario_NovoUsuario_DeveEstarInvalido()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioInvalido();

            //Act
            var result = usuario.EhValido();

            //Assert            
            result.Should().BeFalse();
            usuario.ValidationResult.Errors.ForEach(f => f.ErrorMessage = "Nome é obrigatório.");
            
        }
    }

    
}
