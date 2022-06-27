using AVS.Core.ObjDoinio;
using AVS.Core.ObjValor;
using FluentValidation;

namespace AVS.Banda.Domain.Entities
{
    public class Musica : Entity
    {
        public string Nome { get; private set; }
        public Duracao Duracao { get; private set; }
        public Guid AlbumId { get; private set; }
        public virtual Album Album { get; private set; }
        public virtual IList<MusicaPlaylist> Playlists { get; private set; }

        protected Musica()
        {
        }

        public Musica(Guid id, Guid albumId, string nome, int paramDuracao)
        {
            Id = id;
            AlbumId = albumId;
            Nome = nome;
            Duracao = new Duracao(paramDuracao);
            Playlists = new List<MusicaPlaylist>();
        }

        public override bool EhValido()
        {
            var validationResult = new MusicaValidator().Validate(this);
            return validationResult.IsValid;
        }
        public override void Validar() =>
            new MusicaValidator().ValidateAndThrow(this);
    }

    public class MusicaValidator : AbstractValidator<Musica>
    {
        public MusicaValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido.");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome da banda é obrigatório.");

            RuleFor(x => x.Duracao.Valor)
                .NotEmpty()
                .WithMessage("Tempo de duração é obrigatório.");
        }
    }
}
