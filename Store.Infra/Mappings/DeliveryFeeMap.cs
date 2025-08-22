using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Mappings
{
    public class DeliveryFeeMap : IEntityTypeConfiguration<DeliveryFee>
    {
        public void Configure(EntityTypeBuilder<DeliveryFee> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Fee)
            .HasColumnType("decimal(18,2)");
        }
    }
}