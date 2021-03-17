using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bewerber.Models;

namespace Bewerber.Data
{
    public class BewerberContext : DbContext
    {
        public BewerberContext (DbContextOptions<BewerberContext> options)
            : base(options)
        {
        }

        public DbSet<Bewerber.Models.BewerberModel> uebersicht { get; set; }

    }


}
