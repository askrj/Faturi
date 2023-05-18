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
        ApplicationDbContext _BeneficiarioContext;

        public BeneficiarioRepository(ApplicationDbContext context)
        {
            _BeneficiarioContext = context;
        }

        public async Task<Beneficiario> Create(Beneficiario beneficiario)
        {
            _BeneficiarioContext.Add(beneficiario);
            await _BeneficiarioContext.SaveChangesAsync();
            return beneficiario;
        }

        public async Task<IEnumerable<Beneficiario>> GetBeneficiario()
        {
            return await _BeneficiarioContext.Beneficiarios.ToListAsync();
        }

        public async Task<Beneficiario> GetBeneficiarioConvenioById(int? id)
        {
            return await _BeneficiarioContext.Beneficiarios.Include(c => c.Convenio).SingleOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Beneficiario> GetById(int? id)
        {
            return await _BeneficiarioContext.Beneficiarios.FindAsync(id);
        }


        public async Task<Beneficiario> Remove(Beneficiario beneficiario)
        {
            _BeneficiarioContext.Remove(beneficiario);
            await _BeneficiarioContext.SaveChangesAsync();
            return beneficiario;
        }

        public async Task<Beneficiario> Update(Beneficiario beneficiario)
        {
            _BeneficiarioContext.Update(beneficiario);
            await _BeneficiarioContext.SaveChangesAsync();
            return beneficiario;
        }
    }
}

