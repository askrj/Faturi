using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faturi.Application.Beneficiarios.Commands
{
    public class BeneficiarioUpdateCommand : BeneficiarioCommand
    {
        public int Id { get; set; }
    }
}
