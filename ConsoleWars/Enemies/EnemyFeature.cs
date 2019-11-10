using ConsoleWars.Dungeons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Enemies
{
    public class EnemyFeature
    {
        public int HealPoint { get; set; }
        public int Experience { get; set; }
        public int Damage { get; set; }
        public string Name { get; set; }
        public Dungeon Dungeon { get; set; }
    }
}
