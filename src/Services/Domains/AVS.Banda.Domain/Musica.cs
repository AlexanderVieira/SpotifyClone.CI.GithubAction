using AVS.Core.ObjDoinio;
using AVS.Core.ObjValor;
using FluentValidation;

namespace AVS.Banda.Domain
{
    public class Musica : Entity
    {
        public string Nome { get; set; }
        public Duracao Duracao { get; set; }
        public Guid PlaylistId { get; set; }

        protected Musica()
        {
        }

        public Musica(Guid id, Guid playlistId, string nome, int paramDuracao)
        {
            Id = id;
            PlaylistId = playlistId;
            Nome = nome;
            Duracao = new Duracao(paramDuracao);
        }

        public override bool EhValido()
        {
            var validationResult = new MusicaValidator().Validate(this);
            return validationResult.IsValid;
        }
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
                .WithMessage("Nome da banda inválido.");
            
            RuleFor(x => x.Duracao.Valor)
                .NotEmpty()
                .WithMessage("Tempo de duração inválido.");            
        }
    }
}
