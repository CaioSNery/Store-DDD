using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Mappings
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.Number)
            .IsRequired()
            .HasMaxLength(15);

            builder.Property(o => o.Date)
            .IsRequired();

            builder.Property(o => o.Status)
            .IsRequired();

            builder.Property(o => o.DeliveryFee)
            .HasColumnType("decimal(18,2)");

            builder.HasOne(c => c.Customer)
            .WithMany(c => c.Orders)
            .HasForeignKey(c => c.CustomerId);

            builder.HasMany(c => c.Items)
            .WithOne(c => c.Order)
            .HasForeignKey(c => c.OrderId)
            .OnDelete(DeleteBehavior.Cascade);



        }
    }
}