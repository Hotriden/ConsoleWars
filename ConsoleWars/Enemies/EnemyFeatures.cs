using ConsoleWars.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Enemies
{
    class EnemyFeatures
    {
        public Enemy Enemy { get; set; }

        public bool IsAlive { get; set; }

        public int HealPoints { get; set; }

        public int Level { get; set; }

        public int GainExperience { get; set; }

        public int Damage { get; set; }

        public Level Location { get; set; }
    }
}
