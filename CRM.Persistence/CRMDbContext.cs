using CRM.Application.Interfaces;
using CRM.Domain;
using CRM.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CRM.Persistence
{
    public class CRMDbContext : DbContext, ICRMDbContext
    {
        public DbSet<CoffeeCRM> Notes { get; set; }

        public CRMDbContext(DbContextOptions<CRMDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CRMConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
