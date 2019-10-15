using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Heroes
{
    class RogueHero:Hero,IHero
    {
        HeroType type;

        public RogueHero(string name):base(name)
        {
            type = HeroType.Rogue;
        }

        public string Hit()
        {
            throw new NotImplementedException();
        }

        public string LevelUp()
        {
            throw new NotImplementedException();
        }

        public string MoveOnLevel()
        {
            throw new NotImplementedException();
        }
    }
}
