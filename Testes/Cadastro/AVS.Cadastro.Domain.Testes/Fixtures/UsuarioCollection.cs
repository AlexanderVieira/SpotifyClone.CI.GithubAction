using Xunit;

namespace AVS.Cadastro.Domain.Testes
{
    [CollectionDefinition(nameof(UsuarioCollection))]
    public class UsuarioCollection : ICollectionFixture<UsuarioTestsFixture> { }
}
