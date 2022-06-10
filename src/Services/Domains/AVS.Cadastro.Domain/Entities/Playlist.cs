using AVS.Core.ObjDoinio;
using FluentValidation;

namespace AVS.Cadastro.Domain.Entities
{
    public class Playlist : Entity
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }

        protected Playlist()
        {
        }

        public Playlist(string titulo, string descricao)
        {
            Titulo = titulo;
            Descricao = descricao;            
        }

        public override bool EhValido()
        {
            var validationResult = new PlaylistValidator().Validate(this);
            return validationResult.IsValid;
        }
    }

    public class PlaylistValidator : AbstractValidator<Playlist>
    {
        public PlaylistValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id da playlist inválido.");
            
            RuleFor(x => x.Titulo)
                .NotEmpty()
                .WithMessage("Titulo da playlist inválido.");
            
            //RuleFor(x => x.Foto).NotEmpty().WithMessage("Foto da playlist inválida.");
            
            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("Descrição da playlist inválida.");
        }
    }
}
