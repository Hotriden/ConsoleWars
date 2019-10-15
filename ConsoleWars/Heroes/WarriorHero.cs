using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Heroes
{
    class WarriorHero : Hero, IHero
    {
        HeroType type;

        public WarriorHero(string name): base(name)
        {
            type = HeroType.Warrior;
        }

        public string Hit()
        {
            throw new NotImplementedException();
        }

        public string LevelUp()
        {
            Level += 1;
            Vitality += 2;
            Strength += 3;
            Mana += 1;
            Agility += 1;
            return String.Format($"Hero {NickName} get level {Level}! Features was upped.");
        }

        public string MoveOnLevel()
        {
            throw new NotImplementedException();
        }
    }
}
