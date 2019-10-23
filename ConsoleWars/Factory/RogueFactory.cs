using ConsoleWars.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Factory
{
    class RogueFactory:HeroFactory
    {
        public override Hero FactoryMethod(string name)
        {
            return new RogueHero(name);
        }
    }
}
