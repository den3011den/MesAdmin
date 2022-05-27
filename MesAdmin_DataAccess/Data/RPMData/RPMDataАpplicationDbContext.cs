using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesAdmin_DataAccess.Data.RPMData
{
    public class RPMDataАpplicationDbContext : DbContext
    {
        public RPMDataАpplicationDbContext(DbContextOptions<RPMDataАpplicationDbContext> options) : base(options)
        {

        }
        public DbSet<ProcessResources> ProcessResourcesDbSet { get; set; }
    }
}
