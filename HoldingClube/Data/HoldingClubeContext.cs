using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HoldingClube.Models
{
    public class HoldingClubeContext : DbContext
    {
        public HoldingClubeContext (DbContextOptions<HoldingClubeContext> options)
            : base(options)
        {
        }

        public DbSet<HoldingClube.Models.Register> Register { get; set; }
    }
}
