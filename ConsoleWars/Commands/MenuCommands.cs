using ConsoleWars.DAL.Interfaces;
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
                Console.WriteLine("1:Create new hero\r\n2:Continue gane\r\n3:Show all characters\r\n4:Close game");
                try
                {
                    int command = Convert.ToInt32(Console.ReadLine());

                    switch (command)
                    {
                        case 1:
                            CreateCharacter(menu);
                            break;
                        case 2:
                            ContinueGame(menu);
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
            Features hero = new Features();
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
            AfterCreating(menu);
        }

        private void AfterCreating(Menu menu)
        {
            Console.WriteLine("To start game press 1\r\nBack to main menu press 2");
            int com = Convert.ToInt32(Console.ReadLine());
            if (com == 1)
                StartGame();
            else if (com == 2)
            {
                MainMenu();
            }
            else
            {
                Console.WriteLine("Invalid operation. Try again!");
                AfterCreating(menu);
            }
        }


        private void StartGame()
        {
            throw new NotImplementedException();
        }

        private void ContinueGame(Menu menu)
        {
            throw new NotImplementedException();
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

        #region State Handlers
        private static void CreateStateHandler(object sender, ConsoleWarsEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

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

        private static void AttackStateHandler(object sender, ConsoleWarsEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private static void HeroInfoStateHandler(object sender, ConsoleWarsEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        #endregion
    }
}
