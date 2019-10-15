using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleWars.Heroes;

namespace ConsoleWars.Factory
{
    class WarriorFactory : HeroFactory
    {
        public override IHero FactoryMethod(string name)
        {
            return new WarriorHero(name);
        }
    }
}
