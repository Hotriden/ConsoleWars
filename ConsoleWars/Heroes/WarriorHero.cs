using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Heroes
{
    class WarriorHero:Hero,IHero
    {
        public WarriorHero(string nickName)
        {
            NickName = nickName;
            HeroType = "Warrior";
            IsAlive = true;
            Strength = 35;
            Vitality = 25;
            HealPoints = Vitality*2;
            Agility = 15;
            Mana = 10;
            Level = 1;
            Experience = 0;
            ExperienceBar = 100;
            Damage = 20;
        }
    }
}
