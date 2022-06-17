using AVS.Banda.Domain;
using AVS.Cadastro.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
        [Trait("Categoria", "Usuario Bogus Testes")]        
        public void Usuario_NovoUsuario_DeveEstarValido()
        {
            //Arrange
             var usuario = _usuarioTestsFixture.CriarUsuarioValido();

            //Act
            var result = usuario.EhValido();
            
            //Assert
            Assert.True(result);
            Assert.Equal(0, usuario.ValidationResult.Errors.Count);
        }

        [Fact(DisplayName = "Usuario Criar Playlist")]
        [Trait("Categoria", "Usuario Bogus Testes")]
        public void Usuario_CriarPlaylist_DeveTerTamanhoMaiorOUIgualUm()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var playlist = new Playlist(Guid.NewGuid(), usuario.Id, "Titulo", "Descricao");
            //Act
            usuario.AdicionarPlaylist(playlist);

            //Assert            
            Assert.NotEqual(0, usuario.Playlists.Count);
        }

        [Fact(DisplayName = "Usuario Atualizar Playlist")]
        [Trait("Categoria", "Usuario Bogus Testes")]
        public void Usuario_AtualizarPlaylist_DeveTerTamanhoMaiorOUIgualUm()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var playlists = new List<Playlist> { new Playlist(Guid.NewGuid(), usuario.Id, "Titulo", "Descricao") };
            //Act
            usuario.AtualizarPlaylist(playlists);

            //Assert            
            Assert.NotEqual(0, usuario.Playlists.Count);
        }

        [Fact(DisplayName = "Usuario Remover Playlist")]
        [Trait("Categoria", "Usuario Bogus Testes")]
        public void Usuario_RemoverPlaylist_DeveTerTamanhoIqualLenghtMenosUm()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var playlists = new List<Playlist> 
            { 
                new Playlist(Guid.NewGuid(), usuario.Id, "Titulo", "Descricao"), 
                new Playlist(Guid.NewGuid(), usuario.Id, "Titulo-1", "Descricao-1")
            };
            usuario.AtualizarPlaylist(playlists);
            var countExpected = playlists.Count - 1;
            //Act
            usuario.RemoverPlaylist(playlists[1]);

            //Assert            
            Assert.Equal(countExpected, usuario.Playlists.Count);
        }

        [Fact(DisplayName = "Usuario Remover Todas Playlists")]
        [Trait("Categoria", "Usuario Bogus Testes")]
        public void Usuario_RemoverPlaylist_DeveTerTamanhoIqualZero()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var playlists = new List<Playlist> 
            { 
                new Playlist(Guid.NewGuid(), usuario.Id, "Titulo", "Descricao"), 
                new Playlist(Guid.NewGuid(), usuario.Id, "Titulo-1", "Descricao-1")
            };
            usuario.AtualizarPlaylist(playlists);
            
            //Act
            usuario.RemoverPlaylists();

            //Assert            
            Assert.Equal(0, usuario.Playlists.Count);
        }

        [Fact(DisplayName = "Usuario Ativo")]
        [Trait("Categoria", "Usuario Bogus Testes")]
        public void Usuario_Ativar_DeveTerFlagAtivoIgualVerdadeiro()
        {            
               //Arrange
               var usuario = _usuarioTestsFixture.CriarUsuarioValido();

            //Act
            usuario.Ativar();

            //Assert            
            Assert.True(usuario.Ativo);
        }

        [Fact(DisplayName = "Usuario Inativo")]
        [Trait("Categoria", "Usuario Bogus Testes")]
        public void Usuario_Inativar_DeveTerFlagAtivoIgualFalso()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();

            //Act
            usuario.Inativar();

            //Assert            
            Assert.False(usuario.Ativo);
        }

        [Fact(DisplayName = "Usuario Adicionar Musica na Playlist")]
        [Trait("Categoria", "Usuario Bogus Testes")]
        public void Usuario_AdicionarMusicaPlaylist_DeveTerTamanhoMaiorOuIgualUm()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();                      
            var playlist = new Playlist(Guid.NewGuid(), usuario.Id, "Titulo", "Descricao");
            var musica = new Musica(Guid.NewGuid(), playlist.Id, "Titulo", 300);
            playlist.AdicionarMusica(musica);    

            //Act
            usuario.AdicionarPlaylist(playlist);            

            //Assert
            Assert.Contains(usuario.Playlists, p => p.Musicas.Contains(musica));
            Assert.All(usuario.Playlists, p => p.Musicas.Any());  
            
        }
        
    }
    
}
