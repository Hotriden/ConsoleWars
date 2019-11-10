using ConsoleWars.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Dungeons.Factory
{
    class ConcreteFactory : DungeronFactory
    {
        public override Dungeon CreateDungeon()
        {
            return new EarthHallsDungeon();
        }
    }
}
