using Faturi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faturi.Application.Beneficiarios.Commands
{
    public class BeneficiarioRemoveCommand : IRequest<Beneficiario>
    {
        public int Id { get; set; }

        public BeneficiarioRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
