using AVS.Banda.Domain.Factories;
using AVS.Core.ObjDoinio;
using FluentValidation;

namespace AVS.Banda.Domain
{
    public class Banda : Entity , IAggregateRoot
    {
        public string Nome { get; set; }
        public string Foto { get; set; }
        public string Descricao { get; set; }
        public IList<Album> Albuns { get; set; }

        protected Banda()
        {
        }
                
        public void CriarAlbum(string nome, string descricao, IList<Musica> musicas)
        {
            var album = AlbumFactory.Criar(nome, descricao, musicas);
            Albuns.Add(album);           
        }

        public int QuantidadeAlbuns() => Albuns.Count;

        public IEnumerable<Musica> ObterMusicas () => Albuns.SelectMany(x => x.Musicas).AsEnumerable();

        public override bool EhValido()
        {
            var validationResult = new BandaValidator().Validate(this);
            return validationResult.IsValid;
        }

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
                .WithMessage("Nome da banda inválido.");
            
            //RuleFor(x => x.Foto).NotEmpty().WithMessage("Foto da banda inválida.");
            
            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("Descrição da banda inválida.");
        }
    }
}
