using AVS.Banda.Domain;
using AVS.Cadastro.Domain.Entities;
using AVS.Core.Mensagens;
using FluentValidation;

namespace AVS.Cadastro.Application.DTOs
{
    public class UsuarioDTO : MensagemResposta
    {
        public Guid Id {  get; set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }
        public bool Ativo { get; private set; }
        public string Foto { get; private set; }        
        public List<PlaylistDTO> Playlists { get; set; }

        public static UsuarioDTO ConverteParaUsuarioDTO(Usuario usuario)
        {
            var usuarioDTO = new UsuarioDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email.Address,
                Cpf = usuario.Cpf.Numero,
                Ativo = usuario.Ativo,                
                Foto = usuario.Foto,
                Playlists = new List<PlaylistDTO>()
            };

            foreach (var item in usuario.Playlists)
            {
                var playlistDTO = new PlaylistDTO
                {
                    Id=item.Id,
                    Titulo = item.Titulo,
                    Descricao = item.Descricao,
                    Foto = item.Foto,
                    Musicas = new List<MusicaDTO>(),
                    UsuarioId = item.UsuarioId
                };

                foreach (var musica in item.Musicas)
                {
                    playlistDTO.Musicas.Add(new MusicaDTO
                    {
                        Nome = musica.Nome,
                        Duracao = musica.Duracao.Valor,
                        PlaylistId = playlistDTO.Id
                    });
                }

                usuarioDTO.Playlists.Add(playlistDTO);
            }

            return usuarioDTO;
        }

        public static Usuario ConverteParaUsuario(UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario(usuarioDTO.Id, usuarioDTO.Nome, usuarioDTO.Email, usuarioDTO.Email, usuarioDTO.Foto, usuarioDTO.Ativo);
            var musicas = new List<Musica>();
            foreach (var item in usuarioDTO.Playlists)
            {
                var playlist = new Playlist(item.Id, usuario.Id, item.Titulo, item.Descricao, item.Foto);
                foreach (var musica in item.Musicas)
                {
                    musicas.Add(new Musica(musica.Id, playlist.Id, musica.Nome, musica.Duracao));
                    playlist.AtualizarMusicas(musicas);
                }
                
                usuario.AdicionarPlaylist(playlist);
            }
            
            return usuario;
        }
        public override bool EhValido()
        {
            ValidationResult = new UsuarioDTOValidator().Validate(this);
            return ValidationResult.IsValid;
        }       

    }

    public class UsuarioDTOValidator : AbstractValidator<UsuarioDTO>
    {
        public UsuarioDTOValidator()
        {
            RuleFor(x => x.Id)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do usuário inválido.");

            RuleFor(x => x.Nome)
                .NotEmpty()
                .WithMessage("Nome é obrigatório.")
                .Length(2, 150)
                .WithMessage("O Nome deve ter entre 2 a 150 caracteres.");

            RuleFor(x => x.Cpf)
                .NotEmpty()
                .WithMessage("Documento é obrigatório.")
                .Must(Core.ObjValor.Cpf.ValidarCpf)
                .WithMessage("Documento Inválido.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("E-mail é obrigatório.")
                .Must(Core.ObjValor.Email.ValidarEmail)
                .WithMessage("E-mail inválido.");

            RuleFor(x => x.Foto)
                .NotEmpty()
                .WithMessage("Foto do usuário inválida.");

        }

    }
}
