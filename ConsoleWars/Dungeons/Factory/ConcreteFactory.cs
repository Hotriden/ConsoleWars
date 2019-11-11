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
        public override Dungeon CreateDungeon(int dungeon)
        {
            if(dungeon==1)
                return new GoblinFieldDungeon();
            if (dungeon == 2)
                return new OrcFortDungeon();
            if (dungeon == 3)
                return new TrollJungleDungeon();
            if (dungeon == 4)
                return new EarthHallsDungeon();
            if (dungeon == 5)
                return new GiantCanyonDungeon();
            if (dungeon == 6)
                return new WaterHallsDungeon();
            if (dungeon == 7)
                return new FireHallsDungeon();
            if (dungeon == 8)
                return new MoltenCoreDungeon();
            else
            {
                return null;
            }
        }
    }
}
