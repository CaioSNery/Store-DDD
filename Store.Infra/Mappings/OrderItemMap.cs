using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Store.Domain.Entities;

namespace Store.Infra.Mappings
{
    public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
             .ValueGeneratedOnAdd();

            builder.Property(c => c.Price)
            .HasColumnType("decimal(18,2)");

            builder.Property(c => c.Quantity)
            .IsRequired();

            builder.HasOne(c => c.Order)
            .WithMany(c => c.Items)
            .HasForeignKey(c => c.OrderId);

        }
    }
}