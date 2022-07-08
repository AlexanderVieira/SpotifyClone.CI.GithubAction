using AutoMapper;
using AVS.Cadastro.Application.DTOs;
using AVS.Cadastro.Domain.Entities;

namespace AVS.Cadastro.Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<UsuarioRequestDto, Usuario>()
                .ForPath(x => x.Email.Address, a => a.MapFrom(x => x.Email))
                .ForPath(x => x.Cpf.Numero, a => a.MapFrom(x => x.Cpf));                

        }
    }
}
