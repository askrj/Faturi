using Faturi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faturi.Domain.Interface
{
    public interface IConvenioRepository
    {
        Task<IEnumerable<Convenio>> GetConvenio();
        Task<Convenio> GetById(int? id);
        Task<Convenio> Create(Convenio convenio);
        Task<Convenio> Update(Convenio convenio);
        Task<Convenio> Remove(Convenio convenio);
    }
}
