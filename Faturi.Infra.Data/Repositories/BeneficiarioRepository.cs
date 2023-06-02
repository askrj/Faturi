using Faturi.Domain.Entities;
using Faturi.Domain.Interface;
using Faturi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faturi.Infra.Data.Repositories
{
    public class BeneficiarioRepository : IBeneficiarioRepository
    {
        ApplicationDbContext _beneficiarioContext;

        public BeneficiarioRepository(ApplicationDbContext context)
        {
            _beneficiarioContext = context;
        }

        public async Task<Beneficiario> CreateAsync(Beneficiario beneficiario)
        {
            _beneficiarioContext.Add(beneficiario);
            await _beneficiarioContext.SaveChangesAsync();
            return beneficiario;
        }

        public async Task<IEnumerable<Beneficiario>> GetBeneficiarioAsync()
        {
            return await _beneficiarioContext.Beneficiarios.ToListAsync();
        }


        public async Task<Beneficiario> GetByIdAsync(int? id)
        {
            //return await _beneficiarioContext.Beneficiarios.FindAsync(id);

            return await _beneficiarioContext.Beneficiarios.Include(c => c.Convenio)
                   .SingleOrDefaultAsync(p => p.Id == id);
        }


        public async Task<Beneficiario> RemoveAsync(Beneficiario beneficiario)
        {
            _beneficiarioContext.Remove(beneficiario);
            await _beneficiarioContext.SaveChangesAsync();
            return beneficiario;
        }

        public async Task<Beneficiario> UpdateAsync(Beneficiario beneficiario)
        {
            _beneficiarioContext.Update(beneficiario);
            await _beneficiarioContext.SaveChangesAsync();
            return beneficiario;
        }
    }
}

