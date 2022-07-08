using AutoMapper;
using AVS.Banda.Application.DTOs;
using AVS.Banda.Domain.Entities;

namespace AVS.Banda.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Domain.Entities.Banda, BandaResponseDto>()
                .ForMember(x => x.Albuns, opt => opt.MapFrom(s => s.Albuns));
                //.ForMember(x => x.Albuns.Select(x => x.Musicas), opt => opt.MapFrom(s => s.Albuns.Select(x => x.Musicas)));


            CreateMap<Playlist, PlaylistResponseDto>();
            //.ForMember(x => x.Musicas, opt => opt.MapFrom(x => x.Musicas));

            CreateMap<Album, AlbumResponseDto>();
            //.ForMember(x => x.Musicas, opt => opt.MapFrom(x => x.Musicas));

            CreateMap<Musica, MusicaResponseDto>();
                //.ForPath(x => x.DuracaoFormatada, x => x.MapFrom(x => x.Duracao.Formatado));
                //.ForMember(x => x.Playlists, opt => opt.MapFrom(x => x.Playlists));
            
            CreateMap<MusicaPlaylist, MusicaPlaylistResponseDto>();
        }
    }
}
