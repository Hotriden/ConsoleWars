using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleWars.Heroes;

namespace ConsoleWars.Factory
{
    class MageFactory : HeroFactory
    {
        public override Hero FactoryMethod(string name)
        {
            return new MageHero(name);
        }
    }
}
