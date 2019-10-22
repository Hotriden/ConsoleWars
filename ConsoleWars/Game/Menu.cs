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

        public void MainMenu(CharacterType characterType, string nickName, HeroStateHandler created, HeroStateHandler killed,
            HeroStateHandler gotLevel, HeroStateHandler moveToDung, HeroStateHandler hited, 
            HeroStateHandler attacked, HeroStateHandler heroInfo)
        {
            T newHero = null;

            switch (characterType)
            {
                case CharacterType.Warrior:
                    WarriorFactory warriorFactory = new WarriorFactory();
                    newHero = warriorFactory.FactoryMethod(nickName) as T;
                    break;

                case CharacterType.Mage:
                    MageFactory mageFactory = new MageFactory();
                    newHero = mageFactory.FactoryMethod(nickName) as T;
                    break;

                case CharacterType.Rogue:
                    RogueFactory rogueFactory = new RogueFactory();
                    newHero = rogueFactory.FactoryMethod(nickName) as T;
                    break;

            }
            if(newHero == null)
            {
                throw new Exception("Something goes wrong...");
            }
            if(Heroes == null)
            {
                Heroes = new List<T>() { newHero };
            }
            else
            {
                Heroes.Add(newHero);
            }

            newHero.Attacked += NewHero_Attacked;
            newHero.Created += NewHero_Created;
            newHero.GotLevel += NewHero_GotLevel;
            newHero.HeroInfo += NewHero_HeroInfo;
            newHero.Hited += NewHero_Hited;
            newHero.Killed += NewHero_Killed;
            newHero.MovedToDungeon += NewHero_MovedToDungeon;
        }

        private void NewHero_MovedToDungeon(object s, HeroEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void NewHero_Killed(object s, HeroEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void NewHero_Hited(object s, HeroEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void NewHero_HeroInfo(object s, HeroEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void NewHero_GotLevel(object s, HeroEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void NewHero_Created(object s, HeroEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void NewHero_Attacked(object s, HeroEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
