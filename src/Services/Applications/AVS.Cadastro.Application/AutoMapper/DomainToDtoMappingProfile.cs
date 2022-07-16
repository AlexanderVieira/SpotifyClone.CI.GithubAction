using AutoMapper;
using AVS.Cadastro.Application.DTOs;
using AVS.Cadastro.Domain.Entities;

namespace AVS.Cadastro.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<Usuario, UsuarioResponseDto>()
                .ForPath(x => x.Email, opt => opt.MapFrom(x => x.Email.Address))
                .ForPath(x => x.Cpf, opt => opt.MapFrom(x => x.Cpf.Numero));                
        }
    }
}
