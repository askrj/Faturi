using AutoMapper;
using Faturi.Application.DTOs;
using Faturi.Domain.Entities;

namespace Faturi.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Convenio, ConvenioDTO>().ReverseMap();
            CreateMap<Beneficiario, BeneficiarioDTO>().ReverseMap();
        }
    }
}
