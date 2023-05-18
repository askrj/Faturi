using Faturi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faturi.Infra.Data.EntitiesConfiguration
{
    public class BeneficiarioConfiguration : IEntityTypeConfiguration<Beneficiario>
    {
        public void Configure(EntityTypeBuilder<Beneficiario> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(200).IsRequired();
            builder.Property(p => p.Carteira).HasMaxLength(50).IsRequired();
            builder.Property(p => p.CPF).HasMaxLength(15).IsRequired();

            builder.HasOne(e => e.Convenio).WithMany(e => e.beneficiarios).HasForeignKey(e => e.ConvenioId);
        }
    }
}
