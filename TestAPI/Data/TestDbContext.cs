using Microsoft.EntityFrameworkCore;
using TestAPI.Models;
using System.Reflection.Metadata;
using System.Xml;

namespace TestAPI.Data
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Change the data types for the Migration, so that indexes can be created
            // The indexes are created by scripts
            //modelBuilder.Entity<EmailHistoryModel>()
            //    .Property(e => e.Reference).HasColumnType("VARCHAR").HasMaxLength(100);
        }
        public DbSet<CouponModel> Coupons { get; set; }
        public DbSet<CountryModel> Countries { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CouponCountryModel> CouponCountries { get; set; }
        public DbSet<CouponProductModel> CouponProducts { get; set; }
    }
}

