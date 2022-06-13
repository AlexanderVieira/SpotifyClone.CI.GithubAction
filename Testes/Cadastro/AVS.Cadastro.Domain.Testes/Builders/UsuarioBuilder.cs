using AVS.Cadastro.Domain.Entities;
using Xunit;

namespace AVS.Cadastro.Domain.Testes.Builders
{
    [Collection(nameof(UsuarioCollection))]
    public class UsuarioBuilder
    {        
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public bool Ativo { get; private set; }
        public string Foto { get; private set; }

        public UsuarioBuilder()
        {
            var usuarioTestsFixture = new UsuarioTestsFixture();
            var usuario = usuarioTestsFixture.CriarUsuarioValido();
            Nome = usuario.Nome;
            Email = usuario.Email.Address;
            Cpf = usuario.Cpf.Numero;
            Foto = usuario.Foto;
            Ativo = usuario.Ativo;
        }
                
        public static UsuarioBuilder Novo()
        {
            return new UsuarioBuilder();
        }

        public UsuarioBuilder ComNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public UsuarioBuilder ComEmail(string email)
        {
            Email = email;
            return this;
        }

        public UsuarioBuilder ComCpf(string cpf)
        {
            Cpf = cpf;
            return this;            
        }

        public UsuarioBuilder ComFoto(string foto)
        {
            Foto = foto;
            return this;
        }
        
        public Usuario Buid()
        {
            return new Usuario(Nome, Email, Cpf, Foto, Ativo);
        }
    }
}
