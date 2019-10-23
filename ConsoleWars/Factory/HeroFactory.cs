using ConsoleWars.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Factory
{
    abstract class HeroFactory
    {
        public abstract Hero FactoryMethod(string name);
    }
}
