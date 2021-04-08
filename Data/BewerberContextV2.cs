using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bewerber.Data
{
    public class BewerberContextV2 : DbContext
    {
        public BewerberContextV2(DbContextOptions<BewerberContextV2> options)
            : base(options)
        {
        }

        public DbSet<Bewerber.Models.BewerberModelV2> BEWERBER { get; set; }

    }

}
