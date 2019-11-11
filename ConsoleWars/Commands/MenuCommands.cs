using ConsoleWars.Content;
using ConsoleWars.DAL.Interfaces;
using ConsoleWars.Dungeons;
using ConsoleWars.Dungeons.Factory;
using ConsoleWars.Game;
using ConsoleWars.Handlers;
using ConsoleWars.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Commands
{
    internal class MenuCommands
    {
        internal void MainMenu()
        {
            Menu menu = new Menu("HeroContext");
            bool alive = true;
            while (alive == true)
            {
                Console.WriteLine("Make your choise");
                Console.WriteLine("1:Create new hero\r\n2:Start game\r\n3:Show all characters\r\n4:Close game");
                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());

                    switch (command)
                    {
                        case 1:
                            CreateCharacter(menu);
                            break;
                        case 2:
                            ChooseHero(menu);
                            break;
                        case 3:
                            ShowAll(menu);
                            break;
                        case 4:
                            alive = false;
                            continue;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void CreateCharacter(Menu menu)
        {
            Console.WriteLine("Input character nickname");
            string name = Convert.ToString(Console.ReadLine());
            HeroEntity hero = new HeroEntity();
            if (name == null)
            {
                Console.WriteLine("Invalid nickname input");
                CreateCharacter(menu);
            }
            Console.WriteLine("Choose type of character\r\n1: Warrior\r\n2: Mage\r\n3: Rogue");
            int com = Convert.ToInt32(Console.ReadLine());
            if (com == 1)
            {
                hero = new WarriorHero(name);
            }
            else if (com == 2)
            {
                hero = new MageHero(name);
            }
            else if (com == 3)
            {
                hero = new RogueHero(name);
            }
            else
            {
                Console.WriteLine("Invalid cast");
                CreateCharacter(menu);
            }
            Console.WriteLine(menu.NewHero(hero));
            AfterCreating(hero);
        }

        private void AfterCreating(HeroEntity hero)
        {
            Console.WriteLine("To start game press 1\r\nBack to main menu press 2");
            int com = Convert.ToInt32(Console.ReadLine());
            if (com == 1)
                StartGame(hero, KilledStateHandler, GetLevelStateHandler, MoveToDungStateHandler, HitStateHandler, GetDamageStateHandler);
            else if (com == 2)
            {
                MainMenu();
            }
            else
            {
                Console.WriteLine("Invalid operation. Try again!");
                AfterCreating(hero);
            }
        }

        private void ChooseHero(Menu menu)
        {
            Console.WriteLine("Input character nickname:");
            string input = Console.ReadLine();
            var hero = menu.FindCharacter(input);
            if (hero == null)
            {
                Console.WriteLine("Character with such name doesn't exist");
                MainMenu();
            }
            else
            {
                StartGame(hero, KilledStateHandler, GetLevelStateHandler, 
                    MoveToDungStateHandler, HitStateHandler, GetDamageStateHandler);
            }
        }

        private void StartGame(HeroEntity hero, ConsoleWarsStateHandler killed, ConsoleWarsStateHandler GetLevel,
            ConsoleWarsStateHandler MoveToDung, ConsoleWarsStateHandler Hit, ConsoleWarsStateHandler GetDamage)
        {
            Hero player = (Hero)hero;
            player.Killed += killed;
            player.GotLevel += GetLevel;
            player.Attacked += Hit;
            player.MovedToDungeon += MoveToDung;
            player.Hited += GetDamage;

            if (hero.HeroType == "Warrior")
                player = new WarriorHero(hero.NickName);
            if (hero.HeroType == "Mage")
                player = new MageHero(hero.NickName);
            if (hero.HeroType == "Rogue")
                player = new RogueHero(hero.NickName);
            else
            {
                Console.WriteLine("Some thing goes wrong!");
                MainMenu();
            }
            Console.WriteLine("Press function:\r\n1: Choose dungeon\r\n2: Check features\r\n3: Back to main menu");
            int choose = Convert.ToInt32(Console.ReadLine());
            if (choose == 1)
                ComeToDung(player);
            if (choose == 2)
                HeroInfo(player);
            if(choose == 3)
            {
                MainMenu();    
            }
            else
            {
                Console.WriteLine($"Some thing goes wrong! Trouble on {this.ToString()}");
            }
        }

        private void ComeToDung(Hero hero)
        {
            ConcreteFactory dungFactory = new ConcreteFactory();

            Console.WriteLine(DungeonInfo.ChooseDungInfo());
            int dung = Convert.ToInt32(Console.ReadLine());
            if (dung > 1 && dung * 2 > hero.Level)
            {
                Console.WriteLine($"You are not allow to move on level {dung}. You should be at least {dung * 2} level");
                ComeToDung(hero);
            }
            else
            {
                Dungeon dungeon = dungFactory.CreateDungeon(dung);
                if (dungeon != null)
                    Console.WriteLine(DungeonInfo.ChooseDungInfo());
            }
        }

        private void ShowAll(Menu menu)
        {
            var res = menu.AllCharacters();
            Console.WriteLine("________________________________________");
            foreach(var b in res)
            {
                Console.WriteLine($"{b.NickName} {b.Level} {b.HeroType}");
            }
            Console.WriteLine("________________________________________\r\n");
        }

        private string HeroInfo(Hero hero)
        {
            string info = $"{hero.NickName} - {hero.HeroType} - {hero.Level}\r\n" +
                $"Strength: {hero.Strength}\r\nAgility: {hero.Agility}\r\nVitality: {hero.Vitality}\r\n" +
                $"Heal points: {hero.HealPoints}\r\nMana: {hero.Mana}\r\n" +
                $"Experience to {hero.Level+1}: {hero.Experience} of {hero.ExperienceBar}\r\n" +
                $"Avarage damage per hit: {hero.Damage}";
            return info;
        }

        #region State Handlers

        private static void KilledStateHandler(object sender, ConsoleWarsEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private static void GetLevelStateHandler(object sender, ConsoleWarsEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private static void MoveToDungStateHandler(object sender, ConsoleWarsEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private static void HitStateHandler(object sender, ConsoleWarsEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private static void GetDamageStateHandler(object sender, ConsoleWarsEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        #endregion
    }
}
