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
    public class BeneficiarioCreateCommandHandler : IRequestHandler<BeneficiarioCreateCommand, Beneficiario>
    {
        private readonly IBeneficiarioRepository _beneficiarioRepository;

        public BeneficiarioCreateCommandHandler(IBeneficiarioRepository beneficiarioRepository)
        {
            _beneficiarioRepository = beneficiarioRepository;
        }

        public async Task<Beneficiario> Handle(BeneficiarioCreateCommand request, CancellationToken cancellationToken)
        {
            var beneficiario = new Beneficiario(request.Nome, request.Carteira, request.CPF, request.Nascimento, request.Foto);

            if (beneficiario == null)
            {
                throw new ApplicationException($"Error createing entity. ");
            }
            else
            {
                beneficiario.ConvenioId = request.ConvevioId;
                return await _beneficiarioRepository.Create(beneficiario);
            }
        }
    }
}
