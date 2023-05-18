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
    public class ConvenioConfiguration : IEntityTypeConfiguration<Convenio>
    {
        public void Configure(EntityTypeBuilder<Convenio> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.ANS).HasMaxLength(8).IsRequired();

            builder.HasData(
              new Convenio(1, "417661", "Fisco Saude"),
              new Convenio(2, "101010", "SASSEPE"),
              new Convenio(3, "555555", "Particular")
                );
        }
    }
}
