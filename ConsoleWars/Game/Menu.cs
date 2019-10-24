using ConsoleWars.Handlers;
using ConsoleWars.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Game
{
    public class Menu<T> where T:Hero
    {
        List<T> Heroes;
        public void CreateCharacter(HeroType characterType, string nickName, ConsoleWarsStateHandler created, 
            ConsoleWarsStateHandler killed, ConsoleWarsStateHandler gotLevel, 
            ConsoleWarsStateHandler moveToDung, ConsoleWarsStateHandler hited,
            ConsoleWarsStateHandler attacked, ConsoleWarsStateHandler heroInfo)
        {
            T newHero = null;

            switch (characterType)
            {
                case HeroType.Warrior:
                    newHero = new WarriorHero(nickName) as T;
                    break;
                case HeroType.Mage:
                    newHero = new MageHero(nickName) as T;
                    break;
                case HeroType.Rogue:
                    newHero = new RogueHero(nickName) as T;
                    break;
            }

            if (newHero == null)
                throw new Exception("Error! Hero doesn't created!");
            if (Heroes == null)
                Heroes = new List<T> { newHero };
            else
            {
                Heroes.Add(newHero);
            }

            newHero.Created += created;
            newHero.Attacked += attacked;
            newHero.GotLevel += gotLevel;
            newHero.HeroInfo += heroInfo;
            newHero.Hited += hited;
            newHero.Killed += killed;
            newHero.MovedToDungeon += moveToDung;

            newHero.CreateHero();
        }

        public void Create(string nickName, HeroType type)
        {
            //T newHero = Fin
        }

        public void AllCharacters()
        {
            throw new NotImplementedException();
        }

        public Hero FindCharacter(string nickName)
        {
            foreach(var b in Heroes)
            {
                if (b.NickName == nickName)
                    return b;
            }
            return null;
        }
    }
}
