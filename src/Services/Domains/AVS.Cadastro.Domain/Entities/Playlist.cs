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
        public Guid UsuarioId { get; set; }
        public List<Musica> Musicas {  get; set;}
        //public IReadOnlyCollection<Musica> Musicas => _musicas.AsReadOnly();

        protected Playlist()
        {
        }

        public Playlist(Guid id, Guid usuarioId, string titulo, string descricao, string? foto = null)
        {
            Id = id;
            Titulo = titulo;
            Descricao = descricao;
            Foto = foto;
            UsuarioId = usuarioId;
            Musicas = new List<Musica>();
        }

        public void AdicionarMusica(Musica musica)
        {
            Musicas ??= new List<Musica>();
            Musicas.Add(musica);
        }

        public void AtualizarMusicas(List<Musica> musicas)
        {
            Musicas = musicas;
        }

        public void RemoverMusica(Musica musica)
        {
            Musicas.Remove(musica);
        }
        public void RemoverMusicas()
        {
            Musicas.Clear();
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
