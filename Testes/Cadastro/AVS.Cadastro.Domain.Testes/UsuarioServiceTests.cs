using AVS.Cadastro.Domain.Entities;
using AVS.Core.Data;
using Moq;
using System;
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

    public interface IUsuarioService
    {
        void Adicionar(Usuario usuario);
    }
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void Adicionar(Usuario usuario)
        {
            if (!usuario.EhValido()) return;
            _usuarioRepository.Adicionar(usuario);
        }
    }

    public interface IUsuarioRepository : IRepository<Usuario>
    {
        void Adicionar(Usuario usuario);
    }

    public class UsuarioRepository : IUsuarioRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public void Adicionar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
