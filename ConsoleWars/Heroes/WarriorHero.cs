using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Heroes
{
    class WarriorHero : Hero, IHero
    {
        HeroType type;

        public WarriorHero(string name): base(name)
        {
            type = HeroType.Warrior;
        }
    }
}
