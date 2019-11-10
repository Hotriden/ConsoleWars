using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Heroes
{
    class MageHero:Hero,IHero
    {
        public MageHero(string nickName)
        {
            NickName = nickName;
            HeroType = "Mage";
            IsAlive = true;
            Strength = 15;
            Vitality = 20;
            HealPoints = Vitality*2;
            Agility = 15;
            Mana = 35;
            Level = 1;
            Experience = 0;
            ExperienceBar = 100;
            Damage = 25;
        }
    }
}
