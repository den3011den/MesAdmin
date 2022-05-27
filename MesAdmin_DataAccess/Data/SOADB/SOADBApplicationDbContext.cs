using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesAdmin_DataAccess.Data.SOADB
{
    public class SOADBApplicationDbContext : DbContext
    {
        public SOADBApplicationDbContext(DbContextOptions<SOADBApplicationDbContext> options) : base(options) 
        {

        }
        public DbSet<Equipment> EquipmentDbSet { get; set; }

    }
}
