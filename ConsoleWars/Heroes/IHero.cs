using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Heroes
{
    public interface IHero
    {
        void Hit();
        void LevelUp();
        void MoveOnLevel();
        void CreateHero();
        void HeroKilled();
        void GetDamage();
    }
}
