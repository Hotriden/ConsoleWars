using ConsoleWars.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Dungeons
{
    public abstract class Dungeon
    {
        public abstract string DungeonName();
        public abstract string Intro();
        public abstract string MeetEnemy();
    }
}
