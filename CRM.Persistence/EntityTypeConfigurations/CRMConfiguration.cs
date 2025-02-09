using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CRM.Domain;

namespace CRM.Persistence.EntityTypeConfigurations
{
    public class CRMConfiguration : IEntityTypeConfiguration<CoffeeCRM>
    {
        public void Configure(EntityTypeBuilder<CoffeeCRM> builder) 
        {
            builder.HasKey(k => k.Id);
            builder.HasIndex(k => k.Id).IsUnique();
            builder.Property(k => k.Title).HasMaxLength(250);
        }
    }
}
