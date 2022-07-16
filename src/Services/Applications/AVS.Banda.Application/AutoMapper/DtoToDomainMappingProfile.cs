using AutoMapper;
using AVS.Banda.Application.DTOs;
using AVS.Banda.Domain.Entities;

namespace AVS.Banda.Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<BandaRequestDto, Domain.Entities.Banda>();                
            CreateMap<PlaylistRequestDto, Playlist>();
            CreateMap<AlbumRequestDto, Album>();
            CreateMap<MusicaRequestDto, Musica>()
                .ForPath(x => x.Duracao.Valor, x => x.MapFrom(x => x.Duracao));
            CreateMap<MusicaPlaylistRequestDto, MusicaPlaylist>();
        }
    }
}
