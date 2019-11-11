using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Dungeons
{
    public abstract class DungeronFactory
    {
        public abstract Dungeon CreateDungeon(int dungeon);
    }
}
