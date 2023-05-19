using Faturi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faturi.Application.Beneficiarios.Queries
{
    public class GetBeneficiarioQuerie : IRequest<IEnumerable<Beneficiario>>
    {
    }
}
