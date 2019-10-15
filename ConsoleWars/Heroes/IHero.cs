using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Heroes
{
    interface IHero
    {
        string Hit();
        string LevelUp();
        string MoveOnLevel();
        string CreateHero();
    }
}
