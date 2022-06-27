using AVS.Banda.Domain;
using AVS.Banda.Domain.AppServices.DTOs;
using AVS.Banda.Domain.Entities;
using AVS.Cadastro.Domain.Entities;
using FluentValidation;

namespace AVS.Cadastro.Application.DTOs
{
    public class UsuarioDTO
    {
        public Guid Id {  get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public bool Ativo { get; set; }
        public string? Foto { get; set; }        
        public IList<PlaylistDTO> Playlists { get; set; }

        public static UsuarioDTO ConverterParaUsuarioDTO(Usuario usuario)
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

            if (usuario.Playlists != null && usuario.Playlists.Count > 0)
            {
                foreach (var item in usuario.Playlists)
                {
                    var playlistDTO = new PlaylistDTO(item.Id, item.UsuarioId, item.Titulo, item.Descricao, item.Foto);
                    
                    if (item.Musicas != null && item.Musicas.Count > 0)
                    {
                        foreach (var musica in item.Musicas)
                        {
                            //playlistDTO.Musicas.Add(new MusicaDTO(musica.Id, 
                            //    musica.AlbumId, musica.Nome, musica.Duracao.Valor));                            
                        }
                    }
                    usuarioDTO.Playlists.Add(playlistDTO);
                }
            }
            
            return usuarioDTO;
        }

        public static Usuario ConverterParaUsuario(UsuarioDTO usuarioDTO)
        {
            var usuario = new Usuario(usuarioDTO.Id, 
                usuarioDTO.Nome, usuarioDTO.Email, usuarioDTO.Cpf, usuarioDTO.Foto, usuarioDTO.Ativo);           
            
            if (usuarioDTO.Playlists != null && usuario.Playlists.Count > 0)
            {
                var musicas = new List<Musica>();
                foreach (var item in usuarioDTO.Playlists)
                {
                    var playlist = new Playlist(item.Id, usuario.Id, item.Titulo, item.Descricao, item.Foto);
                    if (item.Musicas != null && item.Musicas.Count > 0)
                    {
                        foreach (var musica in item.Musicas)
                        {
                            //musicas.Add(new Musica(musica.Id, musica.AlbumId, musica.Nome, musica.Duracao));
                            //playlist.AtualizarMusicas(musicas);
                        }                        
                    }
                    usuario.AdicionarPlaylist(playlist);
                }
            }            
            
            return usuario;
        }
        public bool EhValido()
        {
            var validationResult = new UsuarioDTOValidator().Validate(this);
            return validationResult.IsValid;
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
