using AVS.Cadastro.Domain.Entities;
using AVS.Infra.CrossCutting;
using AVS.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace AVS.Cadastro.Domain.Testes
{
    [Collection(nameof(UsuarioCollection))]
    public class UsuarioRepositoryTests
    {
        private readonly UsuarioTestsFixture _usuarioTestsFixture;

        public UsuarioRepositoryTests(UsuarioTestsFixture usuarioTestsFixture)
        {
            _usuarioTestsFixture = usuarioTestsFixture;
        }

        [Fact(DisplayName = "Obter Usuario por ID com Sucesso")]
        [Trait("Categoria", "Usuario Repository Mock Tests")]
        public async Task UsuarioRepository_ObterPorId_DeveExecutarComSucesso()
        {
            // Arrange
            //var testObject = new TestClass();
            var testObject = _usuarioTestsFixture.CriarUsuarioValido();
            var options = new DbContextOptionsBuilder<SpotifyCloneContext>().UseInMemoryDatabase(databaseName: "SpotifyCloneSave").Options;
            var context = new Mock<SpotifyCloneContext>(options);
            var dbSetMock = new Mock<DbSet<Usuario>>();

            context.Setup(x => x.Set<Usuario>()).Returns(dbSetMock.Object);            
            dbSetMock.Setup(x => x.FindAsync(It.IsAny<Guid>()).Result).Returns(ValueTask.FromResult(testObject).Result);

            // Act
            var repository = new GenericRepository<Usuario>(context.Object);
            var objEsperado = await repository.ObterPorId(testObject.Id);

            // Assert
            //Assert.NotNull(objEsperado);
            context.Verify(x => x.Set<Usuario>());
            dbSetMock.Verify(x => x.FindAsync(testObject.Id), Times.Once());
        }
    }


}
