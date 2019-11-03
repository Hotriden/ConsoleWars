using ConsoleWars.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.DAL.EF
{
    class HeroContext : DbContext
    {
        public DbSet<HeroFeature> Features { get; set; }

    }
}
