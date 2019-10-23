using ConsoleWars.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Dungeons
{
    class EarthHallsDungeon
    {
        List<EarthElementalEnemy> EarthElementals;

        public EarthHallsDungeon(int times)
        {
            for (int i = 0; i < times; i++)
            {
                EarthElementals.Add(new EarthElementalEnemy());
            }
        }
    }
}
