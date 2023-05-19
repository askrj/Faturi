using Faturi.Application.Beneficiarios.Commands;
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
    public class BeneficiarioRemoveCommandHandler : IRequestHandler<BeneficiarioRemoveCommand, Beneficiario>
    {
        private readonly IBeneficiarioRepository _beneficiarioRepository;

        public BeneficiarioRemoveCommandHandler(IBeneficiarioRepository beneficiarioRepository)
        {
            _beneficiarioRepository = beneficiarioRepository ??
            throw new ArgumentNullException(nameof(beneficiarioRepository));
        }

        public async Task<Beneficiario> Handle(BeneficiarioRemoveCommand request, CancellationToken cancellationToken)
        {
            var beneficiario = await _beneficiarioRepository.GetById(request.Id);

            if (beneficiario == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                var result = await _beneficiarioRepository.Remove(beneficiario);
                return result;

            }
        }
    }
}
