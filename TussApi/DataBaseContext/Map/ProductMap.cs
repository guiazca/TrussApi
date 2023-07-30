using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrussApi.Models;

namespace TrussApi.DataBaseContext.Map
{
	public class ProductMap : IEntityTypeConfiguration<ProductModel>
	{
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Code).IsRequired().HasMaxLength(255);
            builder.Property(x => x.price).IsRequired();
            builder.Property(x => x.linha).HasMaxLength(255);
            builder.Property(x => x.subLinha).HasMaxLength(255);
        }
    }
}

