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

        private IEnumerable<Usuario> CriarUsuarios(int quantidade, bool excluido)
        {
            var genero = new Faker().PickRandom<Name.Gender>();
            var usuarios = new Faker<Usuario>("pt_BR")
                .CustomInstantiator(f => new Usuario(
                    f.Name.FullName(genero),
                    f.Internet.Email(),
                    f.Person.Cpf(),
                    f.Internet.Avatar(),
                    excluido
                    ))
                .RuleFor(f => f.Id, f => f.Random.Guid());
            return usuarios.Generate(quantidade);
        }

        //public static Usuario CriarUsuarioValido()
        //{            
        //    var genero = new Faker().PickRandom<Name.Gender>();
        //    var usuario = new Faker<Usuario>("pt_BR")
        //        .CustomInstantiator(f => new Usuario(
        //            f.Name.FullName(genero),
        //            f.Internet.Email(),
        //            f.Person.Cpf(),                   
        //            f.Internet.Avatar(),
        //            f.Random.Bool()
        //            ))
        //        .RuleFor(f => f.Id, f => f.Random.Guid());
        //    return usuario;
        //}

        public Usuario CriarUsuarioInvalido()
        {
            var genero = new Faker().PickRandom<Name.Gender>();
            var usuario = new Faker<Usuario>("pt_BR")
                .CustomInstantiator(f => new Usuario(
                    //f.Name.FullName(genero),
                    null,
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
