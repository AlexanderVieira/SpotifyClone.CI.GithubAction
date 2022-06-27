using AVS.Banda.Domain.Factories;
using AVS.Core.ObjDoinio;
using FluentValidation;

namespace AVS.Banda.Domain.Entities
{
    public class Banda : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string? Foto { get; private set; }
        public string Descricao { get; private set; }
        public virtual IList<Album> Albuns { get; private set; }

        public Banda()
        {
        }

        public Banda(Guid id, string nome, string descricao, string? foto)
        {
            Id = id;
            Nome = nome;
            Foto = foto;
            Descricao = descricao;
            Albuns = new List<Album>();
        }

        public void CriarAlbum(Guid id, Guid bandaId, string nome, string descricao, string? foto, IList<Musica> musicas)
        {
            var album = AlbumFactory.Criar(id, bandaId, nome, descricao, foto, musicas);
            Albuns.Add(album);
        }

        public int QuantidadeAlbuns() => Albuns.Count;

        public IEnumerable<Musica> ObterMusicas() => Albuns.SelectMany(x => x.Musicas).AsEnumerable();

        public override bool EhValido()
        {
            var validationResult = new BandaValidator().Validate(this);
            return validationResult.IsValid;
        }
        public override void Validar() =>
            new BandaValidator().ValidateAndThrow(this);

    }

    public class BandaValidator : AbstractValidator<Banda>
    {
        public BandaValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido.");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome da banda é obrigatório.");

            //RuleFor(x => x.Foto)
            //    .NotEmpty()
            //    .WithMessage("Foto da banda é obrigatória.");

            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("Descrição da banda é obrigatória.");
        }
    }
}
