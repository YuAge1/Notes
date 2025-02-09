using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain
{
    public class CoffeeCRM
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }    
        public string Detatils { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

    }
}
