using AutoMapper;
using Faturi.Application.Beneficiarios.Commands;
using Faturi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faturi.Application.Mappings
{
    internal class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<BeneficiarioDTO, BeneficiarioCreateCommand>();
            CreateMap<BeneficiarioDTO, BeneficiarioUpdateCommand>();
        }
    }
}
