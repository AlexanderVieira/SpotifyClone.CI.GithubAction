using AVS.Cadastro.Domain.Entities;
using AVS.Core.ObjDoinio;
using Bogus;
using Bogus.DataSets;
using Bogus.Extensions.Brazil;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AVS.Cadastro.Domain.Testes
{
    [Collection(nameof(UsuarioCollection))]
    public class UsuarioTestsValido 
    {
        private readonly UsuarioTestsFixture _usuarioTestsFixture;

        public UsuarioTestsValido(UsuarioTestsFixture usuarioTestsFixture)
        {
            _usuarioTestsFixture = usuarioTestsFixture;
        }
               
        [Fact(DisplayName = "Novo Usuario valido")]
        [Trait("Categoria", "Usuario Testes")]        
        public void Usuario_NovoUsuario_DeveEstarValido()
        {
            //Arrange
             var usuario = UsuarioTestsFixture.CriarUsuarioValido();

            //Act
            var result = usuario.EhValido();
            
            //Assert
            Assert.True(result);
            Assert.Equal(0, usuario.ValidationResult.Errors.Count);
        }

        [Fact(DisplayName = "Usuario Criar Playlist")]
        [Trait("Categoria", "Usuario Testes")]
        public void Usuario_CriarPlaylist_DeveTerTamanhoMaiorOUIgualUm()
        {
            //Arrange
            var usuario = UsuarioTestsFixture.CriarUsuarioValido();
            var playlist = new Playlist("Titulo", "Descricao");
            //Act
            usuario.AdicionarPlaylist(playlist);

            //Assert            
            Assert.NotEqual(0, usuario.Playlists.Count);
        }

        [Fact(DisplayName = "Usuario Atualizar Playlist")]
        [Trait("Categoria", "Usuario Testes")]
        public void Usuario_AtualizarPlaylist_DeveTerTamanhoMaiorOUIgualUm()
        {
            //Arrange
            var usuario = UsuarioTestsFixture.CriarUsuarioValido();
            var playlists = new List<Playlist> { new Playlist("Titulo", "Descricao") };
            //Act
            usuario.AtualizarPlaylist(playlists);

            //Assert            
            Assert.NotEqual(0, usuario.Playlists.Count);
        }

        [Fact(DisplayName = "Usuario Remover Playlist")]
        [Trait("Categoria", "Usuario Testes")]
        public void Usuario_RemoverPlaylist_DeveTerTamanhoIqualLenghtMenosUm()
        {
            //Arrange
            var usuario = UsuarioTestsFixture.CriarUsuarioValido();
            var playlists = new List<Playlist> 
            { 
                new Playlist("Titulo", "Descricao"), 
                new Playlist("Titulo-1", "Descricao-1")
            };
            usuario.AtualizarPlaylist(playlists);
            var countExpected = playlists.Count - 1;
            //Act
            usuario.RemoverPlaylist(playlists[1]);

            //Assert            
            Assert.Equal(countExpected, usuario.Playlists.Count);
        }

        [Fact(DisplayName = "Usuario Remover Todas Playlist")]
        [Trait("Categoria", "Usuario Testes")]
        public void Usuario_RemoverPlaylist_DeveTerTamanhoIqualZero()
        {
            //Arrange
            var usuario = UsuarioTestsFixture.CriarUsuarioValido();
            var playlists = new List<Playlist> 
            { 
                new Playlist("Titulo", "Descricao"), 
                new Playlist("Titulo-1", "Descricao-1")
            };
            usuario.AtualizarPlaylist(playlists);
            
            //Act
            usuario.RemoverPlaylists();

            //Assert            
            Assert.Equal(0, usuario.Playlists.Count);
        }
    }

    [Collection(nameof(UsuarioCollection))]
    public class UsuarioTestsInvalido
    {
        private readonly UsuarioTestsFixture _usuarioTestsFixture;

        public UsuarioTestsInvalido(UsuarioTestsFixture usuarioTestsFixture)
        {
            _usuarioTestsFixture = usuarioTestsFixture;
        }

        [Fact(DisplayName = "Novo Usuario Nome Vazio")]
        [Trait("Categoria", "Usuario Testes")]
        public void Usuario_ValidarNomeVazio_DeveRetornarMensagem()
        {
            //Arrange
            var usuario = UsuarioTestsFixture.CriarUsuarioInvalido();

            //Act
            var result = usuario.EhValido();
            
            //Assert            
            Assert.False(result);
            Assert.Contains("Nome é obrigatório.", usuario.ValidationResult.Errors[0].ErrorMessage);
        }

        [Fact(DisplayName = "Novo Usuario Nome Vazio")]
        [Trait("Categoria", "Usuario Testes")]
        public void Usuario_ValidarNomeVazio_DeveRetornarExcecao()
        {
            //Arrange
            var usuario = UsuarioTestsFixture.CriarUsuarioValido();

            //Act
            var result = usuario.EhValido();

            //Assert
            var ex = Assert.Throws<DomainException>(() =>
                new Usuario(string.Empty, usuario.Email.Address, usuario.Cpf.Numero, usuario.Foto, usuario.Excluido)
            );
            
            Assert.Equal("Nome é obrigatório.", ex.Message);
        }

        [Fact(DisplayName = "Novo Usuario Nome Nulo")]
        [Trait("Categoria", "Usuario Testes")]
        public void Usuario_ValidarNomeNulo_DeveRetornarExcecao()
        {
            //Arrange
            var usuario = UsuarioTestsFixture.CriarUsuarioValido();

            //Act
            var result = usuario.EhValido();

            //Assert
            var ex = Assert.Throws<DomainException>(() =>
                new Usuario(null, usuario.Email.Address, usuario.Cpf.Numero, usuario.Foto, usuario.Excluido)
            );

            Assert.Equal("Nome é obrigatório.", ex.Message);
        }

        [Fact(DisplayName = "Novo Usuario E-mail Vazio")]
        [Trait("Categoria", "Usuario Testes")]
        public void Usuario_ValidarEmailVazio_DeveRetornarExcecao()
        {
            //Arrange
            var usuario = UsuarioTestsFixture.CriarUsuarioValido();

            //Act
            var result = usuario.EhValido();

            //Assert
            var ex = Assert.Throws<DomainException>(() =>
                new Usuario(usuario.Nome, string.Empty, usuario.Cpf.Numero, usuario.Foto, usuario.Excluido)
            );

            Assert.Equal("E-mail é obrigatório.", ex.Message);
        }

        [Fact(DisplayName = "Novo Usuario E-mail Nulo")]
        [Trait("Categoria", "Usuario Testes")]
        public void Usuario_ValidarEmailNulo_DeveRetornarExcecao()
        {
            //Arrange
            var usuario = UsuarioTestsFixture.CriarUsuarioValido();

            //Act
            var result = usuario.EhValido();

            //Assert
            var ex = Assert.Throws<DomainException>(() =>
                new Usuario(usuario.Nome, null, usuario.Cpf.Numero, usuario.Foto, usuario.Excluido)
            );

            Assert.Equal("E-mail é obrigatório.", ex.Message);
        }

        [Fact(DisplayName = "Novo Usuario CPF Vazio")]
        [Trait("Categoria", "Usuario Testes")]
        public void Usuario_ValidarCpfVazio_DeveRetornarExcecao()
        {
            //Arrange
            var usuario = UsuarioTestsFixture.CriarUsuarioValido();

            //Act
            var result = usuario.EhValido();

            //Assert
            var ex = Assert.Throws<DomainException>(() =>
                new Usuario(usuario.Nome, usuario.Email.Address, string.Empty, usuario.Foto, usuario.Excluido)
            );

            Assert.Equal("Documento é obrigatório.", ex.Message);
        }

        [Fact(DisplayName = "Novo Usuario CPF Nulo")]
        [Trait("Categoria", "Usuario Testes")]
        public void Usuario_ValidarCpfNulo_DeveRetornarExcecao()
        {
            //Arrange
            var usuario = UsuarioTestsFixture.CriarUsuarioValido();

            //Act
            var result = usuario.EhValido();

            //Assert
            var ex = Assert.Throws<DomainException>(() =>
                new Usuario(usuario.Nome, usuario.Email.Address, null, usuario.Foto, usuario.Excluido)
            );

            Assert.Equal("Documento é obrigatório.", ex.Message);
        }

        [Fact(DisplayName = "Novo Usuario Invalido")]
        [Trait("Categoria", "Usuario Testes")]
        public void Usuario_NovoUsuario_DeveEstarInvalido()
        {
            //Arrange
            var usuario = UsuarioTestsFixture.CriarUsuarioInvalido();

            //Act
            var result = usuario.EhValido();

            //Assert            
            result.Should().BeFalse();
            usuario.ValidationResult.Errors.ForEach(f => f.ErrorMessage = "Nome é obrigatório.");
            
        }
    }

    [CollectionDefinition(nameof(UsuarioCollection))]
    public class UsuarioCollection : ICollectionFixture<UsuarioTestsFixture> { }

    public class UsuarioTestsFixture : IDisposable
    {
        public static Usuario CriarUsuarioValido()
        {            
            var genero = new Faker().PickRandom<Name.Gender>();
            var usuario = new Faker<Usuario>("pt_BR")
                .CustomInstantiator(f => new Usuario(
                    f.Name.FullName(genero),
                    f.Internet.Email(),
                    f.Person.Cpf(),                   
                    f.Internet.Avatar(),
                    f.Random.Bool()
                    ))
                .RuleFor(f => f.Id, f => f.Random.Guid());
            return usuario;
        }

        public static Usuario CriarUsuarioInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();
            var usuario = new Faker<Usuario>("pt_BR")
                .CustomInstantiator(f => new Usuario(
                    //f.Name.FullName(genero),
                    string.Empty,
                    f.Internet.Email(),
                    f.Person.Cpf(),
                    //string.Empty,
                    f.Internet.Avatar(),
                    f.Random.Bool()
                    ))
                .RuleFor(f => f.Id, f => f.Random.Guid());
            return usuario;
        }
        public void Dispose()
        {            
        }

    }
}
