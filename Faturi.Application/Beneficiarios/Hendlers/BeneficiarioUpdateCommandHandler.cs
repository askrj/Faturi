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
    public class BeneficiarioUpdateCommandHandler : IRequestHandler<BeneficiarioUpdateCommand, Beneficiario>
    {
        private readonly IBeneficiarioRepository _beneficiarioRepository;

        public BeneficiarioUpdateCommandHandler(IBeneficiarioRepository beneficiarioRepository)
        {
            _beneficiarioRepository = beneficiarioRepository ??
            throw new ArgumentNullException(nameof(beneficiarioRepository));
        }

        public async Task<Beneficiario> Handle(BeneficiarioUpdateCommand request, CancellationToken cancellationToken)
        {
            var beneficiario = await _beneficiarioRepository.GetByIdAsync(request.Id);

            if (beneficiario == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                beneficiario.update(request.Nome, request.Carteira, request.CPF, request.Nascimento, request.Foto, 
                                     request.ConvevioId);

                return await _beneficiarioRepository.UpdateAsync(beneficiario);

            }
        }
    }
}
