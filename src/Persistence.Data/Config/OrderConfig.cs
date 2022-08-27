using Core.Model.Orders;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Data.Config
{
    public class OrderConfig
    {
        public OrderConfig(EntityTypeBuilder<Order> typeBuilder)
        {
            typeBuilder.Property(x => x.Subtotal).IsRequired();
        }
    }
}
