using Faturi.Domain.Entities;
using Faturi.Domain.Interface;
using Faturi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faturi.Infra.Data.Repositories
{
    public class ConvenioRepository : IConvenioRepository
    {
        ApplicationDbContext _ConvenioContext;

        public ConvenioRepository(ApplicationDbContext context)
        {
            _ConvenioContext= context;
        }
        public async Task<Convenio> Create(Convenio convenio)
        {
            _ConvenioContext.Add(convenio);
            await _ConvenioContext.SaveChangesAsync();
            return convenio;
        }

        public async Task<Convenio> GetById(int? id)
        {
            return await _ConvenioContext.Convenios.FindAsync(id);
        }

        public async Task<IEnumerable<Convenio>> GetConvenio()
        {
            return await _ConvenioContext.Convenios.ToListAsync();
        }

        public async Task<Convenio> Remove(Convenio convenio)
        {
            _ConvenioContext.Remove(convenio);
            await _ConvenioContext.SaveChangesAsync();
            return convenio;
        }

        public async Task<Convenio> Update(Convenio convenio)
        {
            _ConvenioContext.Update(convenio);
            await _ConvenioContext.SaveChangesAsync();
            return convenio;
        }
    }
}
