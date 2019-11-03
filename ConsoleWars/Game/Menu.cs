using ConsoleWars.EF;
using ConsoleWars.Handlers;
using ConsoleWars.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWars.Game
{
    public class Menu
    {
        private HeroContext heroContext;

        public Menu() 
        {
            heroContext = new HeroContext();
        }

        internal void ChooseHero(string nickname, ConsoleWarsStateHandler created, 
            ConsoleWarsStateHandler killed, ConsoleWarsStateHandler gotLevel, 
            ConsoleWarsStateHandler moveToDung, ConsoleWarsStateHandler hited,
            ConsoleWarsStateHandler attacked, ConsoleWarsStateHandler heroInfo)
        {
            Hero hero = new WarriorHero(nickname);

            if (nickname == null)
                throw new Exception("Error! Hero doesn't exist!");
            else if(heroContext.Features.Where(x=>x.NickName==nickname)==null)
            {
                throw new Exception("Hero with such nickname doesn't exist");
            }
            else
            {
                hero = heroContext.Features.Where(x => x.NickName == nickname).First() as Hero;
            }

            hero.Created += created;
            hero.Attacked += attacked;
            hero.GotLevel += gotLevel;
            hero.HeroInfo += heroInfo;
            hero.Hited += hited;
            hero.Killed += killed;
            hero.MovedToDungeon += moveToDung;
        }

        internal void AllCharacters()
        {
            var result = heroContext.Features.AsEnumerable().ToList();
            foreach (var r in result)
            {
                Console.WriteLine($"{r.NickName} - {r.Level} - {r.Level}\r\n");
            }
        }

        internal Hero FindCharacter(string nickName)
        {
            return heroContext.Features.Where(x => x.NickName == nickName).First() as Hero;
        }

        internal string NewHero(string nickname, HeroType type)
        {
            Hero hero = null;

            if (heroContext.Features.Any(x => x.NickName == nickname) == true)
            {
                return "Character with such nickname already exist.\r\nTry to choose another one";
            }
            else
            {
                if (type == HeroType.Warrior) 
                    hero = new WarriorHero(nickname);
                if (type == HeroType.Mage)
                    hero = new MageHero(nickname);
                if (type == HeroType.Rogue)
                    hero = new RogueHero(nickname);
                else
                    return "Some thing goes wrong! Check this out";
                heroContext.Features.Add(hero);
                heroContext.SaveChanges();
                return "Character successful created";
            }
        }
    }
}
