using ConsoleWars.Factory;
using ConsoleWars.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Game
{
    public enum CharacterType
    {
        Warrior,
        Mage,
        Rogue
    }

    public class Menu<T> where T:Hero
    {
        List<T> Heroes;

        public void MainMenu(CharacterType characterType, HeroStateHandler created, HeroStateHandler killed,
            HeroStateHandler gotLevel, HeroStateHandler moveToDung, HeroStateHandler hited, 
            HeroStateHandler attacked, HeroStateHandler heroInfo)
        {
            T newHero = null;

            switch (heroType)
            {
                case HeroType.Warrior:
                    newHero = new WarriorFactory
            }
        }
    }
}
