using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bewerber.Models;

namespace Bewerber.Data
{
    public class StellenangeboteContext : DbContext
    {
        public StellenangeboteContext (DbContextOptions<StellenangeboteContext> options)
            : base(options)
        {
        }

        public DbSet<Bewerber.Models.Stellenangebote> Stellenanzeigen { get; set; }
    }
}
