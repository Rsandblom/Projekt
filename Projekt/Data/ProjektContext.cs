using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Projekt.Models
{
    public class ProjektContext : DbContext
    {
        public ProjektContext (DbContextOptions<ProjektContext> options)
            : base(options)
        {
        }

        public DbSet<Projekt.Models.DiningExperience> DiningExperience { get; set; }
    }
}
