using AVS.Core.ObjDoinio;
using FluentValidation;

namespace AVS.Banda.Domain.Entities
{
    public class Album : Entity
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string? Foto { get; private set; }
        public Guid BandaId { get; private set; }
        public virtual Banda Banda { get; set; }
        public virtual IList<Musica> Musicas { get; private set; }

        protected Album()
        {
        }

        public Album(Guid id, Guid bandaId,  string titulo, string descricao, string? foto)
        {
            Id = id;
            BandaId = bandaId;
            Titulo = titulo;
            Descricao = descricao;
            Foto = foto;
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
        public override void Validar() =>
            new AlbumValidator().ValidateAndThrow(this);

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
                .WithMessage("Título do album é obrigatório.");

            //RuleFor(x => x.Foto)
            //    .NotEmpty()
            //    .WithMessage("Foto do album é obrigatória.");

            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("Descrição do album é obrigatória.");
        }
    }
}
