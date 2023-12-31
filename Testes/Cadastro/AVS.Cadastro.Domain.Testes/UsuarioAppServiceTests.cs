﻿using AutoMapper;
using AVS.Banda.Application.DTOs;
using AVS.Cadastro.Application.AppServices;
using AVS.Cadastro.Application.DTOs;
using AVS.Cadastro.Domain.Entities;
using AVS.Cadastro.Domain.Interfaces.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace AVS.Cadastro.Domain.Testes
{
    [Collection(nameof(UsuarioCollection))]
    public class UsuarioAppServiceTests
    {
        private readonly UsuarioTestsFixture _usuarioTestsFixture;

        public UsuarioAppServiceTests(UsuarioTestsFixture usuarioTestsFixture)
        {
            _usuarioTestsFixture = usuarioTestsFixture;
        }

        [Fact(DisplayName = "Adicionar Usuario com Sucesso")]
        [Trait("Categoria", "Usuario AppService Mock Tests")]
        public async Task UsuarioAppService_Adicionar_DeveExecutarComSucesso()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var usuarioDTO = new UsuarioRequestDto(
                usuario.Id, usuario.Nome, usuario.Email.Address, usuario.Cpf.Numero, usuario.Ativo, usuario.Foto);
            var usuarioService = new Mock<IUsuarioService>();
            var automapper = new Mock<IMapper>();
            var usuarioAppService = new UsuarioAppService(usuarioService.Object, automapper.Object);
            automapper.Setup(x => x.Map<Usuario>(usuarioDTO)).Returns(usuario);
            
            //Act
            await usuarioAppService.Salvar(usuarioDTO);

            //Asset
            //Assert.True(usuarioDTO.EhValido());
            usuarioService.Verify(r => r.Salvar(usuario), Times.Once());
        }

        [Fact(DisplayName = "Atualizar Usuario com Sucesso")]
        [Trait("Categoria", "Usuario AppService Mock Tests")]
        public async Task UsuarioAppService_Atualizar_DeveExecutarComSucesso()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var usuarioDTO = new UsuarioRequestDto(
                usuario.Id, usuario.Nome, usuario.Email.Address, usuario.Cpf.Numero, usuario.Ativo, usuario.Foto);
            var usuarioService = new Mock<IUsuarioService>();
            var automapper = new Mock<IMapper>();
            var usuarioAppService = new UsuarioAppService(usuarioService.Object, automapper.Object);
            automapper.Setup(x => x.Map<Usuario>(usuarioDTO)).Returns(usuario);

            //Act
            await usuarioAppService.Atualizar(usuarioDTO);

            //Asset
            //Assert.True(usuarioDTO.EhValido());
            usuarioService.Verify(r => r.Atualizar(usuario), Times.Once());
        }

        [Fact(DisplayName = "Remover Usuario com Sucesso")]
        [Trait("Categoria", "Usuario AppService Mock Tests")]
        public async Task UsuarioAppService_Remover_DeveExecutarComSucesso()
        {
            //Arrange
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var usuarioDTO = new UsuarioRequestDto(
                usuario.Id, usuario.Nome, usuario.Email.Address, usuario.Cpf.Numero, usuario.Ativo, usuario.Foto);
            var usuarioService = new Mock<IUsuarioService>();
            var automapper = new Mock<IMapper>();
            var usuarioAppService = new UsuarioAppService(usuarioService.Object, automapper.Object);
            automapper.Setup(x => x.Map<Usuario>(usuarioDTO)).Returns(usuario);

            //Act
            await usuarioAppService.Exluir(usuarioDTO);

            //Asset
            //Assert.True(usuarioDTO.EhValido());
            usuarioService.Verify(r => r.Exluir(usuario), Times.Once());
        }

        [Fact(DisplayName = "Obter todos Usuarios com Sucesso")]
        [Trait("Categoria", "Usuario AppService Mock Tests")]
        public async Task UsuarioAppService_ObterTodos_DeveExecutarComSucesso()
        {
            //Arrange            
            var usuarioService = new Mock<IUsuarioService>();
            var automapper = new Mock<IMapper>();
            usuarioService.Setup(r => r.ObterTodos()).Returns(_usuarioTestsFixture.ObterUsuarios());            
            var usuarioAppService = new UsuarioAppService(usuarioService.Object, automapper.Object);
            automapper.Setup(x => x.Map<IEnumerable<UsuarioResponseDto>>(_usuarioTestsFixture.ObterUsuariosAtivos()));

            //Act
            var usuarioDTOs = await usuarioAppService.ObterTodos();

            //Asset
            //Assert.True(usuarioDTOs.Any());
            usuarioService.Verify(r => r.ObterTodos(), Times.Once());
        }

        [Fact(DisplayName = "Obter todos Usuarios Ativos com Sucesso")]
        [Trait("Categoria", "Usuario AppService Mock Tests")]
        public async Task UsuarioAppService_ObterTodosAtivos_DeveExecutarComSucesso()
        {
            //Arrange            
            var usuarioService = new Mock<IUsuarioService>();
            var automapper = new Mock<IMapper>();
            usuarioService.Setup(r => r.ObterTodosAtivos()).Returns(_usuarioTestsFixture.ObterUsuariosAtivos());
            var usuarioAppService = new UsuarioAppService(usuarioService.Object, automapper.Object);
            automapper.Setup(x => x.Map<IEnumerable<UsuarioResponseDto>>(_usuarioTestsFixture.ObterUsuariosAtivos()));

            //Act
            var usuarioDTOs = await usuarioAppService.ObterTodosAtivos();

            //Asset
            //Assert.True(usuarioDTOs.Any());
            usuarioService.Verify(r => r.ObterTodosAtivos(), Times.Once());            
            Assert.False(usuarioDTOs.Count(u => !u.Ativo) > 0);
        }

        [Fact(DisplayName = "Obter Usuario por ID com Sucesso")]
        [Trait("Categoria", "Usuario AppService Mock Tests")]
        public async Task UsuarioAppService_ObterPorId_DeveExecutarComSucesso()
        {
            //Arrange            
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();            
            var usuarioDTO = new UsuarioResponseDto(
                usuario.Id, usuario.Nome, usuario.Email.Address, usuario.Cpf.Numero, usuario.Ativo, usuario.Foto, new List<PlaylistResponseDto>());
            var usuarioService = new Mock<IUsuarioService>();
            var automapper = new Mock<IMapper>();
            usuarioService.Setup(r => r.ObterPorId(usuario.Id).Result).Returns(usuario);
            var usuarioAppService = new UsuarioAppService(usuarioService.Object, automapper.Object);
            automapper.Setup(x => x.Map<UsuarioResponseDto>(usuario)).Returns(usuarioDTO);

            //Act
            var usuarioAtual = await usuarioAppService.ObterPorId(usuario.Id);

            //Asset
            usuarioService.Verify(r => r.ObterPorId(usuario.Id), Times.Once());
            Assert.Equal(usuario.Id, usuarioAtual.Id);
        }

        [Fact(DisplayName = "Ativar Usuario com Sucesso")]
        [Trait("Categoria", "Usuario AppService Mock Tests")]
        public async Task UsuarioAppService_Ativar_DeveExecutarComSucesso()
        {
            //Arrange            
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var usuarioDTO = new UsuarioRequestDto(
                usuario.Id, usuario.Nome, usuario.Email.Address, usuario.Cpf.Numero, usuario.Ativo, usuario.Foto);
            var usuarioService = new Mock<IUsuarioService>();
            var automapper = new Mock<IMapper>();
            var usuarioAppService = new UsuarioAppService(usuarioService.Object, automapper.Object);
            automapper.Setup(x => x.Map<Usuario>(usuarioDTO)).Returns(usuario);

            //Act
            await usuarioAppService.Ativar(usuarioDTO);

            //Asset
            usuarioService.Verify(r => r.Ativar(usuario), Times.Once());
        }

        [Fact(DisplayName = "Inativar Usuario com Sucesso")]
        [Trait("Categoria", "Usuario AppService Mock Tests")]
        public async Task UsuarioAppService_Inativar_DeveExecutarComSucesso()
        {
            //Arrange            
            var usuario = _usuarioTestsFixture.CriarUsuarioValido();
            var usuarioDTO = new UsuarioRequestDto(
                usuario.Id, usuario.Nome, usuario.Email.Address, usuario.Cpf.Numero, usuario.Ativo, usuario.Foto);
            var usuarioService = new Mock<IUsuarioService>();
            var automapper = new Mock<IMapper>();
            var usuarioAppService = new UsuarioAppService(usuarioService.Object, automapper.Object);
            automapper.Setup(x => x.Map<Usuario>(usuarioDTO)).Returns(usuario);

            //Act
            await usuarioAppService.Inativar((UsuarioRequestDto)usuarioDTO);

            //Asset
            usuarioService.Verify(r => r.Inativar(usuario), Times.Once());
        }
    }
        
}
