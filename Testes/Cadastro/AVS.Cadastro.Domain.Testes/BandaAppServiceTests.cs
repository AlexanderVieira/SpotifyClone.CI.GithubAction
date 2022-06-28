﻿using AVS.Banda.Domain.AppServices;
using AVS.Banda.Domain.AppServices.DTOs;
using AVS.Banda.Domain.Entities;
using AVS.Banda.Domain.Interfaces.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AVS.Cadastro.Domain.Testes
{
    [Collection(nameof(UsuarioCollection))]
    public class BandaAppServiceTests
    {
        private readonly UsuarioTestsFixture _usuarioTestsFixture;

        public BandaAppServiceTests(UsuarioTestsFixture usuarioTestsFixture)
        {
            _usuarioTestsFixture = usuarioTestsFixture;
        }

        [Fact(DisplayName = "Adicionar Banda com Sucesso")]
        [Trait("Categoria", "Banda AppService Mock Tests")]
        public async Task BandaAppService_Adicionar_DeveExecutarComSucesso()
        {
            //Arrange
            //var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var banda = new Banda.Domain.Entities.Banda(Guid.NewGuid(), "Biquini Cavadao", "Sucesso!", "http://url.com.br");
            var musica = new Musica(Guid.NewGuid(), Guid.NewGuid(), "Vento. Ventania", 300);            
            var musicas = new List<Musica>();
            musicas.Add(musica);
            banda.CriarAlbum(
                Guid.NewGuid(), Guid.NewGuid(), "Top 10", "As dez melhores!", "http://url.com.br", musicas);
            var bandaService = new Mock<IBandaService>();
            var bandaAppService = new BandaAppService(bandaService.Object);
            var bandaDTO = BandaDTO.ConverterParaBandaDTO(banda);

            //Act
            await bandaAppService.Salvar(bandaDTO);

            //Asset
            Assert.True(bandaDTO.EhValido());
            bandaService.Verify(r => r.Salvar(banda), Times.Once());
        }

        //[Fact(DisplayName = "Atualizar Usuario com Sucesso")]
        //[Trait("Categoria", "Usuario AppService Mock Tests")]
        //public async Task UsuarioAppService_Atualizar_DeveExecutarComSucesso()
        //{
        //    //Arrange
        //    var usuario = _usuarioTestsFixture.CriarUsuarioValido();
        //    var usuarioService = new Mock<IUsuarioService>();
        //    var usuarioAppService = new UsuarioAppService(usuarioService.Object);
        //    var usuarioDTO = UsuarioDTO.ConverterParaUsuarioDTO(usuario);

        //    //Act
        //    await usuarioAppService.Atualizar(usuarioDTO);

        //    //Asset
        //    Assert.True(usuarioDTO.EhValido());
        //    usuarioService.Verify(r => r.Atualizar(usuario), Times.Once());
        //}

        //[Fact(DisplayName = "Remover Usuario com Sucesso")]
        //[Trait("Categoria", "Usuario AppService Mock Tests")]
        //public async Task UsuarioAppService_Remover_DeveExecutarComSucesso()
        //{
        //    //Arrange
        //    var usuario = _usuarioTestsFixture.CriarUsuarioValido();
        //    var usuarioService = new Mock<IUsuarioService>();
        //    var usuarioAppService = new UsuarioAppService(usuarioService.Object);
        //    var usuarioDTO = UsuarioDTO.ConverterParaUsuarioDTO(usuario);

        //    //Act
        //    await usuarioAppService.Exluir(usuarioDTO);

        //    //Asset
        //    Assert.True(usuarioDTO.EhValido());
        //    usuarioService.Verify(r => r.Exluir(usuario), Times.Once());
        //}

        //[Fact(DisplayName = "Obter todos Usuarios com Sucesso")]
        //[Trait("Categoria", "Usuario AppService Mock Tests")]
        //public async Task UsuarioAppService_ObterTodos_DeveExecutarComSucesso()
        //{
        //    //Arrange            
        //    var usuarioService = new Mock<IUsuarioService>();
        //    usuarioService.Setup(r => r.ObterTodos()).Returns(_usuarioTestsFixture.ObterUsuarios());
        //    var usuarioAppService = new UsuarioAppService(usuarioService.Object);

        //    //Act
        //    var usuarioDTOs = await usuarioAppService.ObterTodos();

        //    //Asset
        //    Assert.True(usuarioDTOs.Any());
        //    usuarioService.Verify(r => r.ObterTodos(), Times.Once());
        //}

        //[Fact(DisplayName = "Obter todos Usuarios Ativos com Sucesso")]
        //[Trait("Categoria", "Usuario AppService Mock Tests")]
        //public async Task UsuarioAppService_ObterTodosAtivos_DeveExecutarComSucesso()
        //{
        //    //Arrange            
        //    var usuarioService = new Mock<IUsuarioService>();
        //    usuarioService.Setup(r => r.ObterTodosAtivos()).Returns(_usuarioTestsFixture.ObterUsuariosAtivos());
        //    var usuarioAppService = new UsuarioAppService(usuarioService.Object);

        //    //Act
        //    var usuarioDTOs = await usuarioAppService.ObterTodosAtivos();

        //    //Asset
        //    usuarioService.Verify(r => r.ObterTodosAtivos(), Times.Once());
        //    Assert.True(usuarioDTOs.Any());
        //    Assert.False(usuarioDTOs.Count(u => !u.Ativo) > 0);
        //}

        //[Fact(DisplayName = "Obter Usuario por ID com Sucesso")]
        //[Trait("Categoria", "Usuario AppService Mock Tests")]
        //public async Task UsuarioAppService_ObterPorId_DeveExecutarComSucesso()
        //{
        //    //Arrange            
        //    var usuario = _usuarioTestsFixture.CriarUsuarioValido();
        //    var usuarioService = new Mock<IUsuarioService>();
        //    usuarioService.Setup(r => r.ObterPorId(usuario.Id).Result).Returns(usuario);
        //    var UsuarioAppService = new UsuarioAppService(usuarioService.Object);

        //    //Act
        //    var usuarioAtual = await UsuarioAppService.ObterPorId(usuario.Id);

        //    //Asset
        //    usuarioService.Verify(r => r.ObterPorId(usuario.Id), Times.Once());
        //    Assert.Equal(usuario.Id, usuarioAtual.Id);
        //}

        //[Fact(DisplayName = "Ativar Usuario com Sucesso")]
        //[Trait("Categoria", "Usuario AppService Mock Tests")]
        //public async Task UsuarioAppService_Ativar_DeveExecutarComSucesso()
        //{
        //    //Arrange            
        //    var usuario = _usuarioTestsFixture.CriarUsuarioValido();
        //    var usuarioService = new Mock<IUsuarioService>();
        //    var usuarioAppService = new UsuarioAppService(usuarioService.Object);
        //    var usuarioDTO = UsuarioDTO.ConverterParaUsuarioDTO(usuario);

        //    //Act
        //    await usuarioAppService.Ativar(usuarioDTO);

        //    //Asset
        //    usuarioService.Verify(r => r.Ativar(usuario), Times.Once());
        //}

        //[Fact(DisplayName = "Inativar Usuario com Sucesso")]
        //[Trait("Categoria", "Usuario AppService Mock Tests")]
        //public async Task UsuarioAppService_Inativar_DeveExecutarComSucesso()
        //{
        //    //Arrange            
        //    var usuario = _usuarioTestsFixture.CriarUsuarioValido();
        //    var usuarioService = new Mock<IUsuarioService>();
        //    var usuarioAppService = new UsuarioAppService(usuarioService.Object);
        //    var usuarioDTO = UsuarioDTO.ConverterParaUsuarioDTO(usuario);

        //    //Act
        //    await usuarioAppService.Inativar(usuarioDTO);

        //    //Asset
        //    usuarioService.Verify(r => r.Inativar(usuario), Times.Once());
        //}
    }
        
}