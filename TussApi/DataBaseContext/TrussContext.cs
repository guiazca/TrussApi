using System;
using Microsoft.EntityFrameworkCore;
using TrussApi.DataBaseContext.Map;
using TrussApi.Models;

namespace TrussApi.DataBaseContext
{
	public class TrussContext : DbContext
	{
		public TrussContext(DbContextOptions<TrussContext> options)
			: base(options)
		{
		}

		public DbSet<ProductModel> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.ApplyConfiguration(new ProductMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}

