using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Heroes
{
    class MageHero : Hero, IHero
    {
        HeroType type;

        public MageHero(string name) : base(name)
        {
            type = HeroType.Mage;
        }
    }
}
