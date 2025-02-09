using CRM.Domain;
using Microsoft.EntityFrameworkCore;

namespace CRM.Application.Interfaces
{
    public interface ICRMDbContext
    {
        DbSet<CoffeeCRM> Notes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
