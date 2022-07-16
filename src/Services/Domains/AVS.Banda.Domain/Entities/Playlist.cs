using AVS.Core.ObjDoinio;
using FluentValidation;

namespace AVS.Banda.Domain.Entities
{
    public class Playlist : Entity, IAggregateRoot
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string? Foto { get; private set; }
        public Guid UsuarioId { get; private set; }        
        public virtual IList<MusicaPlaylist> Musicas { get; private set; }

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
            Musicas = new List<MusicaPlaylist>();
        }

        public void AdicionarMusica(MusicaPlaylist musica)
        {
            Musicas ??= new List<MusicaPlaylist>();
            Musicas.Add(musica);
        }

        public void AtualizarMusicas(List<MusicaPlaylist> musicas)
        {
            Musicas = musicas;
        }

        public void RemoverMusica(MusicaPlaylist musica)
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
        public override void Validar() =>
            new PlaylistValidator().ValidateAndThrow(this);
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
                .WithMessage("Titulo da playlist é obrigatório.");

            //RuleFor(x => x.Foto)
            //    .NotEmpty()
            //    .WithMessage("Foto da playlist é obrigatória.");

            RuleFor(x => x.Descricao)
                .NotEmpty()
                .WithMessage("Descrição da playlist é obrigatória.");
        }
    }
}
