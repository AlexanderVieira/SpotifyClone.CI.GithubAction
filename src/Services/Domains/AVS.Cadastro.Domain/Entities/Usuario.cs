using AVS.Core.ObjDoinio;
using AVS.Core.ObjValor;
using FluentValidation;
using System.Text.RegularExpressions;

namespace AVS.Cadastro.Domain.Entities
{
    public class Usuario : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public Email Email { get; private set; }
        public Cpf Cpf { get; private set; }
        public bool Ativo { get; private set; }
        public string? Foto { get; private set; }
        
        //public Senha Senha { get; private set; }
        
        public List<Playlist> Playlists { get; private set; }

        protected Usuario()
        {            
        }

        public Usuario(Guid id, string nome, string email, string cpf, string? foto, bool ativo)
        {
            //Validar(nome);
            Id = id;
            Nome = nome; 
            Email = new Email(email);
            Cpf = new Cpf(cpf);
            Foto = foto;
            Ativo = ativo;
            Playlists = new List<Playlist>();
        }

        public void AtualizarEmail(string email)
        {
            Email = new Email(email);
        }

        //public void DefinirSenha()
        //{
        //    this.Senha.Valor = SegurancaUtil.HashSHA1(this.Senha.Valor);
        //}

        public void Ativar() => Ativo = true;

        public void Inativar() => Ativo = false;

        public void AdicionarPlaylist(Playlist playlist)
        {
            Playlists ??= new List<Playlist>();
            Playlists.Add(playlist);
        }

        public void AtualizarPlaylist(List<Playlist> playlists)
        {            
            Validar(playlists);
            Playlists = playlists;
        }

        public void RemoverPlaylist(Playlist playlist)
        {            
            Validar(playlist);
            Playlists.Remove(playlist);
            
        }

        public void RemoverPlaylists()
        {
            Playlists.Clear();
        }

        private static void Validar(Playlist playlist)
        {
            Validacao.ValidarSeNulo(playlist, "Playlist vazia.");
        }

        private static void Validar(List<Playlist> playlists)
        {
            var lista = playlists.Cast<object>().ToList();
            Validacao.ValidarSeExiste(lista, "Playlist vazia.");
        }

        //public static void Validar(string param)
        //{
        //    Validacao.ValidarSeNuloVazio(param, "Nome é obrigatório.");
        //}

        public override bool EhValido()
        {
            ValidationResult = new UsuarioValidator().Validate(this);
            return ValidationResult.IsValid;
        }

        public void Validar() =>
            new UsuarioValidator().ValidateAndThrow(this);
    }    

    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do usuário inválido.");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório.")
                .Length(2, 150)
                .WithMessage("O Nome deve ter entre 2 a 150 caracteres.");
                        
            RuleFor(x => x.Cpf.Numero)
                .NotEmpty()
                .WithMessage("Documento é obrigatório.")
                .Must(Cpf.ValidarCpf)
                .WithMessage("Documento inválido.");
            
            RuleFor(x => x.Email.Address)
                .NotEmpty()
                .WithMessage("E-mail é obrigatório.")
                .Must(Email.ValidarEmail)
                .WithMessage("E-mail inválido.");

            RuleFor(x => x.Foto)
                .NotEmpty()
                .WithMessage("Foto do usuário inválida.");

            //RuleFor(x => x.Senha)
            //    .NotEmpty()
            //    .WithMessage("Senha é obrigatória.")
            //    .SetValidator(new SenhaValidator());

        }
        
    }   

    public class SenhaValidator : AbstractValidator<Senha>
    {
        private const string Pattern = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$";

        public SenhaValidator()
        {
            RuleFor(x => x.Valor)                
                .Must(ValidarSeDiferente)
                .WithMessage("A Senha deve ter no mínimo 8 caracteres, uma letra, um caracter especial e um número");
        }

        private bool ValidarSeDiferente(string valor) => Regex.IsMatch(valor, Pattern);        

    }

    public class UsuarioFactory
    {
        public static Usuario Criar(Guid id, string nome, string email, string cpf, string foto, bool Ativo)
        {
            Validacao.ValidarSeNuloVazio(nome, "Nome é obrigatório.");
            return new Usuario(id, nome, email, cpf, foto, Ativo);
        }
    }
    
}
