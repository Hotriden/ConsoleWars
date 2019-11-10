using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Heroes
{
    class RogueHero:Hero,IHero
    {
        public RogueHero(string nickName)
        {
            NickName = nickName;
            HeroType = "Rogue";
            IsAlive = true;
            Strength = 20;
            Vitality = 25;
            HealPoints = Vitality * 2;
            Agility = 30;
            Mana = 15;
            Level = 1;
            Experience = 0;
            ExperienceBar = 100;
            Damage = 30;
        }
    }
}
