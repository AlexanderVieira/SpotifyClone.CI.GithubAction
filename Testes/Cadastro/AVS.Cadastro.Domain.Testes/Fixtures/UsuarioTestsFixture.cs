using AVS.Cadastro.Domain.Entities;
using Bogus;
using Bogus.DataSets;
using Bogus.Extensions.Brazil;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AVS.Cadastro.Domain.Testes
{
    public class UsuarioTestsFixture : IDisposable
    {
        public Usuario CriarUsuarioValido()
        {
            return CriarUsuarios(1, true).FirstOrDefault();
        }

        public IEnumerable<Usuario> ObterUsuarios()
        {
            var usuarios = new List<Usuario>();
            usuarios.AddRange(CriarUsuarios(50, true).ToList());
            usuarios.AddRange(CriarUsuarios(50, false).ToList());
            return usuarios;
        }

        private IEnumerable<Usuario> CriarUsuarios(int quantidade, bool Ativo)
        {
            var genero = new Faker().PickRandom<Name.Gender>();
            var usuarios = new Faker<Usuario>("pt_BR")
                .CustomInstantiator(f => new Usuario(
                    f.Name.FullName(genero),
                    f.Internet.Email(),
                    f.Person.Cpf(),
                    f.Internet.Avatar(),
                    Ativo
                    ))
                .RuleFor(f => f.Id, f => f.Random.Guid());
            return usuarios.Generate(quantidade);
        }
        
        public Usuario CriarUsuarioInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();
            var usuario = new Faker<Usuario>("pt_BR")
                .CustomInstantiator(f => new Usuario(
                    string.Empty,
                    "teste",
                    string.Empty,
                    string.Empty,
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
