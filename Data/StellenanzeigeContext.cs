using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bewerber.Models;

namespace Bewerber.Data
{
    public class StellenanzeigeContext : DbContext
    {
        public StellenanzeigeContext(DbContextOptions<StellenanzeigeContext> options)
            : base(options)
        {
        }

        public DbSet<Bewerber.Models.Stellenanzeigen> Stellenanzeigen { get; set; }

      
    }


}


