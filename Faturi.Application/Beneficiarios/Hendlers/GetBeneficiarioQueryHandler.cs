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
    public class GetBeneficiarioQueryHandler : IRequestHandler<GetBeneficiarioQuerie, IEnumerable<Beneficiario>>
    {
        private readonly IBeneficiarioRepository _beneficiarioRepository;

        public GetBeneficiarioQueryHandler(IBeneficiarioRepository beneficiarioRepository)
        {
            _beneficiarioRepository = beneficiarioRepository;
        }

        public async Task<IEnumerable<Beneficiario>> Handle(GetBeneficiarioQuerie request,
            CancellationToken cancellationToken)
        {
            return await _beneficiarioRepository.GetBeneficiario();
        }
    }
}
