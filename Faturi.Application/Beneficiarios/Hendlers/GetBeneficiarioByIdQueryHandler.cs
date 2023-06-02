using Faturi.Application.Beneficiarios.Queries;
using Faturi.Domain.Entities;
using Faturi.Domain.Interface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faturi.Application.Beneficiarios.Hendlers
{
    public class GetBeneficiarioByIdQueryHandler : IRequestHandler<GetBeneficiarioByIdQueries, Beneficiario>
    {
        private readonly IBeneficiarioRepository _beneficiarioRepository;

        public GetBeneficiarioByIdQueryHandler(IBeneficiarioRepository beneficiarioRepository)
        {
            _beneficiarioRepository = beneficiarioRepository;
        }


        public async Task<Beneficiario> Handle(GetBeneficiarioByIdQueries request, CancellationToken cancellationToken)
        {
            return await _beneficiarioRepository.GetByIdAsync(request.Id);
        }
    }
}
