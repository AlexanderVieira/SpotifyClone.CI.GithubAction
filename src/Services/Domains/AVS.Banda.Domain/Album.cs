using AVS.Core.ObjDoinio;
using FluentValidation;

namespace AVS.Banda.Domain
{
    public class Album : Entity
    {        
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Foto { get; private set; }
        public IList<Musica> Musicas { get; private set; }

        protected Album()
        {            
        }

        public Album(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;
            Musicas = new List<Musica>();
        }

        public void AdicionarMusica(Musica musica)
        {
            Musicas.Add(musica);
        }

        public void AtualizarMusicas(IList<Musica> musicas)
        {
            Musicas = musicas;
        }        

        public override bool EhValido()
        {
            var validationResult = new AlbumValidator().Validate(this);
            return validationResult.IsValid;
        }

    }

    public class AlbumValidator : AbstractValidator<Album>
    {
        public AlbumValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do album inválido.");
            
            RuleFor(x => x.Titulo)
                .NotEmpty()
                .WithMessage("Título do album inválido.");
            
            RuleFor(x => x.Foto)
                .NotEmpty()
                .WithMessage("Foto do album inválida.");
            
            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("Descrição do album inválida.");
        }
    }
}
