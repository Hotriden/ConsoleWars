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
    class GoblinFieldDungeon: Dungeon
    {
        private IList<GoblinEnemy> Enemies;

        public GoblinFieldDungeon()
        {
            Enemies = new List<GoblinEnemy>();
            for (int i = 0; i < RandomGenerator.RandomMethod(1, 5); i++)
            {
                Enemies.Add(new GoblinEnemy());
            }
        }

        public override string DungeonName()
        {
            throw new NotImplementedException();
        }

        public override string Intro()
        {
            return DungeonInfo.GoblinFieldInfo();
        }

        public override string MeetEnemy()
        {
            throw new NotImplementedException();
        }
    }
}
