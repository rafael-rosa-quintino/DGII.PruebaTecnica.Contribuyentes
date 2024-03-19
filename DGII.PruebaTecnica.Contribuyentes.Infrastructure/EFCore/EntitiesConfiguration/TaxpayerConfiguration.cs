using DGII.PruebaTecnica.Contribuyentes.Domain.Aggregates.TaxpayerAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGII.PruebaTecnica.Contribuyentes.Infrastructure.EFCore.EntitiesConfiguration
{
    public class TaxpayerConfiguration : IEntityTypeConfiguration<Taxpayer>
    {
        public void Configure(EntityTypeBuilder<Taxpayer> builder)
        {
            builder
                .ToTable(nameof(Taxpayer))
                .HasKey(x=> x.Id);

        }
    }
}
