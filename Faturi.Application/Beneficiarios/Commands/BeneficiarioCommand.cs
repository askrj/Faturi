using Faturi.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faturi.Application.Beneficiarios.Commands
{
    public abstract class BeneficiarioCommand : IRequest<Beneficiario>
    {
        public string Nome { get; set; }
        public string Carteira { get; set; }
        public string CPF { get; set; }
        public DateTime Nascimento { get; set; }
        public string Foto { get;  set; }

        public int ConvevioId { get; set; }
    }
}
