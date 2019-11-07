using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.DAL.Entities
{
    public class HeroFeature
    {
        public int Id { get; set; }

        public string NickName { get; set; }

        public string HeroType { get; set; }

        public bool IsAlive { get; set; }

        public int Strength { get; set; }

        public int Vitality { get; set; }

        public int HealPoints { get; set; }

        public int Agility { get; set; }

        public int Mana { get; set; }

        public int Level { get; set; }

        public int Experience { get; set; }

        public int ExperienceBar { get; set; }

        public int Damage { get; set; }
    }
}
