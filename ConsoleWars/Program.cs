using ConsoleWars.Game;
using ConsoleWars.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu<Hero> menu = new Menu<Hero>();
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
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void CreateCharacter(Menu<Hero> hero)
        {
            HeroType type = 0;

            Console.WriteLine("Input character nickname");
            string name = Convert.ToString(Console.ReadLine());
            if (name == null)
            {
                Console.WriteLine("Invalid nickname input");
            }
            Console.WriteLine("Choose type of character\r\n1: Warrior\r\n2: Mage\r\n3:Rogue");
            int com = Convert.ToInt32(Console.ReadLine());
            if(com == 1)
            {
                type = HeroType.Warrior;
            }
            else if (com == 2)
            {
                type = HeroType.Mage;
            }
            else if (com == 3)
            {
                type = HeroType.Rogue;
            }
            else
            {
                Console.WriteLine("Invalid cast");
            }
            hero.CreateCharacter(type, name, CreateStateHandler, KilledStateHandler,
                GetLevelStateHandler, MoveToDungStateHandler, HitStateHandler,
                AttackStateHandler, HeroInfoStateHandler);
        }

        private static void ContinueGame(Menu<Hero> hero)
        {
            throw new NotImplementedException();
        }

        private static void ShowAll(Menu<Hero> hero)
        {
            throw new NotImplementedException();
        }

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
    }
}
