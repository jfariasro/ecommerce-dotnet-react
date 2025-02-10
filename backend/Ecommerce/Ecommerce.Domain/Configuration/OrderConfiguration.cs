using Ecommerce.Domain.Modules.Order.Enum;
using Ecommerce.Domain.Modules.Order.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Configuration;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{

    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.OwnsOne(o => o.OrderAddress, x =>
        {
            x.WithOwner();
        });

        builder.HasMany(o => o.OrderItems).WithOne()
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(s => s.OrderStatus).HasConversion(
            o => o.ToString(),
            o => (OrderStatus)Enum.Parse(typeof(OrderStatus), o)
        );
    }
}
