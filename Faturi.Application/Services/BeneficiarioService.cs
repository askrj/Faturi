using AutoMapper;
using Faturi.Application.Beneficiarios.Commands;
using Faturi.Application.Beneficiarios.Queries;
using Faturi.Application.DTOs;
using Faturi.Application.Interfaces;
using MediatR;

namespace Faturi.Application.Services
{
    public class BeneficiarioService : IBeneficiarioService
    {

        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public BeneficiarioService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<BeneficiarioDTO>> GetBeneficiarios()
        {
            var beneficiarioQuery = new GetBeneficiarioQuerie();

            if (beneficiarioQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(beneficiarioQuery);

            return _mapper.Map<IEnumerable<BeneficiarioDTO>>(result);
        }


        public async Task<BeneficiarioDTO> GetById(int? id)
        {
            var beneficiarioByIdQuery = new GetBeneficiarioByIdQueries(id.Value);

            if (beneficiarioByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(beneficiarioByIdQuery);

            return _mapper.Map<BeneficiarioDTO>(result);
        }

        public async Task Add(BeneficiarioDTO beneficiarioDTO)
        {
            var beneficiarioCreateCommand = _mapper.Map<BeneficiarioCreateCommand>(beneficiarioDTO);
            await _mediator.Send(beneficiarioCreateCommand);
        }

        public async Task Remove(int? id)
        {
            var beneficiarioRemoveCommand = new BeneficiarioRemoveCommand(id.Value);
            if (beneficiarioRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(beneficiarioRemoveCommand);
        }

        public async Task Update(BeneficiarioDTO beneficiarioDTO)
        {
            var beneficiarioUpdateCommand = _mapper.Map<BeneficiarioUpdateCommand>(beneficiarioDTO);
            await _mediator.Send(beneficiarioUpdateCommand);
        }
    }
}
