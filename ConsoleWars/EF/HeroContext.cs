using ConsoleWars.Heroes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.EF
{
    class HeroContext : DbContext
    {
        public DbSet<Features> Features { get; set; }

    }
}
