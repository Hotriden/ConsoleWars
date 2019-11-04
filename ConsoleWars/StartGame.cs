using ConsoleWars.Commands;
using ConsoleWars.DAL.Interfaces;
using ConsoleWars.Game;
using ConsoleWars.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars
{
    class StartGame
    {
        IUnitOfWork DataBase;
        MenuCommands menu;

        public StartGame(IUnitOfWork unitOfWork)
        {
            DataBase = unitOfWork;
            menu = new MenuCommands(DataBase);
        }
        public static void Main(string[] args)
        {
            menu.MainMenu();
        }
    }
}
