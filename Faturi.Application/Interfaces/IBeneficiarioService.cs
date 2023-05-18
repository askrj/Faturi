using Faturi.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faturi.Application.Interfaces
{
    public interface IBeneficiarioService
    {
        Task<IEnumerable<BeneficiarioDTO>> GetBeneficiarios();
        Task<BeneficiarioDTO> GetById(int? id);
        Task<BeneficiarioDTO> GetBeneficiarioConvenio(int? id);
        Task Add(BeneficiarioDTO beneficiarioDTO);
        Task Update(BeneficiarioDTO beneficiarioDTO);
        Task Remove(int? id);
    }
}
