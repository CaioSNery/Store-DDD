using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(30)
            ;

            builder.Property(p => p.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)");

            builder.Property(p => p.Active)
            .IsRequired();

        }
    }
}