using AVS.Banda.Domain;
using AVS.Core.ObjDoinio;
using FluentValidation;

namespace AVS.Cadastro.Domain.Entities
{
    public class Playlist : Entity
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string? Foto { get; set; }
        public Usuario Usuario { get; set; }
        private List<Musica> _musicas {  get; set;}
        public IReadOnlyCollection<Musica> Musicas => _musicas.AsReadOnly();

        protected Playlist()
        {
        }

        public Playlist(string titulo, string descricao, string? foto = null)
        {
            Titulo = titulo;
            Descricao = descricao;
            Foto = foto;
            //Musicas = new List<Musica>();
        }

        public void AdicionarMusica(Musica musica)
        {
            _musicas ??= new List<Musica>();
            _musicas.Add(musica);
        }

        public void AtualizarMusicas(List<Musica> musicas)
        {
            _musicas = musicas;
        }

        public void RemoverMusica(Musica musica)
        {
            _musicas.Remove(musica);
        }
        public void RemoverMusicas()
        {
            _musicas.Clear();
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
