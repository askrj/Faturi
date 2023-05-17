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
        Task<IEnumerable<Beneficiario>> GetConvenio();
        Task<Beneficiario> GetById(int? id);
        Task<Beneficiario> GetBeneficiarioConvenioById(int? id);
        Task<Beneficiario> Create(Beneficiario beneficiario);
        Task<Beneficiario> Update(Beneficiario beneficiario);
        Task<Beneficiario> Remove(Beneficiario beneficiario);
    }
}
