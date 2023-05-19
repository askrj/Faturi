using Faturi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faturi.Application.Beneficiarios.Queries
{
    public class GetBeneficiarioByIdQueries : IRequest<Beneficiario>
    {
        public int Id { get; set; }

        public GetBeneficiarioByIdQueries(int id)
        {
            Id = id;
        }
    }
}
