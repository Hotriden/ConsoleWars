using ConsoleWars.Commands;
using ConsoleWars.Content;
using ConsoleWars.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Dungeons
{
    class EarthHallsDungeon:Dungeon
    {
        private IList<EarthElementalEnemy> Enemies;

        public EarthHallsDungeon()
        {
            Enemies = new List<EarthElementalEnemy>();
            for (int i = 0; i < RandomGenerator.RandomMethod(1,5); i++)
            {
                Enemies.Add(new EarthElementalEnemy());
            }
        }

        public override string DungeonName()
        {
            throw new NotImplementedException();
        }

        public override string Intro()
        {
            return DungeonInfo.EarthHallsDungeon();
        }

        public override string MeetEnemy()
        {
            throw new NotImplementedException();
        }
    }
}
