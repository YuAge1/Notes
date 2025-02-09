using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(CRMDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
