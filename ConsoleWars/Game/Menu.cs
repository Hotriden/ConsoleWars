using ConsoleWars.DAL.Interfaces;
using ConsoleWars.EF;
using ConsoleWars.Handlers;
using ConsoleWars.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ConsoleWars.DAL.Entities;

namespace ConsoleWars.Game
{
    public class Menu
    {
        IUnitOfWork DataBase;

        public Menu(IUnitOfWork unitOfWork) 
        {
            DataBase = unitOfWork;
        }

        internal Hero MapperToHero(HeroFeature feature)
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Hero, HeroFeature>();
                cfg.CreateMap<HeroFeature, Hero>();
            });
            mapperConfiguration.AssertConfigurationIsValid();
            var mapper = mapperConfiguration.CreateMapper();
            return mapper.Map<Hero>(feature);
        }

        internal HeroFeature MapperToFeature(Hero hero)
        {
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<HeroFeature, Hero>();
            });
            mapperConfiguration.AssertConfigurationIsValid();
            var mapper = mapperConfiguration.CreateMapper();
            return mapper.Map<HeroFeature>(hero);
        }

        internal void ChooseHero(string nickname, ConsoleWarsStateHandler created, 
            ConsoleWarsStateHandler killed, ConsoleWarsStateHandler gotLevel, 
            ConsoleWarsStateHandler moveToDung, ConsoleWarsStateHandler hited,
            ConsoleWarsStateHandler attacked, ConsoleWarsStateHandler heroInfo)
        {
            Hero hero = new WarriorHero(nickname);

            if (nickname == null)
                throw new Exception("Error! Hero doesn't exist!");
            else if(DataBase.Features.Get(nickname)!=null)
            {
                throw new Exception("Hero with such nickname doesn't exist");
            }
            else
            {
                hero = MapperToHero((DataBase.Features.Get(nickname)));
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
            var result = DataBase.Features.GetAll();
            foreach (var r in result)
            {
                Console.WriteLine($"{r.NickName} - {r.Level} - {r.Level}\r\n");
            }
        }

        internal Hero FindCharacter(string nickName)
        {
            return MapperToHero((DataBase.Features.Get(nickName)));
        }

        internal string NewHero(string nickname, HeroType type)
        {
            Hero hero = null;

            if (DataBase.Features.Get(nickname) != null)
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
                DataBase.Features.Create(MapperToFeature(hero));
                DataBase.Save();
                return "Character successful created";
            }
        }
    }
}
