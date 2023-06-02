using Faturi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faturi.Domain.Interface
{
    public interface IBeneficiarioRepository
    {
        Task<IEnumerable<Beneficiario>> GetBeneficiarioAsync();
        Task<Beneficiario> GetByIdAsync(int? id);
        Task<Beneficiario> CreateAsync(Beneficiario beneficiario);
        Task<Beneficiario> UpdateAsync(Beneficiario beneficiario);
        Task<Beneficiario> RemoveAsync(Beneficiario beneficiario);
    }
}
